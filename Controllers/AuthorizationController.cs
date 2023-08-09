using Microsoft.AspNetCore.Mvc;
using MeridiaCoreWebAPI.Authorization;
using Microsoft.AspNetCore;
using Newtonsoft.Json;
using MeridiaCoreWebAPI.Constants;

namespace MeridiaCoreWebAPI.Controllers
{
    public class AuthorizationController : Controller
    {
        private HttpClient client = null;

        public AuthorizationController(IConfiguration config)
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(config.GetValue<string>(ConfigurationConstants.AUTHORIZATION_SERVER_URL))
            };
        }

        [HttpPost($"~/{AuthEndpoints.EXCHANGE_TOKEN}")]
        [IgnoreAntiforgeryToken]
        [Produces("application/json")]
        public async Task<Dictionary<string, string>> Connect()
        {
            var request = HttpContext.GetOpenIddictServerRequest() ??
                          throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            var formData = new Dictionary<string, string>
            {
                { "scope", request.Scope },
                { "grant_type", request.GrantType },
                { "grantType", request.GrantType },
                { "username", request.Username },
                { "password", request.Password }
            };

            var res = await client.PostAsync("connect/token", new FormUrlEncodedContent(formData));

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Content.ReadAsStringAsync().Result);
        }
    }
}
