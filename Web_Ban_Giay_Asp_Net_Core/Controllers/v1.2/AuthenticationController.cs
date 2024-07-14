using Web_Ban_Giay_Asp_Net_Core.Constants.String;
using Web_Ban_Giay_Asp_Net_Core.Models.Request;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Controllers.v1_2
{
    [Route(RouterControllerName.Authentication_V1_2)]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1.2")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;

        public AuthenticationController(IAuthentication authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("validate/user")]
        public async Task<IActionResult> ValidateUser([FromBody] ValidateUserRequest validateUserRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(validateUserRequest);
            }

            ValidateUserResponse dataResponse = await _authenticationService.ValidateUser(validateUserRequest);

            return Ok(new Response<ValidateUserResponse>(dataResponse));
        }


    }
}
