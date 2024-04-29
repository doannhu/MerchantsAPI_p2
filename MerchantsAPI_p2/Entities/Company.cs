using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MerchantsAPI.Entities
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Merchant> Merchants { get; set; } = new List<Merchant>();

        public Company() { }

        [SetsRequiredMembers]
        public Company(Guid id, string name) {
            Id = id;
            Name = name;
        }

        public Company(Guid id, string name, List<Merchant> merchants) 
        {
            Id = id;
            Name = name;
            Merchants = merchants;
        }
    }
}
