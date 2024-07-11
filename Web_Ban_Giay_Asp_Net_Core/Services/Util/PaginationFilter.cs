namespace Web_Ban_Giay_Asp_Net_Core.Services.Util
{
    public class PaginationFilter
    {
        public int current_page { get; set; }
        public int page_size { get; set; }

        public PaginationFilter()
        {
            this.current_page = 1;
            this.page_size = 15; // mặc định trả về tối đa 15 item trên 1 page
        }

        public PaginationFilter(int page, int pageSize)
        {
            this.current_page = page < 1 ? 1 : page;
            this.page_size = pageSize > 15 ? 15 : pageSize; // mặc định trả về tối đa 15 item trên 1 page
        }
    }
}
