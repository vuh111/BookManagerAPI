using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagerDAL.Migrations
{
    public partial class BookManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Categories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Books",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Authors",
                newName: "IsActive");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Categories",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Books",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Authors",
                newName: "Active");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
