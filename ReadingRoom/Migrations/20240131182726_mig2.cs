﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingRoom.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<int>(type: "int", nullable: false),
                    ArabicName = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    subscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    durationInDays = table.Column<float>(type: "real", nullable: false),
                    DownloadedBookAmount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.subscriptionId);
                    table.CheckConstraint("CH_Subscription_Description", "Description>= 8");
                    table.CheckConstraint("CH_Subscription_DownloadedBookAmount", "DownloadedBookAmount>=4");
                    table.CheckConstraint("CH_Subscription_durationInDays", "durationInDays >=15");
                    table.CheckConstraint("CH_Subscription_Price", "Price>=10");
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    subscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentId);
                    table.CheckConstraint("CH_Content_Author", "Author>=5");
                    table.CheckConstraint("CH_Content_Description", "Description>=10");
                    table.CheckConstraint("CH_Content_Price", "Price>=4");
                    table.ForeignKey(
                        name: "FK_Content_Subscription_subscriptionId",
                        column: x => x.subscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "subscriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    subscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.CheckConstraint("CH_Person_Age", "Age>= 16");
                    table.CheckConstraint("CH_Person_Email", "EMAIL LIKE '%@______%.COM'");
                    table.CheckConstraint("CH_Person_FullName", "FullName>=3");
                    table.CheckConstraint("CH_Person_Phone", "Phone LIKE '07________'");
                    table.ForeignKey(
                        name: "FK_Person_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Subscription_subscriptionId",
                        column: x => x.subscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "subscriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content_subscriptionId",
                table: "Content",
                column: "subscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ContactEmail",
                table: "Department",
                column: "ContactEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_PhoneNumber",
                table: "Department",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_ContentId",
                table: "Person",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DepartmentId",
                table: "Person",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Phone",
                table: "Person",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_subscriptionId",
                table: "Person",
                column: "subscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Subscription");
        }
    }
}
