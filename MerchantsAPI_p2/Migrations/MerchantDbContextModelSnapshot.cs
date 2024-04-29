﻿// <auto-generated />
using System;
using MerchantsAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MerchantsAPI_p2.Migrations
{
    [DbContext(typeof(MerchantDbContext))]
    partial class MerchantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("MerchantsAPI.Entities.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("978f6fdb-a004-40bf-9d7e-394d6a9fc8d4"),
                            Name = "Commonwealth Bank"
                        },
                        new
                        {
                            Id = new Guid("8ed248b6-7246-44d9-a00a-f26ce935410c"),
                            Name = "ANZ"
                        });
                });

            modelBuilder.Entity("MerchantsAPI.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("14331ff0-09b1-4f8a-a8d8-e938af3b0a3c"),
                            Name = "INTRO Travel"
                        },
                        new
                        {
                            Id = new Guid("8d35b03a-dc8d-4e5c-9fbb-3213e899d146"),
                            Name = "G Adventures"
                        });
                });

            modelBuilder.Entity("MerchantsAPI.Entities.Merchant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BankId")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DetailedResponseMessage")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddresses")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsDefault")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MerchantCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrgBankId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrgCompanyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentMethodType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("RemitDeliveryMethod")
                        .HasColumnType("TEXT");

                    b.Property<string>("StateTerritory")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaxId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Merchants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cf922504-b096-49ce-a3ca-9b8da0b18cf5"),
                            Address = "123 Main Street",
                            City = "New York",
                            Country = "USA",
                            CreatedBy = "aubrey_waters",
                            CreatedDate = new DateTime(2024, 4, 28, 20, 31, 56, 213, DateTimeKind.Local).AddTicks(2213),
                            DetailedResponseMessage = "Success: Merchant successfully created",
                            EmailAddresses = "[\"email@example.com\"]",
                            IsDefault = true,
                            MerchantCode = "MERCHANT_CODE",
                            Name = "Merchant Name",
                            OrgBankId = new Guid("978f6fdb-a004-40bf-9d7e-394d6a9fc8d4"),
                            OrgCompanyId = new Guid("14331ff0-09b1-4f8a-a8d8-e938af3b0a3c"),
                            Phone = "281-555-1212",
                            PostalCode = "10001",
                            StateTerritory = "NY",
                            Status = "ACTIVE",
                            TaxId = "99-9999999"
                        },
                        new
                        {
                            Id = new Guid("f6767a42-955e-403c-bd38-520f5f7af6ec"),
                            Address = "456 Elm Street",
                            City = "Los Angeles",
                            Country = "USA",
                            CreatedBy = "aubrey_waters",
                            CreatedDate = new DateTime(2024, 4, 28, 20, 31, 56, 213, DateTimeKind.Local).AddTicks(2296),
                            DetailedResponseMessage = "Success: Merchant successfully created",
                            EmailAddresses = "[\"email2@example.com\"]",
                            IsDefault = true,
                            MerchantCode = "MERCHANT_CODE_2",
                            Name = "Merchant Name 2",
                            OrgBankId = new Guid("978f6fdb-a004-40bf-9d7e-394d6a9fc8d4"),
                            OrgCompanyId = new Guid("14331ff0-09b1-4f8a-a8d8-e938af3b0a3c"),
                            Phone = "555-123-4567",
                            PostalCode = "90012",
                            StateTerritory = "CA",
                            Status = "ACTIVE",
                            TaxId = "TAX_ID_2"
                        });
                });

            modelBuilder.Entity("MerchantsAPI.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c53652ec-ac46-429b-b198-987c48604318"),
                            Name = "aubrey_waters"
                        },
                        new
                        {
                            Id = new Guid("18e53190-76be-4079-bc85-534f92b5bbc4"),
                            Name = "jaxon_88"
                        });
                });

            modelBuilder.Entity("MerchantsAPI.Entities.Merchant", b =>
                {
                    b.HasOne("MerchantsAPI.Entities.Bank", null)
                        .WithMany("Merchants")
                        .HasForeignKey("BankId");

                    b.HasOne("MerchantsAPI.Entities.Company", null)
                        .WithMany("Merchants")
                        .HasForeignKey("CompanyId");

                    b.HasOne("MerchantsAPI.Entities.User", null)
                        .WithMany("Merchants")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MerchantsAPI.Entities.Bank", b =>
                {
                    b.Navigation("Merchants");
                });

            modelBuilder.Entity("MerchantsAPI.Entities.Company", b =>
                {
                    b.Navigation("Merchants");
                });

            modelBuilder.Entity("MerchantsAPI.Entities.User", b =>
                {
                    b.Navigation("Merchants");
                });
#pragma warning restore 612, 618
        }
    }
}
