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

        /*
         * HttpContext là một đối tượng trong ASP.NET Core đại diện cho thông tin liên quan đến một yêu cầu HTTP cụ thể và phản hồi tương ứng từ máy chủ web. 
         * Nó chứa thông tin về các khía cạnh quan trọng của yêu cầu như URL, Headers, Cookies, Session, người dùng xác thực và nhiều thông tin khác.
         * HttpContext cung cấp cách tiếp cận để bạn có thể truy cập và thao tác với các thông tin này trong suốt quá trình xử lý yêu cầu của ứng dụng.
         * Điều này cho phép bạn thực hiện các tác vụ như xử lý yêu cầu, kiểm tra quyền truy cập, lưu trữ thông tin phiên làm việc, đọc thông tin yêu cầu, ghi thông tin vào phản hồi và nhiều thao tác khác liên quan đến giao tiếp HTTP.
         * HttpContext thường được truyền qua các Middleware và controllers trong ứng dụng ASP.NET Core, cho phép bạn tùy chỉnh xử lý yêu cầu dựa trên thông tin cụ thể của mỗi yêu cầu.
         */

    }

}
