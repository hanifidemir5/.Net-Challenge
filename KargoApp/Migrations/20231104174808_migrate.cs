using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargoApp.Migrations
{
    /// <inheritdoc />
    public partial class migrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierConfigurationId",
                table: "Carriers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrierConfigurationId",
                table: "Carriers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
