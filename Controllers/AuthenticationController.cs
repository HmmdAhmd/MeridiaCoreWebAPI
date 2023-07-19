using MeridiaCoreWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MeridiaCoreWebAPI.Utility;
using Newtonsoft.Json;

namespace MeridiaCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private UtilityFunctions _utilityFunctions;

        public AuthenticationController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, UtilityFunctions utilityFunctions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _utilityFunctions = utilityFunctions;
        }
    }
}
