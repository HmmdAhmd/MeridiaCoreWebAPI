using MeridiaCoreWebAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;

namespace MeridiaCoreWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme, Policy = Policies.OperatorRolePolicy)]
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        // GET: api/<OperatorController>
        [HttpGet]
        public string Get() => "operator";
        }
    }
}
