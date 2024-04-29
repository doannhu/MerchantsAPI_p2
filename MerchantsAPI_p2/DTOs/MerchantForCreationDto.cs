using System.ComponentModel.DataAnnotations;

namespace MerchantsAPI.DTOs
{
    public class MerchantForCreationDto
    {
        public string? MerchantCode { get; set; }
        public required string Name { get; set; }
        public string? Status { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? StateTerritory { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public List<string>? EmailAddresses { get; set; }
        public string? TaxId { get; set; }
    }
}
