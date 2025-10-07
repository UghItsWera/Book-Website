using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorPage.Migrations
{
    /// <inheritdoc />
    public partial class AddBookAndAdditionalContentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalContent",
                table: "AdditionalContent");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "AdditionalContent");

            migrationBuilder.RenameTable(
                name: "AdditionalContent",
                newName: "AdditionalContents");

            migrationBuilder.AlterColumn<string>(
                name: "CoverImagePath",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "AdditionalContents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "AdditionalContents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalContents",
                table: "AdditionalContents",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalContents",
                table: "AdditionalContents");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "AdditionalContents",
                newName: "AdditionalContent");

            migrationBuilder.AlterColumn<string>(
                name: "CoverImagePath",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "AdditionalContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "AdditionalContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "AdditionalContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalContent",
                table: "AdditionalContent",
                column: "Id");
        }
    }
}
