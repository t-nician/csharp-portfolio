using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_portfolio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EncryptedData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nonce = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncryptedData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScryptParams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParamR = table.Column<int>(type: "INTEGER", nullable: false),
                    ParamN = table.Column<int>(type: "INTEGER", nullable: false),
                    ParamP = table.Column<int>(type: "INTEGER", nullable: false),
                    HashLength = table.Column<int>(type: "INTEGER", nullable: false),
                    SaltLength = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScryptParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    ScryptParamsId = table.Column<int>(type: "INTEGER", nullable: false),
                    EncryptedDataId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Accounts_EncryptedData_EncryptedDataId",
                        column: x => x.EncryptedDataId,
                        principalTable: "EncryptedData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_ScryptParams_ScryptParamsId",
                        column: x => x.ScryptParamsId,
                        principalTable: "ScryptParams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EncryptedDataId",
                table: "Accounts",
                column: "EncryptedDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ScryptParamsId",
                table: "Accounts",
                column: "ScryptParamsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "EncryptedData");

            migrationBuilder.DropTable(
                name: "ScryptParams");
        }
    }
}
