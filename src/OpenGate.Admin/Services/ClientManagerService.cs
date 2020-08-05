using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenGate.Admin.EntityFramework.Shared.DbContexts;
using OpenGate.Admin.EntityFramework.Shared.Entities;

namespace OpenGate.Admin.Services {
    class ClientManagerService : IClientManagerService {
        public readonly IdentityServerConfigurationDbContext _context;

        public ClientManagerService(IdentityServerConfigurationDbContext context) {
            _context = context;
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
    }
}