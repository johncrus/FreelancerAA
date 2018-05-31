using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FreelancerData.Migrations
{
    public partial class adddateexpireforjobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "JobAppliances",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpire",
                table: "Jobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateExpire",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "JobAppliances",
                newName: "id");
        }
    }
}
