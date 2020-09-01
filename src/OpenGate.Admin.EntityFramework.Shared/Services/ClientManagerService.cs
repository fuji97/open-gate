using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using OpenGate.Admin.EntityFramework.Shared.DbContexts;
using OpenGate.Admin.EntityFramework.Shared.Entities;
using Skoruba.AuditLogging.Services;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Events.Client;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Helpers;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Mappers;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Common;

namespace OpenGate.Admin.EntityFramework.Shared.Services {
    public class ClientManagerService : IClientManagerService {
        public readonly IdentityServerConfigurationDbContext _context;
        private readonly IAuditEventLogger _auditEventLogger;

        public ClientManagerService(IdentityServerConfigurationDbContext context, IAuditEventLogger eventLogger) {
            _context = context;
            _auditEventLogger = eventLogger;
        }

        public async Task<IList<string>> ClientManagersAsync(int clientId) {
            return await _context.ClientManagers
                .Where(c => c.ClientId == clientId)
                .Select(c => c.UserId)
                .ToListAsync();
        }

        public async Task<IList<int>> ClientManagedAsync(string userId) {
            return await _context.ClientManagers
                .Where(c => c.UserId == userId)
                .Select(c => c.ClientId)
                .ToListAsync();
        }

        public async Task<bool> IsClientManagerAsync(int clientId, string userId) {
            return await _context.ClientManagers
                .Where(c => c.ClientId == clientId)
                .AnyAsync(c => c.UserId == userId);
        }

        public async Task<bool> AddClientManagerAsync(int clientId, string userId) {
            await _context.ClientManagers.AddAsync(new ClientManager() {
                ClientId = clientId,
                UserId = userId
            });
            var result = await _context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<bool> RemoveClientManagerAsync(int clientId, string userId) {
            var clientManager = await _context.ClientManagers
                .FirstOrDefaultAsync(cm => cm.ClientId == clientId && cm.UserId == userId);

            if (clientManager == null) return false;

            _context.Remove(clientManager);
            var result = await _context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<ClientsDto> GetManagedClients(string userId, string searchText, int page, int pageSize) {
            var managedClients = await ClientManagedAsync(userId);
            
            var pagedList = new PagedList<Client>();

            Expression<Func<Client, bool>> searchCondition =
                x => x.ClientId.Contains(searchText) || x.ClientName.Contains(searchText);
            var listClients = await _context.Clients.Where(c => managedClients.Contains(c.Id))
                .WhereIf(!string.IsNullOrEmpty(searchText), searchCondition)
                .PageBy(x => x.Id, page, pageSize).ToListAsync();
            pagedList.Data.AddRange(listClients);
            pagedList.TotalCount =
                await _context.Clients.WhereIf(!string.IsNullOrEmpty(searchText), searchCondition).CountAsync();
            pagedList.PageSize = pageSize;
            var result = pagedList.ToModel();
            
            await _auditEventLogger.LogEventAsync(new ClientsRequestedEvent(result));
            
            return result;
            
        }
    }
}