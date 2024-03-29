﻿namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("Order_Details")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_order_detail { get; set; }

        public long id_order { get; set; }
        public Order order { get; set; }

        public long id_product { get; set; }
        public Product product { get; set; }

        public string? name_size { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0.")]
        public int quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0.")]
        public decimal price { get; set; }
    }
}
