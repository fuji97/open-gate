using Skoruba.AuditLogging.Services;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Resources;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Services;
using Skoruba.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;

namespace OpenGate.Admin.Services {
    public class ExtendedClientService : ClientService {
        public ExtendedClientService(IClientRepository clientRepository, IClientServiceResources clientServiceResources,
            IAuditEventLogger auditEventLogger) : base(clientRepository, clientServiceResources, auditEventLogger) {
        }
        

    }
}