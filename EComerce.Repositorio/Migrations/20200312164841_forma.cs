using Microsoft.EntityFrameworkCore.Migrations;

namespace EComerce.Repositorio.Migrations
{
    public partial class forma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FormasPagamentos",
                columns: new[] { "FormaPagamentoId", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Forma de pagamento Boleto", "Boleto" },
                    { 2, "Forma de pagamento não definida", "Não definido" },
                    { 3, "Forma de pagamento cartão de crédtio", "Cartão de Crédito" },
                    { 4, "Forma de pagamento Depósito", "Depósito" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FormasPagamentos",
                keyColumn: "FormaPagamentoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FormasPagamentos",
                keyColumn: "FormaPagamentoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FormasPagamentos",
                keyColumn: "FormaPagamentoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FormasPagamentos",
                keyColumn: "FormaPagamentoId",
                keyValue: 4);
        }
    }
}
