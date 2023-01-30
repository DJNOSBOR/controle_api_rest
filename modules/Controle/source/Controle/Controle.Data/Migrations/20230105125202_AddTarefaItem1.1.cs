using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle.Data.Migrations
{
    public partial class AddTarefaItem11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TarefaItem_Tarefa_TarefaId",
                table: "TarefaItem");

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "TarefaItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_TarefaItem_Tarefa_TarefaId",
                table: "TarefaItem",
                column: "TarefaId",
                principalTable: "Tarefa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TarefaItem_Tarefa_TarefaId",
                table: "TarefaItem");

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "TarefaItem",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TarefaItem_Tarefa_TarefaId",
                table: "TarefaItem",
                column: "TarefaId",
                principalTable: "Tarefa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
