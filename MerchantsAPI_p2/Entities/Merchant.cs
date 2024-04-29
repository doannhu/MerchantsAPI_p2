using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MerchantsAPI.Entities
{
    public class Merchant
    {
        [Key]
        public Guid Id { get; set; }
        public string? MerchantCode { get; set; }
        [MaxLength(200)]
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
        [Required]
        public string? CreatedBy { get; set; } =  "defaultUser";
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public string? DetailedResponseMessage { get; set; }
        public Guid? OrgBankId { get; set; }
        public Guid? OrgCompanyId { get; set; }
        public string? PaymentMethodType { get; set; }
        public string? RemitDeliveryMethod { get; set; }
        public bool? IsDefault { get; set; } = true;

        public Merchant() { }

        public Merchant(Guid id, User user, Bank bank, Company company)
        {
            Id = id;
            CreatedBy = user.Name;
            OrgBankId = bank.Id;
            OrgCompanyId = company.Id;
        }

        [SetsRequiredMembers]
        public Merchant(
                        Guid id,
                        string merchantCode,
                        string name,
                        string status,
                        string address,
                        string city,
                        string stateTerritory,
                        string postalCode,
                        string country,
                        string phone,
                        List<string> emailAddresses,
                        string taxId,
                        User user,
                        DateTime createdDate,
                        string detailedResponseMessage,
                        Bank bank,
                        Company company
)
        {
            Id = id;
            MerchantCode = merchantCode;
            Name = name;
            Status = status;
            Address = address;
            City = city;
            StateTerritory = stateTerritory;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            EmailAddresses = emailAddresses;
            TaxId = taxId;
            CreatedBy = user.Name;
            CreatedDate = createdDate;
            DetailedResponseMessage = detailedResponseMessage;
            OrgBankId = bank.Id;
            OrgCompanyId = company.Id;
        }

        public Merchant(
                Guid id,
                string merchantCode,
                string name,
                string status,
                string address,
                string city,
                string stateTerritory,
                string postalCode,
                string country,
                string phone,
                List<string> emailAddresses,
                string taxId,
                User user,
                DateTime createdDate,
                string detailedResponseMessage,
                Bank bank,
                Company company,
                string paymentMethodType,
                string remitDeliveryMethod,
                bool isDefault

)
        {
            Id = id;
            MerchantCode = merchantCode;
            Name = name;
            Status = status;
            Address = address;
            City = city;
            StateTerritory = stateTerritory;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            EmailAddresses = emailAddresses;
            TaxId = taxId;
            CreatedBy = user.Name;
            CreatedDate = createdDate;
            DetailedResponseMessage = detailedResponseMessage;
            OrgBankId = bank.Id;
            OrgCompanyId = company.Id;
            PaymentMethodType = paymentMethodType;
            RemitDeliveryMethod = remitDeliveryMethod;
            IsDefault = isDefault;
        }
    }
}
