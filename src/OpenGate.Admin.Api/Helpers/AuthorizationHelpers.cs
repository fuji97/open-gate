using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OpenGate.Admin.Api.Configuration.Constants;

namespace OpenGate.Admin.Api.Helpers {
    public static class AuthorizationHelpers {
        public static async Task<bool> IsAdmin(this IAuthorizationService authorization, ClaimsPrincipal user) {
            return (await authorization.AuthorizeAsync(user, AuthorizationConsts.AdministrationPolicy)).Succeeded;
        }
    }
}