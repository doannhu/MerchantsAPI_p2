
namespace MerchantsAPI.DTOs
{
    public class MerchantDto
    {
        public Guid Id { get; set; }
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
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DetailedResponseMessage { get; set; }
        public Guid? OrgBankId { get; set; }
        public Guid? OrgCompanyId { get; set; }
    }
}
