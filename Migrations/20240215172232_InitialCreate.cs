using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureWorksbackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonType = table.Column<string>(type: "TEXT", nullable: true),
                    NameStyle = table.Column<bool>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Suffix = table.Column<string>(type: "TEXT", nullable: true),
                    EmailPromotion = table.Column<int>(type: "INTEGER", nullable: false),
                    AdditionalContactInfo = table.Column<string>(type: "TEXT", nullable: true),
                    Demographics = table.Column<string>(type: "TEXT", nullable: true),
                    Rowguid = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.BusinessEntityID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
