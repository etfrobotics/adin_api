using Microsoft.EntityFrameworkCore.Migrations;
using adin_api.Data;

namespace adin_api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240519120000_AddRackIdToStep")]
    public partial class AddRackIdToStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rack_id",
                table: "Steps",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rack_id",
                table: "Steps");
        }
    }
}
