namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum StatusProduct
    {
        BINH_THUONG = 1,
        MOI = 2,
        HOT = 3,
        KHUYEN_MAI = 4,
        TAM_HET_HANG = 5,
        HET_HANG = 6,
        CAM_BAN = 7
    }

    public class Product
    {
        public long id_product { get; set; }

        public string name_product { get; set; }

        public int star_review { get; set; }

        public int id_status_product { get; set; }

        public ICollection<HistoryPriceProduct> list_price { get; set; }

        public ICollection<ImageProduct> images { get; set; }

        public ICollection<SizeProduct> size_products { get; set; }

        public Brand brand { get; set; }

        public TypeProduct type_product { get; set; }
    }
}
