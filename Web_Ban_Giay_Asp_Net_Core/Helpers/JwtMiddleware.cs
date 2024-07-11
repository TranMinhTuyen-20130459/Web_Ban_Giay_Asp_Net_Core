using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Web_Ban_Giay_Asp_Net_Core.Helpers
{
    /*
     * Đây là class dùng để kiểm tra xem có token nào được gắn trong phần Header của request gửi tới hay không?
     * - Nếu có:
     *   + Xác thực token đó có hợp lệ hay không ?
     *   + Trích xuất id của người dùng
     *   + Đính kèm người dùng đã xác thực vào HttpContext.Items hiện tại  
     */
    public class JwtMiddleware
    {
        /*
        * Một "Request delegate" thực chất là một phương thức (method) 
        * hoặc một delegate (đối tượng delegate) mà được gọi khi một yêu cầu HTTP đến.
        * Nó có thể thực hiện các tác vụ như xử lý yêu cầu, thêm thông tin vào yêu cầu, thực hiện logging, kiểm tra quyền truy cập, và nhiều tác vụ khác.
        */
        private readonly RequestDelegate _next;

        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        // Phương thức Invoke sẽ được gọi mỗi khi có request vào ứng dụng
        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            // Lấy token từ header của request
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            // Nếu tồn tại token, thực hiện đính kèm thông tin người dùng vào context
            if (token != null)
                AttachUserToContext(context, userRepository, token);

            // Tiếp tục xử lý request
            await _next(context); // => gọi delegate tiếp theo trong pipeline
        }

        // Phương thức AttachUserToContext để đính kèm thông tin người dùng vào context
        private void AttachUserToContext(HttpContext context, IUserRepository userRepository, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                // Xác thực token
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // Đặt clockskew là zero để token hết hạn chính xác vào thời gian hết hạn (thay vì sau 5 phút)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // Đính kèm thông tin người dùng vào context sau khi xác thực jwt thành công
                context.Items["User"] = userRepository.GetUserById(userId);
            }
            catch
            {
                // Không làm gì nếu xác thực jwt thất bại
                // Người dùng không được đính kèm vào context nên request không thể truy cập các route bảo mật
            }
        }
    }

}
