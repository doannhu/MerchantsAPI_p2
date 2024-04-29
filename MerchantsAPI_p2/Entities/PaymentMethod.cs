namespace MerchantsAPI_p2.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public string? PaymentMethodType { get; set; }
        public string? RemitDeliveryMethod { get; set; }
        public bool? IsDefault { get; set; } = true;
    }
}
