namespace Web_Ban_Giay_Asp_Net_Core.Models.Response
{
    public class Response<T>
    {
        public T data { get; set; }
        public bool succeeded { get; set; }
        public string[] errors { get; set; }
        public string message { get; set; }

        public Response(T Data)
        {
            succeeded = true;
            errors = null;
            message = string.Empty;
            data = Data;
        }
    }
}
