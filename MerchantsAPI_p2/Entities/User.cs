using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MerchantsAPI.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Merchant> Merchants { get; set; } = new List<Merchant>();

        public User() { }


        [SetsRequiredMembers]
        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public User(Guid id, string name, List<Merchant> merchants)
        {
            Id = id;
            Name = name;
            Merchants = merchants;
        }
    }
}
