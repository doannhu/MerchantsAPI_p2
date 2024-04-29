using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MerchantsAPI.Entities
{
    public class Bank
    {
        [Key]
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public ICollection<Merchant> Merchants { get; set; } = new List<Merchant>(); 
        public Bank() { }

        [SetsRequiredMembers]
        public Bank(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Bank(Guid id, string name, List<Merchant> merchants)
        {
            Id = id;
            Name = name;
            Merchants = merchants;
        }
    }
}
