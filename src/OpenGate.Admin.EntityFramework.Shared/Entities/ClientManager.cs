using IdentityServer4.EntityFramework.Entities;

namespace OpenGate.Admin.EntityFramework.Shared.Entities {
    public class ClientManager {
        public string UserId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}