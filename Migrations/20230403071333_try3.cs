using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Migrations
{
    /// <inheritdoc />
    public partial class try3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routine_Details_DetailsId",
                table: "Routine");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Details_DetailsId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropIndex(
                name: "IX_User_DetailsId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Routine_DetailsId",
                table: "Routine");

            migrationBuilder.RenameColumn(
                name: "DetailsId",
                table: "User",
                newName: "RoutineType");

            migrationBuilder.RenameColumn(
                name: "DetailsId",
                table: "Routine",
                newName: "RoutineType");

            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "Routine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Routine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ExerciceId",
                table: "Routine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Routine_ExerciceId",
                table: "Routine",
                column: "ExerciceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routine_Exercice_ExerciceId",
                table: "Routine",
                column: "ExerciceId",
                principalTable: "Exercice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routine_Exercice_ExerciceId",
                table: "Routine");

            migrationBuilder.DropIndex(
                name: "IX_Routine_ExerciceId",
                table: "Routine");

            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Routine");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Routine");

            migrationBuilder.DropColumn(
                name: "ExerciceId",
                table: "Routine");

            migrationBuilder.RenameColumn(
                name: "RoutineType",
                table: "User",
                newName: "DetailsId");

            migrationBuilder.RenameColumn(
                name: "RoutineType",
                table: "Routine",
                newName: "DetailsId");

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyType = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RoutineType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_DetailsId",
                table: "User",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine_DetailsId",
                table: "Routine",
                column: "DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routine_Details_DetailsId",
                table: "Routine",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Details_DetailsId",
                table: "User",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
