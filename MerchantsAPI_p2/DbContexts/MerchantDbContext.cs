using MerchantsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchantsAPI.DbContexts
{
    public class MerchantDbContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companys { get; set; } = null!;
        public DbSet<Bank> Banks { get; set; } = null!;
        public DbSet<Merchant> Merchants { get; set; } = null !;

        public MerchantDbContext(DbContextOptions<MerchantDbContext> options)
            : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            User user1 = new(Guid.Parse("c53652ec-ac46-429b-b198-987c48604318"), "aubrey_waters");
            User user2 = new(Guid.Parse("18e53190-76be-4079-bc85-534f92b5bbc4"), "jaxon_88");

            Company company1 = new(Guid.Parse("14331ff0-09b1-4f8a-a8d8-e938af3b0a3c"), "INTRO Travel");
            Company company2 = new(Guid.Parse("8d35b03a-dc8d-4e5c-9fbb-3213e899d146"), "G Adventures");

            Bank bank1 = new(Guid.Parse("978f6fdb-a004-40bf-9d7e-394d6a9fc8d4"), "Commonwealth Bank");
            Bank bank2 = new(Guid.Parse("8ed248b6-7246-44d9-a00a-f26ce935410c"), "ANZ");

            Merchant merchant1 = new(Guid.Parse("cf922504-b096-49ce-a3ca-9b8da0b18cf5"),
                                    "MERCHANT_CODE",
                                    "Merchant Name",
                                    "ACTIVE",
                                    "123 Main Street",
                                    "New York",
                                    "NY",
                                    "10001",
                                    "USA",
                                    "281-555-1212",
                                    new List<string> { "email@example.com" },
                                    "99-9999999",
                                    user1,
                                    DateTime.Now,
                                    "Success: Merchant successfully created",
                                    bank1,
                                    company1);
            Merchant merchant2 = new(Guid.Parse("f6767a42-955e-403c-bd38-520f5f7af6ec"),
                                    "MERCHANT_CODE_2",
                                    "Merchant Name 2",
                                    "ACTIVE",
                                    "456 Elm Street", 
                                    "Los Angeles",
                                    "CA", 
                                    "90012",
                                    "USA", 
                                    "555-123-4567", 
                                    new List<string> { "email2@example.com" },
                                    "TAX_ID_2",
                                    user1,
                                    DateTime.Now,
                                    "Success: Merchant successfully created",
                                    bank1,
                                    company1);

            _ = modelBuilder.Entity<User>().HasData(
                    user1,
                    user2
                );
            _ = modelBuilder.Entity<Company>().HasData(
                    company1,
                    company2
                );
            _ = modelBuilder.Entity<Bank>().HasData(
                    bank1,
                    bank2
                );

            _ = modelBuilder.Entity<Merchant>().HasData(
                    merchant1,
                    merchant2
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
