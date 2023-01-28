using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CODEFIRST_FLUENT_API.Migrations
{
    public partial class myMigration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Category_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Category_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Color_Id = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Color_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Customer_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Customer_Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Middle_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Last_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Date_of_birth = table.Column<DateTime>(type: "date", nullable: true),
                    Phone_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Event_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Event_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Discount_Unit = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Discount_Rate = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))"),
                    Start_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Position_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Position_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Producer_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Producer_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Product_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Product_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Store_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Store_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ware_House",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ware_House_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Ware_House_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Create_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ware_House", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Save_Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Save_Product_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Save_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Save_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Save_Product_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Detail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Product_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date_Of_Manufacture = table.Column<DateTime>(type: "date", nullable: true),
                    Expiry = table.Column<DateTime>(type: "date", nullable: true),
                    Date_Of_entry = table.Column<DateTime>(type: "date", nullable: true),
                    Date_Of_inventory = table.Column<DateTime>(type: "date", nullable: true),
                    Quantity_in_stock = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Import_Price = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))"),
                    Price = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))"),
                    Month_Warranty = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Color_Color_Id",
                        column: x => x.Color_Id,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Producer_Producer_Id",
                        column: x => x.Producer_Id,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Detail_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Store_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Send_report_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Employee_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Employee_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Middle_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Last_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Date_Of_Birth = table.Column<DateTime>(type: "date", nullable: false),
                    Date_Of_Join = table.Column<DateTime>(type: "date", nullable: false),
                    Phone_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_Send_report_Id",
                        column: x => x.Send_report_Id,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Position_Position_Id",
                        column: x => x.Position_Id,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Store_Store_Id",
                        column: x => x.Store_Id,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Detail",
                columns: table => new
                {
                    Event_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_Detail_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Detail", x => new { x.Event_Id, x.Product_Detail_Id });
                    table.ForeignKey(
                        name: "FK_Event_Detail_Event_Event_Id",
                        column: x => x.Event_Id,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Detail_Product_Detail_Product_Detail_Id",
                        column: x => x.Product_Detail_Id,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Save_Product_Detail",
                columns: table => new
                {
                    Save_Product_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_Detail_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unit_Price = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))"),
                    Unit_price_when_reduced = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Save_Product_Detail", x => new { x.Save_Product_Id, x.Product_Detail_Id });
                    table.ForeignKey(
                        name: "FK_Save_Product_Detail_Product_Detail_Product_Detail_Id",
                        column: x => x.Product_Detail_Id,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Save_Product_Detail_Save_Product_Save_Product_Id",
                        column: x => x.Save_Product_Id,
                        principalTable: "Save_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ware_House_Detail",
                columns: table => new
                {
                    Ware_House_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_Detail_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity_entered = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Quantity_in_stock = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ware_House_Detail", x => new { x.Ware_House_Id, x.Product_Detail_Id });
                    table.ForeignKey(
                        name: "FK_Ware_House_Detail_Product_Detail_Product_Detail_Id",
                        column: x => x.Product_Detail_Id,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ware_House_Detail_Ware_House_Ware_House_Id",
                        column: x => x.Ware_House_Id,
                        principalTable: "Ware_House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Employee_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Invoice_Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Create_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Date_of_Payment = table.Column<DateTime>(type: "date", nullable: true),
                    Customer_Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Phone_Number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Money = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))"),
                    Amound_Paid = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))"),
                    Status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Employee_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warranty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Employee_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_Detail_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Start_Date = table.Column<DateTime>(type: "date", nullable: false),
                    End_Date = table.Column<DateTime>(type: "date", nullable: false),
                    License_Plate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId_NavigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId_NavigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warranty_Customer_CustomerId_NavigationId",
                        column: x => x.CustomerId_NavigationId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warranty_Employee_EmployeeId_NavigationId",
                        column: x => x.EmployeeId_NavigationId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warranty_Product_Detail_Product_Detail_Id",
                        column: x => x.Product_Detail_Id,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice_Detail",
                columns: table => new
                {
                    Invoice_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_Detail_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Price = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))"),
                    Unit_price_when_reduced = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "((0))"),
                    Total_Money = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCT", x => new { x.Invoice_Id, x.Product_Detail_Id });
                    table.ForeignKey(
                        name: "FK_Invoice_Detail_Invoice_Invoice_Id",
                        column: x => x.Invoice_Id,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_Detail_Product_Detail_Product_Detail_Id",
                        column: x => x.Product_Detail_Id,
                        principalTable: "Product_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Position_Id",
                table: "Employee",
                column: "Position_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Send_report_Id",
                table: "Employee",
                column: "Send_report_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Store_Id",
                table: "Employee",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Detail_Product_Detail_Id",
                table: "Event_Detail",
                column: "Product_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Customer_Id",
                table: "Invoice",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Employee_Id",
                table: "Invoice",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Detail_Product_Detail_Id",
                table: "Invoice_Detail",
                column: "Product_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_Category_Id",
                table: "Product_Detail",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_Color_Id",
                table: "Product_Detail",
                column: "Color_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_Producer_Id",
                table: "Product_Detail",
                column: "Producer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Detail_Product_Id",
                table: "Product_Detail",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Save_Product_Customer_Id",
                table: "Save_Product",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Save_Product_Detail_Product_Detail_Id",
                table: "Save_Product_Detail",
                column: "Product_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ware_House_Detail_Product_Detail_Id",
                table: "Ware_House_Detail",
                column: "Product_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warranty_CustomerId_NavigationId",
                table: "Warranty",
                column: "CustomerId_NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranty_EmployeeId_NavigationId",
                table: "Warranty",
                column: "EmployeeId_NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranty_Product_Detail_Id",
                table: "Warranty",
                column: "Product_Detail_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event_Detail");

            migrationBuilder.DropTable(
                name: "Invoice_Detail");

            migrationBuilder.DropTable(
                name: "Save_Product_Detail");

            migrationBuilder.DropTable(
                name: "Ware_House_Detail");

            migrationBuilder.DropTable(
                name: "Warranty");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Save_Product");

            migrationBuilder.DropTable(
                name: "Ware_House");

            migrationBuilder.DropTable(
                name: "Product_Detail");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
