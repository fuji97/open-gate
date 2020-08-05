using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Common;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Extensions;
using Skoruba.IdentityServer4.Admin.EntityFramework.Interfaces;
using Skoruba.IdentityServer4.Admin.EntityFramework.Repositories;

namespace OpenGate.Admin.Services {
    public class ExtendedClientRepository<T> : ClientRepository<T> where T : Microsoft.EntityFrameworkCore.DbContext, IAdminConfigurationDbContext {
        public ExtendedClientRepository(T dbContext) : base(dbContext) {
        }
        

    }
}