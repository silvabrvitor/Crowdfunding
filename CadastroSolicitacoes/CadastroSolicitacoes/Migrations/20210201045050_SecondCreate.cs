using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroSolicitacoes.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Aluno_AlunoId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "NomeId",
                table: "Solicitacao");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "Solicitacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Aluno_AlunoId",
                table: "Solicitacao",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Aluno_AlunoId",
                table: "Solicitacao");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "Solicitacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NomeId",
                table: "Solicitacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Aluno_AlunoId",
                table: "Solicitacao",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
