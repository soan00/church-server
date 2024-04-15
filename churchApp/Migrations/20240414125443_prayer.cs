using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace churchApp.Migrations
{
    /// <inheritdoc />
    public partial class prayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTable_Role_Role Id",
                table: "UserTable");

            migrationBuilder.AlterColumn<int>(
                name: "Role Id",
                table: "UserTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Prayer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prayerRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Prayer_UserTable_userId",
                        column: x => x.userId,
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prayer_userId",
                table: "Prayer",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTable_Role_Role Id",
                table: "UserTable",
                column: "Role Id",
                principalTable: "Role",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTable_Role_Role Id",
                table: "UserTable");

            migrationBuilder.DropTable(
                name: "Prayer");

            migrationBuilder.AlterColumn<int>(
                name: "Role Id",
                table: "UserTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTable_Role_Role Id",
                table: "UserTable",
                column: "Role Id",
                principalTable: "Role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
