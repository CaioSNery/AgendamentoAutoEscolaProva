using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaDaProva",
                table: "DiaDaProva");

            migrationBuilder.RenameTable(
                name: "DiaDaProva",
                newName: "AgendamentosDeProva");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Alunos",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "AgendamentosDeProva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgendamentosDeProva",
                table: "AgendamentosDeProva",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosDeProva_AlunoId",
                table: "AgendamentosDeProva",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentosDeProva_Alunos_AlunoId",
                table: "AgendamentosDeProva",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentosDeProva_Alunos_AlunoId",
                table: "AgendamentosDeProva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgendamentosDeProva",
                table: "AgendamentosDeProva");

            migrationBuilder.DropIndex(
                name: "IX_AgendamentosDeProva_AlunoId",
                table: "AgendamentosDeProva");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "AgendamentosDeProva");

            migrationBuilder.RenameTable(
                name: "AgendamentosDeProva",
                newName: "DiaDaProva");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaDaProva",
                table: "DiaDaProva",
                column: "Id");
        }
    }
}
