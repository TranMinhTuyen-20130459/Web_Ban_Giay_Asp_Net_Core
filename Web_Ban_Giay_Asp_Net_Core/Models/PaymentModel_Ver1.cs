namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class PaymentModel_Ver1
    {
        [Range(1, 2, ErrorMessage = "Giá trị của id_status_payment phải từ 1 đến 2.")]
        public int id_status_payment { get; set; }

        [Range(1, 3, ErrorMessage = "Giá trị của id_method_payment phải từ 1 đến 3.")]
        public int id_method_payment { get; set; }
    }
}
