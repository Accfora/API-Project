using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MyMigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoty_id = table.Column<int>(type: "int", nullable: false),
                    categoty_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    parent_category = table.Column<int>(type: "int", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kategori__EB93B733B73DB27B", x => x.categoty_id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories",
                        column: x => x.parent_category,
                        principalTable: "Categories",
                        principalColumn: "categoty_id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    surname = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    patronymic = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    city = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    telephone_number = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    login = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    manufacturer_id = table.Column<int>(type: "int", nullable: false),
                    manufacturer_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    manufacturer_country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.manufacturer_id);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    filter_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.filter_id);
                    table.ForeignKey(
                        name: "FK_Filters_Categories",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "categoty_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "date", nullable: false),
                    paid = table.Column<bool>(type: "bit", nullable: false),
                    delivery_type = table.Column<int>(type: "int", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Zakazy__4D78AF94D1A3AFA6", x => new { x.order_id, x.customer_id });
                    table.ForeignKey(
                        name: "FK__Zakazy__id_pokup__30F848ED",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    good_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    categoty_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    manufacturer_id = table.Column<int>(type: "int", nullable: false),
                    amount_on_stock = table.Column<int>(type: "int", nullable: false),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.good_id);
                    table.ForeignKey(
                        name: "FK__Tovary__id_kateg__3F466844",
                        column: x => x.categoty_id,
                        principalTable: "Categories",
                        principalColumn: "categoty_id");
                    table.ForeignKey(
                        name: "FK__Tovary__id_proiz__403A8C7D",
                        column: x => x.manufacturer_id,
                        principalTable: "Manufacturers",
                        principalColumn: "manufacturer_id");
                });

            migrationBuilder.CreateTable(
                name: "GoodFilterValue",
                columns: table => new
                {
                    good_id = table.Column<int>(type: "int", nullable: false),
                    filter_id = table.Column<int>(type: "int", nullable: false),
                    filter_value = table.Column<object>(type: "sql_variant", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodFilterValue", x => new { x.good_id, x.filter_id });
                    table.ForeignKey(
                        name: "FK_GoodFilterValue_Filters",
                        column: x => x.filter_id,
                        principalTable: "Filters",
                        principalColumn: "filter_id");
                    table.ForeignKey(
                        name: "FK_GoodFilterValue_Goods",
                        column: x => x.good_id,
                        principalTable: "Goods",
                        principalColumn: "good_id");
                });

            migrationBuilder.CreateTable(
                name: "Order_content",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    good_id = table.Column<int>(type: "int", nullable: false),
                    number_of_positions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Soderzhi__810D8EBF7A7B6560", x => new { x.order_id, x.customer_id, x.good_id });
                    table.ForeignKey(
                        name: "FK__Soderzhim__id_to__31EC6D26",
                        column: x => x.good_id,
                        principalTable: "Goods",
                        principalColumn: "good_id");
                    table.ForeignKey(
                        name: "FK__Soderzhimoe_zaka__32E0915F",
                        columns: x => new { x.order_id, x.customer_id },
                        principalTable: "Orders",
                        principalColumns: new[] { "order_id", "customer_id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_parent_category",
                table: "Categories",
                column: "parent_category");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_category_id",
                table: "Filters",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_GoodFilterValue_filter_id",
                table: "GoodFilterValue",
                column: "filter_id");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_categoty_id",
                table: "Goods",
                column: "categoty_id");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_manufacturer_id",
                table: "Goods",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_content_good_id",
                table: "Order_content",
                column: "good_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customer_id",
                table: "Orders",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodFilterValue");

            migrationBuilder.DropTable(
                name: "Order_content");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
