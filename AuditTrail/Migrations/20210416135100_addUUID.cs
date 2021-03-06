using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditTrail.Migrations
{
    public partial class addUUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "Products",
                type: "text",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "AuditTrails",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        UserId = table.Column<string>(type: "text", nullable: true),
            //        TableName = table.Column<string>(type: "text", nullable: true),
            //        DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            //        OldValues = table.Column<string>(type: "json", nullable: true),
            //        NewValues = table.Column<string>(type: "json", nullable: true),
            //        AffectedColumns = table.Column<string>(type: "text", nullable: true),
            //        AuditType = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AuditTrails", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Products");
        }
    }
}
