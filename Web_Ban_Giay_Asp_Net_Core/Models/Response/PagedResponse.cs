namespace Web_Ban_Giay_Asp_Net_Core.Models.Response
{
    public class PagedResponse<T> : Response<T>
    {
        public int current_page { get; set; }
        public int page_size { get; set; }
        public int total_pages { get; set; }
        public int total_items { get; set; }

        public PagedResponse(T Data, int current_page, int page_size, int total_items) : base(Data)
        {
            this.current_page = current_page;
            this.page_size = page_size;
            total_pages = (int)Math.Ceiling(total_items / (double)page_size);
            this.total_items = total_items;
        }
    }
}
