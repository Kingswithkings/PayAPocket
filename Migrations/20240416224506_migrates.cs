using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayAPocket.Migrations
{
    public partial class migrates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HouseAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserWalletId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseAddress",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserWalletId",
                table: "User");
        }
    }
}
