namespace MerchantsAPI.DTOs
{
    public class MerchantForUpdatePaymentDto
    {
        public string? PaymentMethodType { get; set; }
        public string? RemitDeliveryMethod { get; set; }
        public bool? IsDefault { get; set; }
    }
}
