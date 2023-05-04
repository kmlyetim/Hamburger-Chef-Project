using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerMenuProject.Migrations
{
    public partial class databaseyenii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WhoAdded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Menus_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Desserts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desserts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Desserts_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Desserts_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drinks_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Drinks_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Fries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fries_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Fries_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Hamburgers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamburgers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hamburgers_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Hamburgers_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sauces_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sauces_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Desserts",
                columns: new[] { "ID", "CreatedTime", "IsActive", "MenuID", "Name", "OrderID", "Photo", "Piece", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3267), true, null, "Souffle", null, "Souffle.png", 1, 14m },
                    { 2, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3269), true, null, "Chocolate Cookie", null, "ChocolateCookie.png", 1, 6m },
                    { 3, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3270), true, null, "İce-Cream", null, "İceCream.png", 1, 5m },
                    { 4, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3272), true, null, "Künefe", null, "Künefe.png", 1, 15m }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "ID", "CreatedTime", "IsActive", "MenuID", "Name", "OrderID", "Photo", "Piece", "Price", "Size" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3196), true, null, "Fuse Tea", null, "FuseTea.png", 1, 4m, 0 },
                    { 2, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3198), true, null, "Coca-Cola", null, "CocaCola.png", 1, 5m, 0 },
                    { 3, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3199), true, null, "Coca-Cola Zero", null, "CocaColaZero.png", 1, 5m, 0 },
                    { 4, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3201), true, null, "Fanta", null, "Fanta.png", 1, 5m, 0 },
                    { 5, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3203), true, null, "Sprite", null, "Sprite.png", 1, 6m, 0 },
                    { 6, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3204), true, null, "Strawberry Milkshake", null, "StrawberryMilkshake.png", 1, 11m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Fries",
                columns: new[] { "ID", "CreatedTime", "IsActive", "MenuID", "Name", "OrderID", "Photo", "Piece", "Price", "Size" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3250), true, null, "Fried Potatoes", null, "Potatoes.png", 1, 10m, 0 },
                    { 2, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3251), true, null, "Nuggets", null, "Nuggets.png", 1, 8m, 0 },
                    { 3, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3252), true, null, "Onion Rings", null, "OnionRings.png", 1, 9m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Hamburgers",
                columns: new[] { "ID", "CreatedTime", "IsActive", "MenuID", "Name", "OrderID", "Photo", "Piece", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3068), true, null, "Whopper", null, "Whopper.png", 1, 32m },
                    { 2, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3074), true, null, "Double Whopper", null, "DoubleWhopper.png", 1, 45m },
                    { 3, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3076), true, null, "Texas Smokehouse", null, "TexasSmokeHouse.png", 1, 37m },
                    { 4, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3077), true, null, "Cheese Burger", null, "Cheeseburger.png", 1, 29m },
                    { 5, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3078), true, null, "Chicken Royale", null, "ChickenRoyale.png", 1, 34m },
                    { 6, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3080), true, null, "Steakhouse", null, "SteakHouse.png", 1, 41m }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "ID", "CreatedTime", "IsActive", "Name", "OrderID", "Photo", "Piece", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3229), true, "Whopper Menu", null, "WhopperMenu.png", 1, 50m },
                    { 2, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3231), true, "CheeseBurger Menu", null, "CheeseBurgerMenu.png", 1, 47m },
                    { 3, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3233), true, "Steakhouse Burger Menu", null, "SteakHouseMenu.png", 1, 62m }
                });

            migrationBuilder.InsertData(
                table: "Sauces",
                columns: new[] { "ID", "CreatedTime", "IsActive", "MenuID", "Name", "OrderID", "Photo", "Piece", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3285), true, null, "Mayonnaise", null, "Mayonnaise.png", 1, 1m },
                    { 2, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3287), true, null, "Ketchup", null, "Ketchup.png", 1, 1m },
                    { 3, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3288), true, null, "Ranch Sauce", null, "RanchSauce.png", 1, 2m },
                    { 4, new DateTime(2023, 5, 3, 3, 47, 59, 624, DateTimeKind.Local).AddTicks(3289), true, null, "Mustard Sauce", null, "MustardSauce.png", 1, 2m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Desserts_MenuID",
                table: "Desserts",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Desserts_OrderID",
                table: "Desserts",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_MenuID",
                table: "Drinks",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_OrderID",
                table: "Drinks",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Fries_MenuID",
                table: "Fries",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Fries_OrderID",
                table: "Fries",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Hamburgers_MenuID",
                table: "Hamburgers",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Hamburgers_OrderID",
                table: "Hamburgers",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_OrderID",
                table: "Menus",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sauces_MenuID",
                table: "Sauces",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Sauces_OrderID",
                table: "Sauces",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Desserts");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Fries");

            migrationBuilder.DropTable(
                name: "Hamburgers");

            migrationBuilder.DropTable(
                name: "Sauces");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
