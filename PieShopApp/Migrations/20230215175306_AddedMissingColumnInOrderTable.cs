﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PieShopApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedMissingColumnInOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Orders");
        }
    }
}
