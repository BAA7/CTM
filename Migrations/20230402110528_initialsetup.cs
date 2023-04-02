using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTM.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguageLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    languageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguageLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserQualificationLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    qualificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQualificationLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { 1, "C" },
                    { 2, "C++" },
                    { 3, "C#" },
                    { 4, "Java" },
                    { 5, "Python" }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Способен применять компьютерные/суперкомпьютерные методы", "ОПК-2" },
                    { 2, "Способен к разработке алгоритмических и программных решений в области системного и прикладного программирования", "ОПК-3" },
                    { 3, "Способен осуществлять поиск, критический анализ и синтез информации", "УК-1" }
                });

            migrationBuilder.InsertData(
                table: "UserLanguageLink",
                columns: new[] { "Id", "languageId", "userId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 1, 2 },
                    { 4, 3, 2 },
                    { 5, 4, 3 },
                    { 6, 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserQualificationLink",
                columns: new[] { "Id", "qualificationId", "userId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 1, 3 },
                    { 7, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "eMail", "name", "password" },
                values: new object[,]
                {
                    { 1, "ivanovii@mail.ru", "Иванов Иван Иванович", "ivanovPassword" },
                    { 2, "petrovpp@mail.ru", "Петров Петр Петрович", "petrovPassword" },
                    { 3, "maksimovmm@mail.ru", "Максимов Максим Максимович", "maksimovPassword" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "UserLanguageLink");

            migrationBuilder.DropTable(
                name: "UserQualificationLink");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
