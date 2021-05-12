using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class addingrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_AStoreEntityId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "AStoreEntityId",
                table: "Orders",
                newName: "StoreEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AStoreEntityId",
                table: "Orders",
                newName: "IX_Orders_StoreEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreEntityId",
                table: "Orders",
                column: "StoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreEntityId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StoreEntityId",
                table: "Orders",
                newName: "AStoreEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StoreEntityId",
                table: "Orders",
                newName: "IX_Orders_AStoreEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_AStoreEntityId",
                table: "Orders",
                column: "AStoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
