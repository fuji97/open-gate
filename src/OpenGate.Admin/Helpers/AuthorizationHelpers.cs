using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OpenGate.Admin.Configuration.Constants;

namespace OpenGate.Admin.Helpers {
    public static class AuthorizationHelpers {
        public static async Task<bool> IsAdmin(this IAuthorizationService authorization, ClaimsPrincipal user) {
            return (await authorization.AuthorizeAsync(user, AuthorizationConsts.AdministrationPolicy)).Succeeded;
        }
    }
}