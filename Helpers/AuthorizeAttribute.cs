using Microsoft.AspNetCore.Mvc.Filters;

namespace Web_Ban_Giay_Asp_Net_Core.Helpers
{
    // Định nghĩa thuộc tính AuthorizeAttribute, có thể áp dụng cho lớp hoặc phương thức
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        // Phương thức thực hiện kiểm tra xác thực
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Truy cập dữ liệu người dùng từ context
            var user = context.HttpContext.Items["User"];

            // Kiểm tra nếu người dùng chưa đăng nhập
            if (user == null)
            {
                // Thiết lập kết quả trả về với thông báo Unauthorized và mã trạng thái 401
                context.Result = new JsonResult(new { message = "Unauthorized" })

                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

            }
        }
    }

}
