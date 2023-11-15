using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderItemsAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            //--Order 1
            mb.Sql("INSERT INTO Orders (OrderDate) VALUES(GETDATE());");

            //--OrderItems for Order 1
            mb.Sql("INSERT INTO OrderItems(Quantity, PizzaId, OrderId) VALUES(1, 1, 1);");
            mb.Sql("INSERT INTO OrderItems(Quantity, PizzaId, OrderId) VALUES(2, 2, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM OrderItems");
            mb.Sql("DELETE FROM Orders");
        }
    }
}
