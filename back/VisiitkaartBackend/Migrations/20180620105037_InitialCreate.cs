using Microsoft.EntityFrameworkCore.Migrations;

namespace VisiitkaartBackend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 200, nullable: true),
                    RoleValue = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "PasswordHash", "RoleValue" },
                values: new object[] { "admin@visiitkaart.ee", "2iYX3yd5wjY9ZErZzudZ2lXy7MvR46Wb/aHMkGYXlbsVja81", (byte)128 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
