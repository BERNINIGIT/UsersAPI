using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersAPI.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    USD_balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Password", "Role", "USD_balance" },
                values: new object[] { "bernini", "B3rn1n1", "admin", 50003.4m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Password", "Role", "USD_balance" },
                values: new object[] { "admin1", "admin1", "admin", 57703.4m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Password", "Role", "USD_balance" },
                values: new object[] { "guest1", "g35t", "user", 105.1m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Password", "Role", "USD_balance" },
                values: new object[] { "guest2", "g35t", "user", 105.1m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Password", "Role", "USD_balance" },
                values: new object[] { "guest3", "g35t", "user", 105.1m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
