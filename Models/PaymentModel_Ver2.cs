namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class PaymentModel_Ver2
    {
        public int id_status_payment { get; set; }
        public string name_status_payment { get; set; }
        public int id_method_payment { get; set; }
        public string name_method_payment { get; set; }

        public PaymentModel_Ver2(int id_status_payment, int id_method_payment)
        {
            this.id_status_payment = id_status_payment;
            this.name_status_payment = GetNameStatusPayment(id_status_payment);
            this.id_method_payment = id_method_payment;
            this.name_method_payment = GetNameMethodPayment(id_method_payment);
        }

        public string GetNameStatusPayment(int id_status_payment)
        {
            switch (id_status_payment)
            {
                case (int)StatusPaymentEnum.CHO_THANH_TOAN: return "CHỜ THANH TOÁN";
                case (int)StatusPaymentEnum.DA_THANH_TOAN: return "ĐÃ THANH TOÁN";
                default: return "";
            }
        }

        public string GetNameMethodPayment(int id_method_payment)
        {
            switch (id_method_payment)
            {
                case (int)MethodPaymentEnum.Cash: return "Cash";
                case (int)MethodPaymentEnum.Zalo_Pay: return "ZaloPay";
                case (int)MethodPaymentEnum.PayPal: return "PayPal";
                default: return "";
            }
        }
    }
}
