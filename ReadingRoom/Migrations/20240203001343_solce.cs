using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingRoom.Migrations
{
    /// <inheritdoc />
    public partial class solce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Department_DepartmentId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Subscription_subscriptionId",
                table: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "subscriptionId",
                table: "Person",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Person",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Department_DepartmentId",
                table: "Person",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Subscription_subscriptionId",
                table: "Person",
                column: "subscriptionId",
                principalTable: "Subscription",
                principalColumn: "subscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Department_DepartmentId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Subscription_subscriptionId",
                table: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "subscriptionId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Department_DepartmentId",
                table: "Person",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Subscription_subscriptionId",
                table: "Person",
                column: "subscriptionId",
                principalTable: "Subscription",
                principalColumn: "subscriptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
