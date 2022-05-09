using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.ByteBank.Dados.Migrations
{
    public partial class ultimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_conta_corrente_agencia_AgenciaId",
               table: "conta_corrente");

            migrationBuilder.AddForeignKey(
               name: "FK_conta_corrente_agencia_AgenciaId",
               table: "conta_corrente",
               column: "AgenciaId",
               principalTable: "agencia",
               principalColumn: "Id",
               onDelete: ReferentialAction.Cascade);



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
