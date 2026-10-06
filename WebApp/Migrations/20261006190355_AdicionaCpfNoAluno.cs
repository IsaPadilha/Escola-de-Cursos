using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCpfNoAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "TBAlunos",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TBAlunos_Cpf",
                table: "TBAlunos",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBAlunos_Cpf",
                table: "TBAlunos");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "TBAlunos");
        }
    }
}
