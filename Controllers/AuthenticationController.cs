namespace Web_Ban_Giay_Asp_Net_Core.Controllers
{
    [Route("api/authentication/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public AuthenticationController(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        [HttpPost("login-user")]
        public IActionResult LoginUser([FromBody] LoginModel loginModel)
        {
            try
            {
                // kiểm tra sự hợp lệ của dữ liệu Json nhận vào
                if (!ModelState.IsValid) { return BadRequest(loginModel); }

                var userModel = _userRepository.GetUser(loginModel);

                // <=> User không có trong hệ thống
                if (userModel == null)
                {
                    var errorResponse = new ErrorResponse
                    {
                        status = (int)HttpStatusCode.Unauthorized, // => lỗi 401
                        error_code = "-1",
                        error_message = "Email or password is Invalid"
                    };
                    return StatusCode(401, errorResponse);
                }

                // <=> User có trong hệ thống
                var loginResponse = new LoginResponse
                {
                    access_token = FunctionUtil.GenerateJwtToken(userModel, _appSettings),
                    token_type = TokenTypes.BEARER,
                    expires_in = "3 minutes" // => thời gian hiệu lực của access_token
                };

                return Ok(loginResponse);

            }
            catch
            {
                var errorResponse = new ErrorResponse
                {
                    status = 500,
                    error_code = "-2",
                    error_message = "Error From Server"
                };
                return StatusCode(500, errorResponse);
            }
        }


    }
}
