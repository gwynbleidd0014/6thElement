﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _6thElement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class changeModuleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Modules");
        }
    }
}
