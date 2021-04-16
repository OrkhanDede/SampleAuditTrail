using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditTrail.Migrations
{
    public partial class AuditTrailuuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "AuditTrails",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "AuditTrails");
        }
    }
}
