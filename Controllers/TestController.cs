using MeridiaCoreWebAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;

namespace MeridiaCoreWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public string Get() => "test";

        [Authorize(Policy = Policies.OperatorRolePolicy)]
        [Route("operator")]
        [HttpGet]
        public string GetOperator() => "operator";

        [Authorize(Policy = Policies.AdministratorRolePolicy)]
        [Route("admin")]
        [HttpGet]
        public string GetAdministrator() => "administrator";
    }
}
