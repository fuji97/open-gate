using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenGate.Admin.Services {
    public interface IClientManagerService {
        Task<IList<string>> ClientManagersAsync(int clientId);
        
        Task<IList<int>> ClientManagedAsync(string userId);

        Task<bool> IsClientManagerAsync(int clientId, string userId);

        Task<bool> AddClientManagerAsync(int clientId, string userId);
        
        Task<bool> RemoveClientManagerAsync(int clientId, string userId);
    }
}