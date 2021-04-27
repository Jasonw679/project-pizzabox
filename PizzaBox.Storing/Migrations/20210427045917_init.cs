using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrustEntityId = table.Column<long>(type: "bigint", nullable: true),
                    SizeEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crust_CrustEntityId",
                        column: x => x.CrustEntityId,
                        principalTable: "Crust",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Size_SizeEntityId",
                        column: x => x.SizeEntityId,
                        principalTable: "Size",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreEntityId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerEntityId",
                        column: x => x.CustomerEntityId,
                        principalTable: "Customers",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreEntityId",
                        column: x => x.StoreEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APizzaTopping",
                columns: table => new
                {
                    PizzasEntityId = table.Column<long>(type: "bigint", nullable: false),
                    ToppingsEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaTopping", x => new { x.PizzasEntityId, x.ToppingsEntityId });
                    table.ForeignKey(
                        name: "FK_APizzaTopping_Pizzas_PizzasEntityId",
                        column: x => x.PizzasEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaTopping_Topping_ToppingsEntityId",
                        column: x => x.ToppingsEntityId,
                        principalTable: "Topping",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "APizzaOrder",
                columns: table => new
                {
                    OrderEntityId = table.Column<long>(type: "bigint", nullable: false),
                    pizzasEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaOrder", x => new { x.OrderEntityId, x.pizzasEntityId });
                    table.ForeignKey(
                        name: "FK_APizzaOrder_Orders_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Orders",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaOrder_Pizzas_pizzasEntityId",
                        column: x => x.pizzasEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Discriminator", "Name" },
                values: new object[] { 1L, "JayPizza", "Jay Pizza" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Discriminator", "Name" },
                values: new object[] { 2L, "Pizzaria", "Pizzaria" });

            migrationBuilder.CreateIndex(
                name: "IX_APizzaOrder_pizzasEntityId",
                table: "APizzaOrder",
                column: "pizzasEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_APizzaTopping_ToppingsEntityId",
                table: "APizzaTopping",
                column: "ToppingsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEntityId",
                table: "Orders",
                column: "CustomerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreEntityId",
                table: "Orders",
                column: "StoreEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APizzaOrder");

            migrationBuilder.DropTable(
                name: "APizzaTopping");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
