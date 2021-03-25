using Microsoft.EntityFrameworkCore.Migrations;

namespace option_one.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    service_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_title = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    service_desc = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    service_promocode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    service_status = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.service_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "service_id", "service_desc", "service_promocode", "service_status", "service_title" },
                values: new object[,]
                {
                    { 1, "Siteconstructor decription", "SiteconstructorPromocode", "Inactive", "Siteconstructor" },
                    { 2, "Appvision description", "Appvisionpromocode", "Inactive", "Appvision.com" },
                    { 3, "Analytics decription", "Analyticspromocode", "Inactive", "Analytics.com" },
                    { 4, "Logotype decription", "Logotypepromocode", "Inactive", "Logotype" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "password", "user_name" },
                values: new object[,]
                {
                    { 1, "Password1", "User1" },
                    { 2, "Password2", "User2" },
                    { 3, "Password3", "User3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
