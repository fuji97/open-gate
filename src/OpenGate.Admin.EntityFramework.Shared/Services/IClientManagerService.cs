using System.Collections.Generic;
using System.Threading.Tasks;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;

namespace OpenGate.Admin.EntityFramework.Shared.Services {
    public interface IClientManagerService {
        Task<IList<string>> ClientManagersAsync(int clientId);
        
        Task<IList<int>> ClientManagedAsync(string userId);

        Task<bool> IsClientManagerAsync(int clientId, string userId);

        Task<bool> AddClientManagerAsync(int clientId, string userId);
        
        Task<bool> RemoveClientManagerAsync(int clientId, string userId);

        Task<ClientsDto> GetManagedClients(string userId, string searchText, int page, int pageSize);
    }
}