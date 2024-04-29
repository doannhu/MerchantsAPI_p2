using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MerchantsAPI_p2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MerchantCode = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    StateTerritory = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddresses = table.Column<string>(type: "TEXT", nullable: true),
                    TaxId = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DetailedResponseMessage = table.Column<string>(type: "TEXT", nullable: true),
                    OrgBankId = table.Column<Guid>(type: "TEXT", nullable: true),
                    OrgCompanyId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PaymentMethodType = table.Column<string>(type: "TEXT", nullable: true),
                    RemitDeliveryMethod = table.Column<string>(type: "TEXT", nullable: true),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: true),
                    BankId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Merchants_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Merchants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8ed248b6-7246-44d9-a00a-f26ce935410c"), "ANZ" },
                    { new Guid("978f6fdb-a004-40bf-9d7e-394d6a9fc8d4"), "Commonwealth Bank" }
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14331ff0-09b1-4f8a-a8d8-e938af3b0a3c"), "INTRO Travel" },
                    { new Guid("8d35b03a-dc8d-4e5c-9fbb-3213e899d146"), "G Adventures" }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "Address", "BankId", "City", "CompanyId", "Country", "CreatedBy", "CreatedDate", "DetailedResponseMessage", "EmailAddresses", "IsDefault", "MerchantCode", "ModifiedBy", "ModifiedDate", "Name", "OrgBankId", "OrgCompanyId", "PaymentMethodType", "Phone", "PostalCode", "RemitDeliveryMethod", "StateTerritory", "Status", "TaxId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cf922504-b096-49ce-a3ca-9b8da0b18cf5"), "123 Main Street", null, "New York", null, "USA", "aubrey_waters", new DateTime(2024, 4, 28, 20, 31, 56, 213, DateTimeKind.Local).AddTicks(2213), "Success: Merchant successfully created", "[\"email@example.com\"]", true, "MERCHANT_CODE", null, null, "Merchant Name", new Guid("978f6fdb-a004-40bf-9d7e-394d6a9fc8d4"), new Guid("14331ff0-09b1-4f8a-a8d8-e938af3b0a3c"), null, "281-555-1212", "10001", null, "NY", "ACTIVE", "99-9999999", null },
                    { new Guid("f6767a42-955e-403c-bd38-520f5f7af6ec"), "456 Elm Street", null, "Los Angeles", null, "USA", "aubrey_waters", new DateTime(2024, 4, 28, 20, 31, 56, 213, DateTimeKind.Local).AddTicks(2296), "Success: Merchant successfully created", "[\"email2@example.com\"]", true, "MERCHANT_CODE_2", null, null, "Merchant Name 2", new Guid("978f6fdb-a004-40bf-9d7e-394d6a9fc8d4"), new Guid("14331ff0-09b1-4f8a-a8d8-e938af3b0a3c"), null, "555-123-4567", "90012", null, "CA", "ACTIVE", "TAX_ID_2", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18e53190-76be-4079-bc85-534f92b5bbc4"), "jaxon_88" },
                    { new Guid("c53652ec-ac46-429b-b198-987c48604318"), "aubrey_waters" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_BankId",
                table: "Merchants",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_CompanyId",
                table: "Merchants",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_UserId",
                table: "Merchants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
