using Microsoft.EntityFrameworkCore.Migrations;

namespace GUI.Data.Migrations
{
    public partial class NewDesignforProcessed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgClassification",
                table: "ProcessImgDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgClassification",
                table: "ProcessImgDetails");
        }
    }
}
