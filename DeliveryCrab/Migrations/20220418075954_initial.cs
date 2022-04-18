using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryCrab.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "FirstName", "LastName", "Login", "Password" },
                values: new object[] { 3, 22, "maliutin.vas@yandex.ru", "Алексей", "Алесеев", "vasiliym", "vas123987" });
        }
    }
}
