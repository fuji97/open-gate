using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenGate.Admin.Configuration.Constants;
using OpenGate.Admin.ExceptionHandling;
using OpenGate.Admin.Helpers;

namespace OpenGate.Admin.Controllers
{
    [Authorize(Policy = AuthorizationConsts.ClientManagerPolicy)]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    public class HomeController : BaseController
    {
        private readonly ILogger<ConfigurationController> _logger;
        private IAuthorizationService _authorization;

        public HomeController(ILogger<ConfigurationController> logger, IAuthorizationService authorizationService) : base(logger)
        {
            _logger = logger;
            _authorization = authorizationService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.IsAdmin = await _authorization.IsAdmin(User);
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }

        public IActionResult Error()
        {
            // Get the details of the exception that occurred
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature == null) return View();

            // Get which route the exception occurred at
            string routeWhereExceptionOccurred = exceptionFeature.Path;

            // Get the exception that occurred
            Exception exceptionThatOccurred = exceptionFeature.Error;

            // Log the exception
            _logger.LogError(exceptionThatOccurred, $"Exception at route {routeWhereExceptionOccurred}");

            return View();
        }
    }
}





