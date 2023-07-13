using MeridiaCoreWebAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;

namespace MeridiaCoreWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme, Policy = Policies.AdministratorRolePolicy)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        // GET: api/<AdministratorController>
        [HttpGet]
        public string Get() => "administrator";
        }
    }
}
