using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PizzaBox.Storage.Migrations
{
    public partial class addedStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AStoreEntityId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityId);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 1L, "ChicagoStore", "Downtown Chicago" },
                    { 2L, "NewYorkStore", "Big Apple" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AStoreEntityId",
                table: "Orders",
                column: "AStoreEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_AStoreEntityId",
                table: "Orders",
                column: "AStoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_AStoreEntityId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AStoreEntityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AStoreEntityId",
                table: "Orders");
        }
    }
}
