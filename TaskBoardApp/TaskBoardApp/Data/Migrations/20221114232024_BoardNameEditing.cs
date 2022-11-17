using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class BoardNameEditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoradId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23b57617-9ade-46ef-817c-e3d1ae627ad0");

            migrationBuilder.RenameColumn(
                name: "BoradId",
                table: "Tasks",
                newName: "BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_BoradId",
                table: "Tasks",
                newName: "IX_Tasks_BoardId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "689c5969-f49a-4866-a8f1-5b42a5ba72ab", 0, "629b023c-cc46-4361-8e62-4fab5a3b17e6", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEAsP2a7iNppuqVc33OTZwM+XDiygwRVcotfC9/sLshgxLd1OLCdAESZ82Zb/BBRH9Q==", null, false, "b451bd7d-8b0c-4427-a3ee-15a2f3c3fe66", false, "guest" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 15, 1, 20, 24, 235, DateTimeKind.Local).AddTicks(9405), "689c5969-f49a-4866-a8f1-5b42a5ba72ab" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 6, 15, 1, 20, 24, 235, DateTimeKind.Local).AddTicks(9438), "689c5969-f49a-4866-a8f1-5b42a5ba72ab" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 1, 15, 1, 20, 24, 235, DateTimeKind.Local).AddTicks(9441), "689c5969-f49a-4866-a8f1-5b42a5ba72ab" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 15, 1, 20, 24, 235, DateTimeKind.Local).AddTicks(9442), "689c5969-f49a-4866-a8f1-5b42a5ba72ab" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardId",
                table: "Tasks",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "689c5969-f49a-4866-a8f1-5b42a5ba72ab");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Tasks",
                newName: "BoradId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                newName: "IX_Tasks_BoradId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23b57617-9ade-46ef-817c-e3d1ae627ad0", 0, "f629f6bd-706e-4812-ba6b-16f68ed2cb8f", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEGOxK+QjAZpzoeg/Qw6trs+Oof1ZMr+RajB6DGaP6h88YCQvDb/EViSYN2ltNgXPVA==", null, false, "0afbde93-9d76-40bc-a659-27a76a596b47", false, "guest" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 7, 17, 0, 15, 100, DateTimeKind.Local).AddTicks(9025), "23b57617-9ade-46ef-817c-e3d1ae627ad0" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 6, 7, 17, 0, 15, 100, DateTimeKind.Local).AddTicks(9054), "23b57617-9ade-46ef-817c-e3d1ae627ad0" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 1, 7, 17, 0, 15, 100, DateTimeKind.Local).AddTicks(9057), "23b57617-9ade-46ef-817c-e3d1ae627ad0" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 7, 17, 0, 15, 100, DateTimeKind.Local).AddTicks(9059), "23b57617-9ade-46ef-817c-e3d1ae627ad0" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoradId",
                table: "Tasks",
                column: "BoradId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
