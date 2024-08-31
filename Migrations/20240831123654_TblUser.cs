using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class TblUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_refreshtoken",
                columns: table => new
                {
                    userid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    tokenid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    refreshtoken = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_refreshtoken", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true),
                    role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    islocked = table.Column<bool>(type: "bit", nullable: true),
                    failattempt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.username);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_refreshtoken");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
