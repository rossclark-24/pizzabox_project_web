using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PizzaBox.Storage.Migrations
{
    public partial class addrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrustEntityId = table.Column<long>(type: "bigint", nullable: false),
                    SizeEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OrderEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustEntityId",
                        column: x => x.CrustEntityId,
                        principalTable: "Crusts",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Orders_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Orders",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeEntityId",
                        column: x => x.SizeEntityId,
                        principalTable: "Sizes",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzasEntityId = table.Column<long>(type: "bigint", nullable: false),
                    ToppingsEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzasEntityId, x.ToppingsEntityId });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizzas_PizzasEntityId",
                        column: x => x.PizzasEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingsEntityId",
                        column: x => x.ToppingsEntityId,
                        principalTable: "Toppings",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "Name",
                value: "pepperoni");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "Name",
                value: "pineapple");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 3L,
                column: "Name",
                value: "ham");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 4L,
                column: "Name",
                value: "green peppers");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 5L,
                column: "Name",
                value: "black olives");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityId",
                table: "Pizzas",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingsEntityId",
                table: "PizzaTopping",
                column: "ToppingsEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "Name",
                value: "meat");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "Name",
                value: "veggie");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 3L,
                column: "Name",
                value: "gluten-free");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 4L,
                column: "Name",
                value: "vegan");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 5L,
                column: "Name",
                value: "plain");
        }
    }
}
