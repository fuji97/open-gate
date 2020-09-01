using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenGate.Admin.Api.Configuration.Constants;
using OpenGate.Admin.Api.Dtos.Clients;
using OpenGate.Admin.Api.ExceptionHandling;
using OpenGate.Admin.Api.Helpers;
using OpenGate.Admin.Api.Mappers;
using OpenGate.Admin.Api.Resources;
using OpenGate.Admin.EntityFramework.Shared.DbContexts;
using OpenGate.Admin.EntityFramework.Shared.Services;
using Skoruba.AuditLogging.EntityFramework.Helpers.Common;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Helpers;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Resources;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Services.Interfaces;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Shared.ExceptionHandling;

namespace OpenGate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.ClientManagerPolicy)]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IApiErrorResources _errorResources;
        private readonly IAuthorizationService _authorization;
        private readonly IClientManagerService _clientManagerService;
        private readonly IdentityServerConfigurationDbContext _dbContext;
        private readonly IClientServiceResources _clientServiceResources;

        public ClientsController(IClientService clientService, IApiErrorResources errorResources, IAuthorizationService authorization, IClientManagerService clientManagerService, IdentityServerConfigurationDbContext dbContext, IClientServiceResources clientServiceResources) {
            _clientService = clientService;
            _errorResources = errorResources;
            _authorization = authorization;
            _clientManagerService = clientManagerService;
            _dbContext = dbContext;
            _clientServiceResources = clientServiceResources;
        }

        [HttpGet]
        public async Task<ActionResult<ClientsApiDto>> Get(string searchText, int page = 1, int pageSize = 10)
        {
            ClientsApiDto clientsApiDto;
            if (!await _authorization.IsAdmin(User)) {
                var pagedList =
                    await _clientManagerService.GetManagedClients(User.GetSubjectId(), searchText, page, pageSize);
                clientsApiDto = pagedList.ToClientApiModel<ClientsApiDto>();
            }
            else {
                var clientsDto = await _clientService.GetClientsAsync(searchText, page, pageSize);
                clientsApiDto = clientsDto.ToClientApiModel<ClientsApiDto>();
            }

            return Ok(clientsApiDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientApiDto>> Get(int id)
        {
            var clientDto = await _clientService.GetClientAsync(id);

            await NotFoundIfNotAdmin(clientDto.Id);

            var clientApiDto = clientDto.ToClientApiModel<ClientApiDto>();

            return Ok(clientApiDto);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody]ClientApiDto client)
        {
            var clientDto = client.ToClientApiModel<ClientDto>();

            if (!clientDto.Id.Equals(default)) {
                return BadRequest(_errorResources.CannotSetId());
            }

            var id = await _clientService.AddClientAsync(clientDto);
            client.Id = id;
            await _clientManagerService.AddClientManagerAsync(id, User.GetSubjectId());

            return CreatedAtAction(nameof(Get), new { id }, client);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ClientApiDto client)
        {
            var clientDto = client.ToClientApiModel<ClientDto>();

            await NotFoundIfNotAdmin(clientDto.Id);

            await _clientService.GetClientAsync(clientDto.Id);
            await _clientService.UpdateClientAsync(clientDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var clientDto = new ClientDto { Id = id };

            await _clientService.GetClientAsync(clientDto.Id);
            
            await NotFoundIfNotAdmin(id);
            
            await _clientService.RemoveClientAsync(clientDto);

            return Ok();
        }

        [HttpPost("Clone")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostClientClone([FromBody]ClientCloneApiDto client)
        {
            var clientCloneDto = client.ToClientApiModel<ClientCloneDto>();

            var originalClient = await _clientService.GetClientAsync(clientCloneDto.Id);

            await NotFoundIfNotAdmin(originalClient.Id);
            
            var id = await _clientService.CloneClientAsync(clientCloneDto);
            originalClient.Id = id;

            return CreatedAtAction(nameof(Get), new { id }, originalClient);
        }

        [HttpGet("{id}/Secrets")]
        public async Task<ActionResult<ClientSecretsApiDto>> GetSecrets(int id, int page = 1, int pageSize = 10)
        {
            await NotFoundIfNotAdmin(id);
            
            var clientSecretsDto = await _clientService.GetClientSecretsAsync(id, page, pageSize);
            var clientSecretsApiDto = clientSecretsDto.ToClientApiModel<ClientSecretsApiDto>();

            return Ok(clientSecretsApiDto);
        }

        [HttpGet("Secrets/{secretId}")]
        public async Task<ActionResult<ClientSecretApiDto>> GetSecret(int secretId)
        {
            var clientSecretsDto = await _clientService.GetClientSecretAsync(secretId);

            //var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == clientSecretsDto.ClientId);
            await NotFoundIfNotAdmin(clientSecretsDto.ClientId);

            var clientSecretDto = clientSecretsDto.ToClientApiModel<ClientSecretApiDto>();

            return Ok(clientSecretDto);
        }

        [HttpPost("{id}/Secrets")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostSecret(int id, [FromBody]ClientSecretApiDto clientSecretApi)
        {
            var secretsDto = clientSecretApi.ToClientApiModel<ClientSecretsDto>();
            secretsDto.ClientId = id;
            
            await NotFoundIfNotAdmin(id);

            if (!secretsDto.ClientSecretId.Equals(default))
            {
                return BadRequest(_errorResources.CannotSetId());
            }

            var secretId = await _clientService.AddClientSecretAsync(secretsDto);
            clientSecretApi.Id = secretId;

            return CreatedAtAction(nameof(GetSecret), new { secretId }, clientSecretApi);
        }

        [HttpDelete("Secrets/{secretId}")]
        public async Task<IActionResult> DeleteSecret(int secretId)
        {
            // TODO Find a way to check if the user have permissions to access the secret
            var clientSecret = new ClientSecretsDto { ClientSecretId = secretId };

            await _clientService.GetClientSecretAsync(clientSecret.ClientSecretId);
            await _clientService.DeleteClientSecretAsync(clientSecret);

            return Ok();
        }

        [HttpGet("{id}/Properties")]
        public async Task<ActionResult<ClientPropertiesApiDto>> GetProperties(int id, int page = 1, int pageSize = 10)
        {
            var clientPropertiesDto = await _clientService.GetClientPropertiesAsync(id, page, pageSize);
            
            await NotFoundIfNotAdmin(id);
            
            var clientPropertiesApiDto = clientPropertiesDto.ToClientApiModel<ClientPropertiesApiDto>();

            return Ok(clientPropertiesApiDto);
        }

        [HttpGet("Properties/{propertyId}")]
        public async Task<ActionResult<ClientPropertyApiDto>> GetProperty(int propertyId)
        {
            var clientPropertiesDto = await _clientService.GetClientPropertyAsync(propertyId);
            
            await NotFoundIfNotAdmin(clientPropertiesDto.ClientId);
            
            var clientPropertyApiDto = clientPropertiesDto.ToClientApiModel<ClientPropertyApiDto>();

            return Ok(clientPropertyApiDto);
        }

        [HttpPost("{id}/Properties")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostProperty(int id, [FromBody]ClientPropertyApiDto clientPropertyApi)
        {
            var clientPropertiesDto = clientPropertyApi.ToClientApiModel<ClientPropertiesDto>();
            clientPropertiesDto.ClientId = id;
            
            await NotFoundIfNotAdmin(id);

            if (!clientPropertiesDto.ClientPropertyId.Equals(default))
            {
                return BadRequest(_errorResources.CannotSetId());
            }

            var propertyId = await _clientService.AddClientPropertyAsync(clientPropertiesDto);
            clientPropertyApi.Id = propertyId;

            return CreatedAtAction(nameof(GetProperty), new { propertyId }, clientPropertyApi);
        }

        [HttpDelete("Properties/{propertyId}")]
        public async Task<IActionResult> DeleteProperty(int propertyId)
        {
            // TODO Find a way to check if the user have permissions to access the property
            var clientProperty = new ClientPropertiesDto { ClientPropertyId = propertyId };

            await _clientService.GetClientPropertyAsync(clientProperty.ClientPropertyId);
            await _clientService.DeleteClientPropertyAsync(clientProperty);

            return Ok();
        }

        [HttpGet("{id}/Claims")]
        public async Task<ActionResult<ClientClaimsApiDto>> GetClaims(int id, int page = 1, int pageSize = 10)
        {
            var clientClaimsDto = await _clientService.GetClientClaimsAsync(id, page, pageSize);
            
            await NotFoundIfNotAdmin(id);
            
            var clientClaimsApiDto = clientClaimsDto.ToClientApiModel<ClientClaimsApiDto>();

            return Ok(clientClaimsApiDto);
        }

        [HttpGet("Claims/{claimId}")]
        public async Task<ActionResult<ClientClaimApiDto>> GetClaim(int claimId)
        {
            var clientClaimsDto = await _clientService.GetClientClaimAsync(claimId);
            
            await NotFoundIfNotAdmin(clientClaimsDto.ClientId);
            
            var clientClaimApiDto = clientClaimsDto.ToClientApiModel<ClientClaimApiDto>();

            return Ok(clientClaimApiDto);
        }

        [HttpPost("{id}/Claims")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostClaim(int id, [FromBody]ClientClaimApiDto clientClaimApiDto)
        {
            var clientClaimsDto = clientClaimApiDto.ToClientApiModel<ClientClaimsDto>();
            clientClaimsDto.ClientId = id;
            
            await NotFoundIfNotAdmin(id);

            if (!clientClaimsDto.ClientClaimId.Equals(default))
            {
                return BadRequest(_errorResources.CannotSetId());
            }

            var claimId = await _clientService.AddClientClaimAsync(clientClaimsDto);
            clientClaimApiDto.Id = claimId;

            return CreatedAtAction(nameof(GetClaim), new { claimId }, clientClaimApiDto);
        }

        [HttpDelete("Claims/{claimId}")]
        public async Task<IActionResult> DeleteClaim(int claimId)
        {
            // TODO Find a way to check if the user have permissions to access the claim
            var clientClaimsDto = new ClientClaimsDto { ClientClaimId = claimId };

            await _clientService.GetClientClaimAsync(claimId);
            await _clientService.DeleteClientClaimAsync(clientClaimsDto);

            return Ok();
        }

        private async Task<PagedList<Client>> GetManagedClients(string searchText, int page, int pageSize, IList<int> managedClients) {
            var pagedList = new PagedList<Client>();
            // TODO Extractred the original query code from the repository, not a good idea

            Expression<Func<Client, bool>> searchCondition =
                x => x.ClientId.Contains(searchText) || x.ClientName.Contains(searchText);
            var listClients = await _dbContext.Clients.Where(c => managedClients.Contains(c.Id))
                .WhereIf(!string.IsNullOrEmpty(searchText), searchCondition)
                .PageBy(x => x.Id, page, pageSize).ToListAsync();
            pagedList.Data.AddRange(listClients);
            pagedList.TotalCount =
                await _dbContext.Clients.WhereIf(!string.IsNullOrEmpty(searchText), searchCondition).CountAsync();
            pagedList.PageSize = pageSize;
            return pagedList;
        }

        private async Task<bool> IsUserManagerOrAdmin(int clientId) {
            return await _authorization.IsAdmin(User) ||
                   await _clientManagerService.IsClientManagerAsync(clientId, User.GetSubjectId());
        }

        private async Task NotFoundIfNotAdmin(int id) {
            if (!await IsUserManagerOrAdmin(id)) {
                // TODO To test, it's ok to return null?
                throw new UserFriendlyErrorPageException(
                    string.Format(_clientServiceResources.ClientDoesNotExist().Description, (object) id));
            }
        }
    }
}





