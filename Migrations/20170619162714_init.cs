using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netcoreef.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtendField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateTime = table.Column<long>(nullable: false),
                    Field = table.Column<string>(maxLength: 30, nullable: true),
                    Key = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 20, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Key = table.Column<string>(maxLength: 100, nullable: true),
                    Value = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtendField");

            migrationBuilder.DropTable(
                name: "Setting");
        }
    }
}
