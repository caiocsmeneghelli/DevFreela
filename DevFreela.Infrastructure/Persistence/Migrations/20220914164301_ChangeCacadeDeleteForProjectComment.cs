﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    public partial class ChangeCacadeDeleteForProjectComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_Projects_IdProject",
                table: "ProjectComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_Users_IdUser",
                table: "ProjectComments");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_Projects_IdProject",
                table: "ProjectComments",
                column: "IdProject",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_Users_IdUser",
                table: "ProjectComments",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_Projects_IdProject",
                table: "ProjectComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComments_Users_IdUser",
                table: "ProjectComments");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_Projects_IdProject",
                table: "ProjectComments",
                column: "IdProject",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComments_Users_IdUser",
                table: "ProjectComments",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
