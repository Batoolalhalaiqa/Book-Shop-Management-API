using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Shop_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DurationDay",
                table: "Subsecription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "02/01/2024 15:03:08",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "02/01/2024 14:43:22");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DurationDay",
                table: "Subsecription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "02/01/2024 14:43:22",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "02/01/2024 15:03:08");
        }
    }
}
