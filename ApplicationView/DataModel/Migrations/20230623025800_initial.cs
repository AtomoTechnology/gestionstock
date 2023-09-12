using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationView.DataModel.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Cuit_Cuil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingBusiness",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsTryOn = table.Column<bool>(type: "bit", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingBusiness_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubModules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Confirm = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OptionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ModuleAction = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncreasePriceAfterTwelves",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HourFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HourTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Porcent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncreasePriceAfterTwelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncreasePriceAfterTwelves_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleAccounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleAccounts_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Cuit_Cuil = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TurnName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateFrom = table.Column<int>(type: "int", nullable: false),
                    DateTo = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turns_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turns_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubModuleAccounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubModuleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModuleAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubModuleAccounts_ModuleAccounts_ModuleAccountId",
                        column: x => x.ModuleAccountId,
                        principalTable: "ModuleAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubModuleAccounts_SubModules_SubModuleId",
                        column: x => x.SubModuleId,
                        principalTable: "SubModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceCode = table.Column<long>(type: "bigint", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    finalizeSale = table.Column<bool>(type: "bit", nullable: false),
                    SaleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeLotePayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenWorkTurns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TurnId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenWorkTurns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenWorkTurns_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenWorkTurns_Turns_TurnId",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Legit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SaleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legit_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Legit_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryPrices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PriceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePurchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    typeUpdate = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryPrices_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LotCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    productId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SaleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleDetails_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "Address", "BusinessName", "CreatedDate", "Cuit_Cuil", "FinalDate", "ModifiedDate", "Phone", "state" },
                values: new object[] { "de07358c-3a51-42fb-8690-c383b91b5844", "Argentina", "Almacen", new DateTime(2023, 6, 22, 23, 58, 0, 0, DateTimeKind.Local).AddTicks(3078), "30-45785215-9", null, null, "3419875425", 1 });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "ActionName", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "Name", "state" },
                values: new object[,]
                {
                    { "5017aded-60ac-45cc-89b1-993703cd91ab", "btnUser", new DateTime(2023, 6, 22, 23, 58, 0, 5, DateTimeKind.Local).AddTicks(2731), "Dar permiso", null, null, "Gestion de Usuarios", 1 },
                    { "8178794d-5f0c-4255-b234-8f0f683e74dd", "btnProduct", new DateTime(2023, 6, 22, 23, 58, 0, 5, DateTimeKind.Local).AddTicks(2717), "Dar permiso", null, null, "Productos", 1 },
                    { "a9315906-f7bf-49eb-808e-d24cb39a04ba", "btnprovider", new DateTime(2023, 6, 22, 23, 58, 0, 5, DateTimeKind.Local).AddTicks(2722), "Dar permiso", null, null, "Proveedores", 1 },
                    { "dc09b3c4-58ff-4483-91b7-89ed479e6d1a", "btnSale", new DateTime(2023, 6, 22, 23, 58, 0, 5, DateTimeKind.Local).AddTicks(2704), "Encarga la seguridad de las ventas, permisos, etc", null, null, "Ventas", 1 },
                    { "e64ac6a7-bf12-4d14-815f-e52cb8252878", "btnReport", new DateTime(2023, 6, 22, 23, 58, 0, 5, DateTimeKind.Local).AddTicks(2727), "Dar permiso", null, null, "Reportes", 1 },
                    { "efa9e573-4308-4d88-99cf-d2c51c85cd54", "btnSecurity", new DateTime(2023, 6, 22, 23, 58, 0, 5, DateTimeKind.Local).AddTicks(2740), "Dar permiso", null, null, "Seguridades", 1 },
                    { "f01ea86d-5d66-493d-9df2-4fe211bc8509", "btnMovements", new DateTime(2023, 6, 22, 23, 58, 0, 5, DateTimeKind.Local).AddTicks(2735), "Dar permiso", null, null, "Movimientos", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "RoleName", "state" },
                values: new object[,]
                {
                    { "0ac46b16-ef03-452c-9586-ba4251496b3f", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(932), "Solo puede hacer control de stock", null, null, "Almacenero(a)", 1 },
                    { "66e3d763-3f6c-49f1-ad72-3b64051c4879", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(928), "Tiene acceso para realizar ventas, con limite", null, null, "Empleado(a)", 1 },
                    { "82a0bec6-8266-443a-84a2-af85ad69348b", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(917), "Tiene acceso en todo", null, null, "Admin", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubModules",
                columns: new[] { "Id", "ActionName", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "ModuleId", "Name", "state" },
                values: new object[,]
                {
                    { "0081ef4d-6b18-4e83-a443-b3b85abc6c47", "btndetailfiar", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5870), "Detalle Fiar", null, null, "dc09b3c4-58ff-4483-91b7-89ed479e6d1a", "Detalle Fiar", 1 },
                    { "023b4db0-a094-4fd8-b215-0f1941a5223f", "button26", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5966), "ABM categoria", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "ABM categoria", 1 },
                    { "08968b7c-3fc1-4bcc-9ff2-41336219ec69", "btnmouvment", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5928), "ABM movimiento", null, null, "f01ea86d-5d66-493d-9df2-4fe211bc8509", "ABM movimiento", 1 },
                    { "0f44982b-bc5c-4ff8-a4cd-fc518baa3457", "button30", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5970), "Turno cerrado", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "Turno cerrado", 1 },
                    { "1774917c-fb76-492f-9adc-846886d9ed0e", "btnproductreport", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5910), "Productos", null, null, "e64ac6a7-bf12-4d14-815f-e52cb8252878", "Productos", 1 },
                    { "25a434b6-674f-47de-95ba-904c6b867318", "button25", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5944), "Gestionar turno", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "Gestionar turno", 1 },
                    { "27d6db63-5a85-438d-98f7-63c744059223", "btnmodifyrol", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5974), "Modificar", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "Modificar rol", 1 },
                    { "34c3d045-9e99-470c-822b-aa8caa9cdfe2", "btncreateoffer", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5888), "Crear Oferta", null, null, "8178794d-5f0c-4255-b234-8f0f683e74dd", "Crear Oferta", 1 },
                    { "371d3ef5-916f-4c5a-9bdb-4208febf7813", "btnconsultantprize", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5866), "Consultar venta", null, null, "dc09b3c4-58ff-4483-91b7-89ed479e6d1a", "Consultar venta", 1 },
                    { "44f91259-af42-431f-be8e-bea98a9bf6eb", "button9", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5948), "Incremento nocturno", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "Incremento nocturno", 1 },
                    { "4a6f84a3-779c-4d2e-841a-88546fcdc0f1", "btnconsultantdateexpired", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5879), "Consultar Vencimiento", null, null, "8178794d-5f0c-4255-b234-8f0f683e74dd", "Consultar Vencimiento", 1 },
                    { "56672d96-1e2e-409e-b01f-f47d978fd286", "btntypemouvment", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5932), "ABM tipo movimiento", null, null, "f01ea86d-5d66-493d-9df2-4fe211bc8509", "ABM tipo movimiento", 1 },
                    { "7d3afe88-1c0a-48f8-a9ca-90b9e76783ea", "button22", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5940), "ABM forma de pago", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "ABM forma de pago", 1 },
                    { "83824e9f-6d83-462b-b2a4-592502af5d60", "button28", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5957), "Abrir turno", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "Abrir turno", 1 },
                    { "9a3f1169-10b8-4d41-89ad-a6c24e917b52", "btnproveedorreport", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5914), "Proveedores", null, null, "e64ac6a7-bf12-4d14-815f-e52cb8252878", "Proveedores", 1 },
                    { "a0379995-cae9-47c6-95d0-4109dd6437e8", "btnupdateatock", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5892), "Actualizar stock", null, null, "8178794d-5f0c-4255-b234-8f0f683e74dd", "Actualizar stock", 1 },
                    { "a89f3ce0-000f-4525-8be6-48d417718f4c", "btnambproveedor", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5897), "ABM Proveedor", null, null, "a9315906-f7bf-49eb-808e-d24cb39a04ba", "ABM Proveedor", 1 },
                    { "ad3aa3aa-0f57-4f6e-9d20-72a247a9abe7", "btnchangepassword", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5923), "Cambiar contraseña", null, null, "5017aded-60ac-45cc-89b1-993703cd91ab", "Cambiar contraseña", 1 },
                    { "b269ec21-d373-4698-8acc-f6c47d501987", "btnconsultantproducto", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5901), "Consultar producto", null, null, "a9315906-f7bf-49eb-808e-d24cb39a04ba", "Consultar producto", 1 },
                    { "b6960d25-b1d3-4a16-88b9-56ad9d8bd212", "btnconsultantsale", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5861), "Consultar precio", null, null, "dc09b3c4-58ff-4483-91b7-89ed479e6d1a", "Consultar precio", 1 },
                    { "c6139ff7-4b03-450c-8abc-457620c4714a", "button27", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5952), "Actualizar precio", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "Actualizar precio", 1 },
                    { "cb364518-b564-4336-98d4-349c67f35531", "button29", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5961), "Cerrar turno", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "Cerrar turno", 1 },
                    { "d4e2445b-c66a-4b70-9f4d-6c1cbbfdca40", "btndetailproduct", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5884), "Detalle Producto", null, null, "8178794d-5f0c-4255-b234-8f0f683e74dd", "Detalle Producto", 1 },
                    { "d8ca7cbe-0ace-4d44-b74f-e0bac19c7770", "btnabmgestionuser", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5919), "ABM Usuario", null, null, "5017aded-60ac-45cc-89b1-993703cd91ab", "ABM Usuario", 1 },
                    { "db88181b-478e-4523-8f75-3ca66afba611", "btnsalereport", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5905), "Ventas", null, null, "e64ac6a7-bf12-4d14-815f-e52cb8252878", "Ventas", 1 },
                    { "dbb0673c-3589-4e98-a42a-103cb44697d9", "btnabmproduct", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5874), "ABM Producto", null, null, "8178794d-5f0c-4255-b234-8f0f683e74dd", "ABM Producto", 1 },
                    { "ee090c50-f4a4-4877-8df7-0a05abeaf1c8", "btnstartsale", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5850), "Iniciar venta", null, null, "dc09b3c4-58ff-4483-91b7-89ed479e6d1a", "Iniciar venta", 1 },
                    { "fc374362-3c46-4600-b533-7854526353ec", "button23", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(5936), "ABM rol", null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", "ABM rol", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BusinessId", "CreatedDate", "Email", "FinalDate", "FirstName", "LastName", "ModifiedDate", "Phone", "state" },
                values: new object[] { "362c2637-2ad9-449a-9498-dbd74be87ee8", "Argentina", "de07358c-3a51-42fb-8690-c383b91b5844", new DateTime(2023, 6, 22, 23, 58, 0, 1, DateTimeKind.Local).AddTicks(5899), "almacen@gmail.com", null, "Pepito", "Juancito", null, "3416987542", 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Confirm", "CreatedDate", "FinalDate", "ModifiedDate", "RoleId", "UserId", "UserName", "UserPass", "state" },
                values: new object[] { "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", true, new DateTime(2023, 6, 22, 23, 57, 59, 995, DateTimeKind.Local).AddTicks(7362), null, null, "82a0bec6-8266-443a-84a2-af85ad69348b", "362c2637-2ad9-449a-9498-dbd74be87ee8", "admin", "JNtSCr8uEE4irR5lFH4OUA==", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AccountId", "CategoryName", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "state" },
                values: new object[,]
                {
                    { "07dd4e15-386e-44c7-8f63-801c1dddeb1a", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "AUTOMEDICACIÓN", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1130), "La automedicación es la utilización de medicamentos por iniciativa propia sin ninguna intervención por parte del médico (ni en el diagnóstico de la enfermedad, ni en la prescripción o supervisión del tratamiento)", null, null, 1 },
                    { "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "BEBIDAS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1122), "Bebida es cualquier líquido que se ingiere. La bebida más consumida es el agua. Otros ejemplos son las bebidas alcohólicas, bebidas gaseosas, infusiones o zumos. En Chile se le llama bebida exclusivamente a las gaseosas.", null, null, 1 },
                    { "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "ALIMENTOS PREPARADOS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1126), "Alimento listo para el consumo: alimento que está en forma comestible, sin necesidad de lavado, cocimiento, o preparación adicional por parte del establecimiento de comida o consumidor, y se espera que sea consumido en esa forma.", null, null, 1 },
                    { "21fcbb68-3e40-4550-b142-a302fc264a47", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "USO DOMÉSTICO", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1139), "USO DOMÉSTICO.", null, null, 1 },
                    { "27d5e91e-1229-49cd-964b-cc812a81faeb", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "JARCERÍA / PRODUCTOS DE LIMPIEZA", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1148), "Jarciería es el término que se refiere a toda aquella mercadería que se denomina comúnmente instrumentos de limpieza. Existe gran variedad de jarciería a la venta ya sea en la típica tienda de autoservicio o bien en compañías especializadas.", null, null, 1 },
                    { "4444da14-84ac-48de-a7da-a4f4ddd28858", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "ABARROTES", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1077), "Este tipo de recinto comercial ofrece alimentos envasados o de venta al peso, desde panes hasta productos lácteos pasando por conservas. Los abarrotes, en algunos países sudamericanos, se denominan almacenes.", null, null, 1 },
                    { "4af6f8b7-b1a5-4375-8319-079e3d8487fe", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "LÁCTEOS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1098), "El grupo de los lácteos (también productos lácteos, lácticos o derivados lácteos) incluye alimentos como la leche y sus derivados procesados. Las plantas industriales que producen estos alimentos pertenecen a la industria láctea y se caracterizan por la manipulación de un producto altamente perecedero, como la leche, que debe vigilarse y analizarse correctamente durante todos los pasos de la cadena de frío hasta su llegada al consumidor.", null, null, 1 },
                    { "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "PRODUCTOS ENLATADOS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1089), "Un alimento enlatado, es por ende, un alimento fresco, incorporado en un recipiente metálico, herméticamente cerrado el cual se somete a un proceso de calentamiento a temperaturas superiores a los 100 °C, para conservarlo, lo más parecido posible, a su estado en forma natural hasta el momento de consumirlo.", null, null, 1 },
                    { "9cb3d8c8-226e-4f1a-b04d-258db3329c75", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "OTROS PRODUCTOS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1153), "Que no tiene una categoria especifico", null, null, 1 },
                    { "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "HIGIENE PERSONAL", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1134), "La higiene personal es el concepto básico del aseo, de la limpieza y del cuidado del cuerpo humano.", null, null, 1 },
                    { "b296430c-42de-41f8-8fc2-3f7fadb44218", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "FRUTAS Y VERDURAS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1117), "Las frutas y verduras se consideran partes comestibles de las plantas (por ejemplo, estructuras portadoras de semillas, flores, brotes, hojas, tallos, brotes y raíces), ya sean cultivadas o cosechadas en forma silvestre, en estado crudo o en forma mínimamente elaborada.", null, null, 1 },
                    { "c0f96f74-96cf-438a-b89f-0888182b3e75", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "HARINAS Y PAN", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1113), "Se encuentra todo sobre perfumeria", null, null, 1 },
                    { "db2ca371-5ba5-49d9-81cf-f04f49a61b0e", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "HELADOS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1144), "En su forma más simple, el helado o crema helada es un alimento congelado que por lo general se hace de productos lácteos tales como leche o crema.", null, null, 1 },
                    { "e7c4059e-04a1-4f4a-b5c9-b86da231147f", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "BOTANAS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1103), "Es un tipo de aperitivo, ese plato que da inicio a una comida y se comparte entre los comensales. Algunas de las botanas más tradicionales generalmente están hechas con una masa de maíz que termina siendo tortillas, totopos, tostadas… y normalmente se acompañan con diferentes salsas.", null, null, 1 },
                    { "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "BEBIDAS ALCOHÓLICAS", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1094), "Las bebidas alcohólicas son aquellas bebidas que contienen etanol en su composición. Las bebidas alcohólicas desempeñan un papel social importante en muchas culturas del mundo, debido a su efecto de droga recreativa depresora.", null, null, 1 },
                    { "f350cdda-f912-4fd3-85c9-f99863ab6c2e", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "CONFITERÍA/DULCERIA", new DateTime(2023, 6, 22, 23, 58, 0, 3, DateTimeKind.Local).AddTicks(1108), "El término repostería es el que se utiliza para denominar al tipo de gastronomía que se basa en la preparación, y decoración de platos dulces tales como pies, tartas, pasteles, galletas, budines, etc.", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ModuleAccounts",
                columns: new[] { "Id", "AccountId", "CreatedDate", "FinalDate", "ModifiedDate", "ModuleId", "state" },
                values: new object[,]
                {
                    { "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(983), null, null, "8178794d-5f0c-4255-b234-8f0f683e74dd", 1 },
                    { "7151993b-b219-4e22-80f2-0ec8002e4b3f", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(972), null, null, "dc09b3c4-58ff-4483-91b7-89ed479e6d1a", 1 },
                    { "826e202c-ef1a-4be0-95eb-7eab6388f878", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(999), null, null, "f01ea86d-5d66-493d-9df2-4fe211bc8509", 1 },
                    { "a2585d96-d782-45c2-b8be-1edbfaaa160e", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(991), null, null, "e64ac6a7-bf12-4d14-815f-e52cb8252878", 1 },
                    { "b871ccf3-2421-4861-b7a0-3ed6b070a3c3", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(987), null, null, "a9315906-f7bf-49eb-808e-d24cb39a04ba", 1 },
                    { "e30a699e-51c2-4f06-b1bc-7c076824db44", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(1003), null, null, "efa9e573-4308-4d88-99cf-d2c51c85cd54", 1 },
                    { "ff020261-95e7-4695-90a0-a16f380aa2f7", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 6, DateTimeKind.Local).AddTicks(995), null, null, "5017aded-60ac-45cc-89b1-993703cd91ab", 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "AccountId", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "PaymentName", "state" },
                values: new object[,]
                {
                    { "1535f60d-2db1-4c65-90bc-c1ded55b07aa", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(5984), "Mercado pago", null, null, "Mercado pago", 1 },
                    { "3700a7b3-0e1b-49e2-87ce-490d06d2512c", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(5975), "Tarjeta de credito", null, null, "Tarjeta de credito", 1 },
                    { "4c1ffed9-2f0c-4294-8b82-d236da387b39", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(5969), "Tarjeta de debito", null, null, "Tarjeta de debito", 1 },
                    { "50e82295-a08f-42fa-aae0-26813bc261db", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(5979), "Cheques", null, null, "Cheques", 1 },
                    { "876d4600-b062-4e84-937d-8a79f88c1e47", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(5989), "Transferencia bancaria", null, null, "Transferencia bancaria", 1 },
                    { "b9d03d21-52ed-486f-8b60-bd871505e6b5", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(6002), "Fiar", null, null, "Fiar", 1 },
                    { "c3eb2f61-7bd0-47ed-8a16-98e1b7d24b44", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(5993), "Especie", null, null, "Especie", 1 },
                    { "da40a532-f06a-4fff-8f66-a7563fef8941", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(5998), "Cuenta Corriente", null, null, "Cuenta Corriente", 1 },
                    { "db3de6dc-b1f3-44f1-bb24-648e6eb9e65a", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(6007), "Billetera Santa Fe", null, null, "Billetera Santa Fe", 1 },
                    { "f5f737fd-860c-485b-972a-927d385f4ab5", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", new DateTime(2023, 6, 22, 23, 58, 0, 2, DateTimeKind.Local).AddTicks(5956), "Efectivo", null, null, "Efectivo", 1 }
                });

            migrationBuilder.InsertData(
                table: "Turns",
                columns: new[] { "Id", "AccountId", "BusinessId", "CreatedDate", "DateFrom", "DateTo", "Description", "FinalDate", "ModifiedDate", "TurnName", "state" },
                values: new object[,]
                {
                    { "7a57db1f-3f77-4a25-8107-b73e668ab65a", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "de07358c-3a51-42fb-8690-c383b91b5844", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(5470), 14, 22, "Se encarga de iniciar el dia", null, null, "Tarde", 1 },
                    { "c0ba7b4c-d292-48c7-9f78-8a2e83973053", "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca", "de07358c-3a51-42fb-8690-c383b91b5844", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(5456), 8, 14, "Se encarga de iniciar el dia", null, null, "Mañana", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "SubCategoryName", "state" },
                values: new object[,]
                {
                    { "005dc5af-61c1-4b54-9266-03407ca75d10", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(240), "Te", null, null, "Te", 1 },
                    { "07735a2d-1e10-404d-8ae4-28c05bab0e6b", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(276), "Frijoles enlatados", null, null, "Frijoles enlatados", 1 },
                    { "08bf4c2a-55b9-4449-ba44-7a18e61157fa", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(832), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "09e77b14-a1c5-4094-8ae2-5af32ab26d5d", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(661), "Isotónicos", null, null, "Isotónicos", 1 },
                    { "0be5b0f7-62f6-4411-b540-82b51abc865a", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(484), "Caramelos", null, null, "Caramelos", 1 },
                    { "0c64e944-3a0b-49f4-a323-6edccc48ba35", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(407), "Leche light", null, null, "Leche light", 1 },
                    { "0c64f205-d9ca-4a4b-90ec-eac98fbf523c", "db2ca371-5ba5-49d9-81cf-f04f49a61b0e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(952), "Paletas/ Helados", null, null, "Paletas/ Helados", 1 },
                    { "0c71411a-1acc-44ce-b5ba-c2bb01fac508", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(518), "Pulpa de tamarindo", null, null, "Pulpa de tamarindo", 1 },
                    { "0d2d3a77-64c7-4fb3-aee0-366d262d3ce3", "07dd4e15-386e-44c7-8f63-801c1dddeb1a", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(755), "Antiácidos", null, null, "Antiácidos", 1 },
                    { "0d54b411-6a42-49b1-8a8a-ee2ac22aa1be", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1014), "Jergas/Franelas", null, null, "Jergas/Franelas", 1 },
                    { "0dee8e1a-a3a8-411a-864a-542bf690fb34", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(906), "Limpiadores líquidos", null, null, "Limpiadores líquidos", 1 },
                    { "0e59c12d-d29f-4667-a3af-c1060d16ae94", "e7c4059e-04a1-4f4a-b5c9-b86da231147f", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(480), "Nueces y semillas", null, null, "Nueces y semillas", 1 },
                    { "10db0819-5466-420d-acca-5ecaa864ec0a", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(785), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "1174d492-edd1-4f9c-b7cf-ce8a6f68abc3", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(673), "Sopas en vaso", null, null, "Sopas en vaso", 1 },
                    { "11ae28fa-b2e2-44fb-8d65-aba73b937ead", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(943), "Fibras limpiadoras", null, null, "Fibras limpiadoras", 1 },
                    { "13722a31-d37e-4c44-9226-fef2dd6ab09e", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(272), "Chícharos enlatados", null, null, "Chícharos enlatados", 1 },
                    { "14348004-c92e-45b9-8cd4-c82060d3f291", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(699), "Manteca", null, null, "Manteca", 1 },
                    { "1579c57f-cf33-4645-bfcc-4d09f92a70a3", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(222), "Catsup", null, null, "Catsup", 1 },
                    { "19634b95-60be-45ec-8ca8-e508e273af05", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1006), "Focos", null, null, "Focos", 1 },
                    { "198c65d6-cb58-4d3f-be56-f1bc93fc0277", "07dd4e15-386e-44c7-8f63-801c1dddeb1a", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(751), "Antigripales", null, null, "Antigripales", 1 },
                    { "19fe7044-5f20-4720-9bf3-9214b1d9fbef", "07dd4e15-386e-44c7-8f63-801c1dddeb1a", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(716), "Agua oxigenada", null, null, "Agua oxigenada", 1 },
                    { "1a27fb1d-7b20-41a2-9c53-43e5afa27698", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(345), "Mezcal", null, null, "Mezcal", 1 },
                    { "1a3985b7-65b2-4fc3-bf00-7d5764bd59f2", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(231), "Mermelada", null, null, "Mermelada", 1 },
                    { "1bc53107-6800-4b35-b4f3-c3363fb89a19", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(298), "Chiles envasados", null, null, "Chiles envasados", 1 },
                    { "1d5721d3-a787-4b8d-9d6f-ffb5d5262b21", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(399), "Leche en polvo", null, null, "Leche deslactosada", 1 },
                    { "1faacaec-d09a-4fb5-ab7f-3ca55c754ccd", "c0f96f74-96cf-438a-b89f-0888182b3e75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(553), "Pan dulce", null, null, "Pan dulce", 1 },
                    { "208b7941-a0a1-47bb-8b6c-5108c0f4cc2b", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(236), "Miel", null, null, "Miel", 1 },
                    { "20db2648-207a-474b-a97d-d53451152de3", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(600), "Manzanas", null, null, "Manzanas", 1 },
                    { "2267271b-d123-4f63-8e8e-c1719a4ad20d", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(922), "Detergente para ropa", null, null, "Detergente para ropa", 1 },
                    { "247700b0-7887-45b1-b670-4e97c0b90b44", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(350), "Jerez", null, null, "Jerez", 1 },
                    { "24a39fa6-79d3-47c7-9e55-180bf92c2d89", "9cb3d8c8-226e-4f1a-b04d-258db3329c75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1038), "Recargas móviles", null, null, "Recargas móviles", 1 },
                    { "24a73edb-d737-42fa-a380-b2fdddd9ef44", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(227), "Mayonesa", null, null, "Mayonesa", 1 },
                    { "25202d3f-46e2-4706-aa39-f1100063aeca", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(315), "Vegetales en conserva", null, null, "Vegetales en conserva", 1 },
                    { "25bb2d73-56d5-4479-bce5-a63aa1ca63d6", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(652), "Bebidas isotónicas", null, null, "Bebidas isotónicas", 1 },
                    { "2cd8ebea-b8e5-408e-b098-4a6f635bc6bd", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(302), "Ensaladas enlatadas", null, null, "Ensaladas enlatadas", 1 },
                    { "30c5ec35-19f7-4d52-aaa1-cfcf21987603", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(319), "Bebidas preparadas", null, null, "Bebidas preparadas", 1 },
                    { "35532f1d-0adf-460a-ad91-63e270f7a4db", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(435), "Mantequilla", null, null, "Mantequilla", 1 },
                    { "3861c055-4277-4c56-8114-5f2c1b898f5c", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(444), "Media crema", null, null, "Media crema", 1 },
                    { "3b2730ed-eee3-4d6a-b7e2-46934dd2cd25", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(989), "Extensiones/Multicontacto", null, null, "Extensiones/Multicontacto", 1 },
                    { "3ba56596-8256-46a0-85b1-fcedb255c8a2", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(997), "Popotes", null, null, "Popotes", 1 },
                    { "3e237426-d168-4f88-bdd5-44236546870a", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(421), "Leche semidescremada", null, null, "Leche semidescremada", 1 },
                    { "410e6eda-1fb4-4ced-84d2-3542b87ada40", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(439), "Margarina", null, null, "Margarina", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "SubCategoryName", "state" },
                values: new object[,]
                {
                    { "41e9e143-03db-4b0f-a51b-6b9160d357fc", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(262), "Champiñones enteros/rebanados", null, null, "Champiñones enteros/rebanados", 1 },
                    { "422edf4a-d9e6-40f4-9cc1-9b0dcd0756ac", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(960), "Cepillo de plástico", null, null, "Cepillo de plástico", 1 },
                    { "42496afc-b727-48cb-ae26-eb20c859bba7", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(285), "Sardinas", null, null, "Sardinas", 1 },
                    { "4636fd58-00ad-4f6c-ab97-6a91a2a6e210", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(993), "Recogedor de metal/plástico", null, null, "Recogedor de metal/plástico", 1 },
                    { "46c73d3e-d21b-4914-87a9-ebac432901e7", "e7c4059e-04a1-4f4a-b5c9-b86da231147f", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(463), "Frituras de maíz", null, null, "Frituras de maíz", 1 },
                    { "4b799d8f-ee08-4e8e-930e-ab8403392c4b", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(566), "Aguacates", null, null, "Aguacates", 1 },
                    { "4ba4eaad-c72c-4bf4-8715-2d1d58f1901b", "c0f96f74-96cf-438a-b89f-0888182b3e75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(536), "Galletas dulces", null, null, "Galletas dulces", 1 },
                    { "4c1f4d08-7a4b-43d3-beca-4959700e41bc", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(918), "Detergentes para trastes", null, null, "Detergentes para trastes", 1 },
                    { "4d85744f-add3-4f9e-88c8-2c34ab4f815a", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(790), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "51858237-ae9b-4731-88c2-f19a2d344c3c", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(172), "Crema para café", null, null, "Crema para café", 1 },
                    { "524bbae4-38ca-4f9b-9603-aebcd65ecf84", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(249), "Huevo", null, null, "Huevo", 1 },
                    { "52cd0e99-22b0-4e17-ba9f-ad448b3b8766", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(501), "Chocolates", null, null, "Chocolates", 1 },
                    { "530edb0d-938c-4ae4-869a-567bf6bb529c", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(630), "Jugos/Néctares", null, null, "Jugos/Néctares", 1 },
                    { "55136ca5-1c33-4e44-9e4d-34a06c6086f8", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(337), "Ginebra.", null, null, "Ginebra", 1 },
                    { "5656e6aa-f9cb-4add-99cb-a9f2696480a0", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(596), "Limones", null, null, "Limones", 1 },
                    { "591bac37-162a-4314-b0ae-46e9db02f691", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1022), "Pegamento", null, null, "Pegamento", 1 },
                    { "5c19e99c-2b96-49cc-a968-7e5d270b1201", "e7c4059e-04a1-4f4a-b5c9-b86da231147f", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(467), "Cacahuates", null, null, "Cacahuates", 1 },
                    { "5df74c33-8b66-4999-a511-6aecc01faa33", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(604), "Naranjas", null, null, "Naranjas", 1 },
                    { "60366d57-cfe4-473a-a473-6e58fce5c928", "9cb3d8c8-226e-4f1a-b04d-258db3329c75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1034), "Tarjetas telefónicas", null, null, "Tarjetas telefónicas", 1 },
                    { "62433dfd-835e-4651-99f5-78ea6eefec3f", "9cb3d8c8-226e-4f1a-b04d-258db3329c75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1042), "Cigarros", null, null, "Cigarros", 1 },
                    { "62664ce7-b8a0-4531-bfb9-932595f7d7a4", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(425), "Crema", null, null, "Crema", 1 },
                    { "6399abe6-056a-425c-a41e-371e7f135bce", "e7c4059e-04a1-4f4a-b5c9-b86da231147f", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(454), "Papas", null, null, "Papas", 1 },
                    { "63eaca83-cacf-4d84-9b29-2fa454a9c206", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(914), "Jabón de barra", null, null, "Jabón de barra", 1 },
                    { "63efd264-3e31-480b-b86c-27c500705826", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(591), "Papas", null, null, "Papas", 1 },
                    { "6557a6d3-5317-44c2-98fd-333064c87b13", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(682), "Salchicha", null, null, "Salchicha", 1 },
                    { "65749701-c848-42a3-8549-b90938b0a98f", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(836), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "65ade45e-c4b5-4b7d-9d71-2cfae455fe31", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(764), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "65bb2650-2d2a-46b4-841b-39bc67d3b132", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(893), "Cera para automóvil", null, null, "Cera para automóvil", 1 },
                    { "66c6219a-a5eb-49d5-9a73-d36bb76d821a", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(964), "Vasos desechables", null, null, "Vasos desechables", 1 },
                    { "6ad37caa-6ee5-4f73-ab41-ea2be3d77828", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(324), "Cerveza", null, null, "Cerveza", 1 },
                    { "6c9aa2b5-8cef-4621-b526-d94b08c17e46", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(190), "Avena", null, null, "Avena", 1 },
                    { "6cf0328c-d542-43be-baed-72af19417433", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(579), "Chiles", null, null, "Chiles", 1 },
                    { "6d2eac00-615c-4802-8706-ed8f3b339e26", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(417), "Leche saborizada", null, null, "Leche saborizada", 1 },
                    { "6d5403fe-eb3b-4e6a-b66f-5584d61c75d5", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(621), "Agua saborizada", null, null, "Agua saborizada", 1 },
                    { "6eea4362-7ae5-4631-b3ca-571d523b3176", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(985), "Tenedores de plástico", null, null, "Tenedores de plástico", 1 },
                    { "6f9c9a1a-7ea6-40a2-9a50-feaa658493c7", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(403), "Leche evaporada", null, null, "Leche evaporada", 1 },
                    { "7002138f-f7fb-4a43-a880-060188703c09", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(643), "Bebidas en polvo", null, null, "Bebidas en polvo", 1 },
                    { "7027f120-3478-4896-81cf-21bcff739315", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(333), "Brandy", null, null, "Brandy", 1 },
                    { "70bc49ab-7e64-461a-a350-d18323fe6743", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(823), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "74bd441c-c526-4aa8-9948-467be87158e6", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(647), "Bebidas infantiles", null, null, "Bebidas infantiles", 1 },
                    { "76ac4c24-9bc2-4897-a9a2-60529d306a14", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(910), "Limpiadores para pisos", null, null, "Limpiadores para pisos", 1 },
                    { "77c79cbb-b53e-40aa-aa80-043d4f221bec", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(208), "Harina", null, null, "Harina", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "SubCategoryName", "state" },
                values: new object[,]
                {
                    { "77e2ee32-b9fc-4600-b28b-1ec5b0190e7d", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(686), "Mortadela", null, null, "Mortadela", 1 },
                    { "796cfb96-7b0d-4558-a4a9-08a9fed29071", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(807), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "7b3bdb7e-f9d4-4bfc-ab00-ad75b1e32185", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(635), "Naranjadas", null, null, "Naranjadas", 1 },
                    { "7be30abf-7504-480b-b0af-580ccc0be9ec", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(872), "Pilas", null, null, "Pilas", 1 },
                    { "7e36389e-2514-4c1a-9b02-956cccb72b7a", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(880), "Servilletas", null, null, "Servilletas", 1 },
                    { "7fc35ef8-08f5-4504-b578-012b873574d9", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(253), "Pastas", null, null, "Pastas", 1 },
                    { "8126f485-7a77-49c9-a3cb-de1be3b682bd", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(811), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "81806b92-46ce-4177-bcad-3c572857aec5", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(156), "Aceite comestibles", null, null, "Aceite comestibles", 1 },
                    { "82305cb1-de65-4b90-8734-87c5a768e7b3", "e7c4059e-04a1-4f4a-b5c9-b86da231147f", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(476), "Barras alimenticias", null, null, "Barras alimenticias", 1 },
                    { "82fe357c-af4b-436b-b648-983a6092aa65", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(258), "Aceitunas", null, null, "Aceitunas", 1 },
                    { "84990688-e3f9-45af-8f22-03c77262c614", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(200), "Cereales", null, null, "Cereales", 1 },
                    { "84bb56bb-c36d-4117-a4cf-e768990761eb", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(244), "Vinagre", null, null, "Vinagre", 1 },
                    { "85bb728e-2c64-4d40-9189-735313307bf8", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(815), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "86775899-0796-4ede-b76f-b2fb4b30aced", "c0f96f74-96cf-438a-b89f-0888182b3e75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(544), "Pastelillos", null, null, "Pastelillos", 1 },
                    { "88cfed2e-4469-4d95-8f08-252ce4f74e8f", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(707), "Carne de puerco/res/pollo", null, null, "Carne de puerco/res/pollo", 1 },
                    { "8a195233-1a00-4dbf-a41d-3c4c0d18b574", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(678), "Carnes y Embutidos", null, null, "Carnes y Embutidos", 1 },
                    { "8ac143dd-a639-4bad-9243-5706bf358ae1", "07dd4e15-386e-44c7-8f63-801c1dddeb1a", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(720), "Preservativos", null, null, "Preservativos", 1 },
                    { "8aee87a6-643f-4197-abe7-ee9956cfe636", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(802), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "8bac1ef3-473c-41a7-95a3-209fbea0c9b7", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(492), "Chocolate de mesa", null, null, "Chocolate de mesa", 1 },
                    { "8c066537-f8d7-4031-9172-872081e1d0a3", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1018), "Matamoscas", null, null, "Matamoscas", 1 },
                    { "8ef9734c-7ed8-4ce0-9899-d96b3da864eb", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(968), "Cinta adhesiva", null, null, "Cinta adhesiva", 1 },
                    { "8efb933d-b689-4110-8cff-4a4e20f46104", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(777), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "8f762c3f-368d-412b-bd04-3090847b30ea", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(608), "Plátanos", null, null, "Plátanos", 1 },
                    { "90bb3117-ea6e-4868-9fc3-7504f685c03e", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(266), "Chícharo con zanahoria", null, null, "Chícharo con zanahoria", 1 },
                    { "933336aa-5883-46b4-b6af-3f5c89b5b973", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(798), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "9538e426-3d8a-4575-aaeb-671bfadfcf4c", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(976), "Escobas/Trapeadores/Mechudos", null, null, "Escobas/Trapeadores/Mechudos", 1 },
                    { "95dc66d1-1de1-46de-a588-a5080f197aae", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(527), "Paletas de dulce", null, null, "Paletas de dulce", 1 },
                    { "98a5dd90-ba52-4534-998f-5da2e95e38b4", "9cb3d8c8-226e-4f1a-b04d-258db3329c75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1030), "Hielo", null, null, "Hielo", 1 },
                    { "995a74e1-98b5-4489-977d-f84113df2bc1", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(217), "Sopas en sobre", null, null, "Sopas en sobre", 1 },
                    { "9a15a184-1821-4b06-9b6d-8624e62f42fb", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(181), "Alimento para bebe", null, null, "Alimento para bebe", 1 },
                    { "9ba0b0c7-d09a-42e5-920d-fac472cfdad9", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(794), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "9c8dde52-8d6c-4b7c-9651-fef58287be61", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(311), "Sopa en lata", null, null, "Sopa en lata", 1 },
                    { "9cdba6b6-d54a-467c-ae55-baa752ec67c7", "c0f96f74-96cf-438a-b89f-0888182b3e75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(532), "Tortillas de harina/maíz", null, null, "Tortillas de harina/maíz", 1 },
                    { "9d6c9083-6b73-45c9-a61b-28800cfc5d0a", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(289), "Atún en agua/aceite", null, null, "Atún en agua/aceite", 1 },
                    { "9f8fff37-92e9-465b-ae5d-8940ae1e1cd3", "07dd4e15-386e-44c7-8f63-801c1dddeb1a", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(746), "Analgésicos", null, null, "Analgésicos", 1 },
                    { "a055a422-56d0-4852-ac24-5a5925002c35", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(690), "Tocino", null, null, "Tocino", 1 },
                    { "a1746970-5277-4100-87fb-27843e3e7572", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(617), "Agua natural", null, null, "Agua natural", 1 },
                    { "a2a399bc-e461-40b5-85e0-dddc7b5ddea4", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(863), "Sosa caustica", null, null, "Sosa caustica", 1 },
                    { "a37d971a-c292-4b59-8883-04362047cb2f", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(509), "Mazapán", null, null, "Mazapán", 1 },
                    { "a39c1fd6-2a60-4b29-8ba9-3e263406caf2", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(571), "Ajos", null, null, "Ajos", 1 },
                    { "a4d3cc0d-8e39-460c-a02d-18fc2dced014", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(186), "Alimento para mascotas", null, null, "Alimento para mascotas", 1 },
                    { "a5b8701d-c62c-476e-b22f-e666def4152a", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(363), "Sidra", null, null, "Sidra", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "SubCategoryName", "state" },
                values: new object[,]
                {
                    { "a64360a1-d91a-4405-9996-56ef3a89e32c", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(587), "Jitomate", null, null, "Jitomate", 1 },
                    { "a77e5bf6-0d96-4922-999e-09b4909ebae5", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(845), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "a8e6b961-8f12-4679-a05c-0d72fdb4f755", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(876), "Shampoo para ropa", null, null, "Shampoo para ropa", 1 },
                    { "a8f90356-989c-47a5-a6f6-ab338f283018", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(281), "Frutas en almíbar", null, null, "Frutas en almíbar", 1 },
                    { "a93bf77b-505b-46f8-8442-795bd47d83b2", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(496), "Chocolate en polvo", null, null, "Chocolate en polvo", 1 },
                    { "a93e6d6a-fe84-4977-88f9-9eb5dac3c7e4", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(695), "Jamón", null, null, "Jamón", 1 },
                    { "aae444bc-4a86-4e9f-bfbd-71ad73da07a2", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1010), "Fusibles", null, null, "Fusibles", 1 },
                    { "ad74e8ce-c6cf-4f0d-a7c3-0b86a5690808", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(430), "Yoghurt", null, null, "Yoghurt", 1 },
                    { "ad774f0a-e895-47c4-8b7e-9593c5d37f8e", "07dd4e15-386e-44c7-8f63-801c1dddeb1a", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(724), "Alcohol", null, null, "Alcohol", 1 },
                    { "add2357f-a4bd-480d-9652-df476b521e4c", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(939), "Insecticidas", null, null, "Insecticidas", 1 },
                    { "b0848172-c1be-469b-b874-5143c420a137", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(449), "Queso", null, null, "Queso", 1 },
                    { "b0a7966c-e4ab-426c-8628-c86106fbf3fe", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(868), "Aluminio", null, null, "Aluminio", 1 },
                    { "b0c6bb87-7bb1-43d4-b6fa-43eb67694604", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(927), "Cerillos", null, null, "Cerillos", 1 },
                    { "b1aac6b6-1e84-45a6-ac41-52e14a8ea1fa", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1001), "Platos desechables", null, null, "Platos desechables", 1 },
                    { "b21274b8-1f85-4034-aa24-f47ae1f46d00", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(204), "Especias", null, null, "Especias", 1 },
                    { "b3ae5bf6-5836-4e90-9c69-637afde26bd7", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(772), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "b4f45ffb-8b76-4304-bd06-706a228b5b10", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(947), "Desinfectantes", null, null, "Desinfectantes", 1 },
                    { "b71dd199-bb0d-44d2-98a1-71466e29b4ae", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(819), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "b83339e8-ec1b-44a4-8045-cb6e22905cd7", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(897), "Cera para calzados", null, null, "Cera para calzados", 1 },
                    { "b94e325c-2fa5-4c2e-ae97-66c53f7f23b1", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(625), "Jarabes", null, null, "Jarabes", 1 },
                    { "b9d66a36-38d6-4d57-bad3-b0e949a5a574", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(827), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "bb40a622-9e9e-4c19-ae9f-545dc86bef0d", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(931), "Cloro/Blanqueador", null, null, "Cloro/Blanqueador", 1 },
                    { "bb789c84-5913-4a64-984b-20ad85a99de1", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(575), "Cebollas", null, null, "Cebollas", 1 },
                    { "bc0083b3-7fce-4fb2-92df-9d6be798366a", "e7c4059e-04a1-4f4a-b5c9-b86da231147f", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(471), "Botanas saladas", null, null, "Botanas saladas", 1 },
                    { "bca46483-d119-4a9a-a72b-676d761ebb6a", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(354), "Ron", null, null, "Ron", 1 },
                    { "bd91bd5a-4f03-48d5-ab41-ff3900b3b566", "c0f96f74-96cf-438a-b89f-0888182b3e75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(548), "Pan de caja", null, null, "Pan de caja", 1 },
                    { "c3165ffb-7ad1-4730-8b00-a335edac1cc5", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(306), "Granos de elote enlatados", null, null, "Granos de elote enlatados", 1 },
                    { "c31961f5-e6ab-4f1f-a398-04ff4c7c2368", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(781), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "c346edb2-02df-4453-9ba6-a8c718d671bd", "c0f96f74-96cf-438a-b89f-0888182b3e75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(562), "Pan tostado", null, null, "Pan tostado", 1 },
                    { "c4a81f89-6f44-4c1c-bfd6-adf1f0a312e3", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(167), "Aderezos", null, null, "Aderezos", 1 },
                    { "c5ebff6a-ea3a-426c-a06c-38cfdf3fcc31", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(656), "Energetizantes", null, null, "Energetizantes", 1 },
                    { "c7296d61-4b18-46e9-8e26-7a809e636cb8", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(768), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "c7b90037-1c6d-4ad4-8397-5f04014ba97f", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(394), "Se encuentra todo sobre perfumeria", null, null, "Leche condensada", 1 },
                    { "c8cb23d4-2d87-41ec-a592-9535d366f9db", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(522), "Pastillas de dulce", null, null, "Pastillas de dulce", 1 },
                    { "c90a0767-fb77-4136-ab65-7719945e803a", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(841), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "cb924254-4f5b-4e25-aafc-b3c6e51a26a7", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(849), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "cdea20ca-087d-4fb5-8553-105c1e2d9a84", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(935), "Cloro para ropa", null, null, "Cloro para ropa", 1 },
                    { "ce775a23-82b1-4cdf-9736-a378cdb88c8c", "b296430c-42de-41f8-8fc2-3f7fadb44218", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(583), "Cilantro/Perejil", null, null, "Cilantro/Perejil", 1 },
                    { "cf17f4d4-cfc1-4c06-9f6a-6eac5062ede9", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(328), "Anís", null, null, "Anís", 1 },
                    { "d295440a-24c8-4a8f-879a-41f9c883fa4b", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(888), "Aromatizantes", null, null, "Aromatizantes", 1 },
                    { "d571e083-40cd-41db-8448-f55d4cc16780", "c0f96f74-96cf-438a-b89f-0888182b3e75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(540), "Galletas saladas", null, null, "Galletas saladas", 1 },
                    { "d6d038ac-c428-4761-8d24-dc0703e8e4c2", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(901), "Pastillas sanitarias", null, null, "Pastillas sanitarias", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "FinalDate", "ModifiedDate", "SubCategoryName", "state" },
                values: new object[,]
                {
                    { "d75240b2-f901-46af-80be-fcb9a7bd174b", "4af6f8b7-b1a5-4375-8319-079e3d8487fe", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(412), "Leche pasteurizada", null, null, "Leche pasteurizada", 1 },
                    { "d8fa7bc2-e8b5-44c4-b4ee-79f0db884832", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(612), "Agua mineral", null, null, "Agua mineral", 1 },
                    { "dbcc02e0-7b1e-406e-b3e0-a0f333b0062e", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(488), "Dulces enchilados", null, null, "Dulces enchilados", 1 },
                    { "dc85f186-d18b-4a8b-a504-698fda19a9b6", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(177), "Pure de tomate", null, null, "Pure de tomate", 1 },
                    { "dca0c0d8-69a7-451c-bbe3-db4e4237daaf", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(504), "Gomas de mascar", null, null, "Gomas de mascar", 1 },
                    { "dd2d472b-252b-4963-a802-6e615657df04", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(359), "Tequila", null, null, "Tequila", 1 },
                    { "dd56fb2d-90d1-404d-bf33-3a2163a6fc20", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(341), "Cordiales", null, null, "Cordiales", 1 },
                    { "def25cbf-86db-4ae4-ae45-7a63a8d71c6c", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(368), "Whiskey", null, null, "Whiskey", 1 },
                    { "df953e9b-49b2-4c98-bf43-c0b89ffd2671", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(980), "Trampas para ratas", null, null, "Trampas para ratas", 1 },
                    { "dfce1885-ecbe-432e-9148-8a2d34809082", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(1026), "Mecate/cuerda", null, null, "Mecate/cuerda", 1 },
                    { "e06b976c-4745-4368-a615-3d011811589e", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(669), "Pastas listas para comer", null, null, "Pastas listas para comer", 1 },
                    { "e28f8d28-5cb6-4f56-918e-c822a0060452", "e7c4059e-04a1-4f4a-b5c9-b86da231147f", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(458), "Palomitas", null, null, "Palomitas", 1 },
                    { "e3a46fc4-de62-41cc-8a11-305cbbf77ebb", "96e050b3-4f1c-4280-8ce0-1f32b6af87f1", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(293), "Chiles enlatados", null, null, "Chiles enlatados", 1 },
                    { "e5bc3319-2a58-4df3-89bd-17edc123cc0a", "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(703), "Chorizo", null, null, "Chorizo", 1 },
                    { "e5eab8bf-d214-4bb2-a42a-e73d6c8890d8", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(212), "Sal", null, null, "Sal", 1 },
                    { "e7af707d-2029-4d1d-a10b-9a5c55d98ca2", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(854), "Suavizante de telas", null, null, "Suavizante de telas", 1 },
                    { "eb4ed592-7499-4ea3-9c4d-aea95c4a86b1", "f350cdda-f912-4fd3-85c9-f99863ab6c2e", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(513), "Malvaviscos", null, null, "Malvaviscos", 1 },
                    { "ed6b2c4a-bcf3-4d0b-8e98-83ddd98653b6", "9fc02177-e0ba-42cf-bc95-cd2f7abc4418", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(759), "Se encuentra todo sobre perfumeria", null, null, "HIGIENE PERSONAL", 1 },
                    { "ee9c7eb3-842a-4671-a046-96facfb2bcb6", "07dd4e15-386e-44c7-8f63-801c1dddeb1a", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(712), "Suero", null, null, "Suero", 1 },
                    { "f467869a-bbb7-4647-bb04-82e7bfd07eb5", "c0f96f74-96cf-438a-b89f-0888182b3e75", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(557), "Pan molido", null, null, "Pan molido", 1 },
                    { "f586c0df-265a-46d3-9f7d-1219f269c2d6", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(639), "Bebidas de soya", null, null, "Bebidas de soya", 1 },
                    { "f66ac072-f4db-4bae-9ad3-25afe5d653b8", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(956), "Veladoras/Velas", null, null, "Veladoras/Velas", 1 },
                    { "f7f2a895-0a64-4e47-bbab-9bd914eaa86e", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(884), "Servitoallas", null, null, "Servitoallas", 1 },
                    { "fa7b0ef7-a5b5-48a8-80dd-bdbb51b3827a", "087aa814-3f3d-4cfb-83ef-e11256d6ecdb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(665), "Refrescos", null, null, "Refrescos", 1 },
                    { "fb894ec4-3008-46d0-bcbd-10c66df049af", "27d5e91e-1229-49cd-964b-cc812a81faeb", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(972), "Cucharas de plástico", null, null, "Cucharas de plástico", 1 },
                    { "fd74c75f-db36-4101-bcd4-9b5d672f2c5a", "4444da14-84ac-48de-a7da-a4f4ddd28858", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(195), "Azúcar", null, null, "Azúcar", 1 },
                    { "fec5fe83-b884-4d56-a5fe-6d7ab2156574", "21fcbb68-3e40-4550-b142-a302fc264a47", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(859), "Ácido muriático", null, null, "Ácido muriático", 1 },
                    { "fef25062-8fc1-4006-8514-e234bfa63a05", "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(388), "Vodka", null, null, "Vodka", 1 },
                    { "fefb0f12-c610-44ba-a425-b58344af0a3c", "07dd4e15-386e-44c7-8f63-801c1dddeb1a", new DateTime(2023, 6, 22, 23, 58, 0, 4, DateTimeKind.Local).AddTicks(729), "Gasas", null, null, "Gasas", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubModuleAccounts",
                columns: new[] { "Id", "CreatedDate", "FinalDate", "ModifiedDate", "ModuleAccountId", "SubModuleId", "state" },
                values: new object[,]
                {
                    { "5ab48144-1d40-44de-89c0-8813fa07520d", new DateTime(2023, 6, 22, 23, 58, 0, 7, DateTimeKind.Local).AddTicks(664), null, null, "7151993b-b219-4e22-80f2-0ec8002e4b3f", "371d3ef5-916f-4c5a-9bdb-4208febf7813", 1 },
                    { "8eed93e8-914c-440b-8eff-8a458f728318", new DateTime(2023, 6, 22, 23, 58, 0, 7, DateTimeKind.Local).AddTicks(668), null, null, "7151993b-b219-4e22-80f2-0ec8002e4b3f", "0081ef4d-6b18-4e83-a443-b3b85abc6c47", 1 },
                    { "bd812379-dc7b-4439-b116-24467fd0b31c", new DateTime(2023, 6, 22, 23, 58, 0, 7, DateTimeKind.Local).AddTicks(649), null, null, "7151993b-b219-4e22-80f2-0ec8002e4b3f", "ee090c50-f4a4-4877-8df7-0a05abeaf1c8", 1 },
                    { "ca8743fd-6fed-4289-94d9-de8db265282a", new DateTime(2023, 6, 22, 23, 58, 0, 7, DateTimeKind.Local).AddTicks(660), null, null, "7151993b-b219-4e22-80f2-0ec8002e4b3f", "b6960d25-b1d3-4a16-88b9-56ad9d8bd212", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AccountId",
                table: "Categories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_AccountId",
                table: "Histories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPrices_AccountId",
                table: "HistoryPrices",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPrices_ProductId",
                table: "HistoryPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_IncreasePriceAfterTwelves_AccountId",
                table: "IncreasePriceAfterTwelves",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Legit_AccountId",
                table: "Legit",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Legit_SaleId",
                table: "Legit",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_ProductId",
                table: "Lots",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleAccounts_AccountId",
                table: "ModuleAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleAccounts_ModuleId",
                table: "ModuleAccounts",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenWorkTurns_AccountId",
                table: "OpenWorkTurns",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenWorkTurns_TurnId",
                table: "OpenWorkTurns",
                column: "TurnId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_AccountId",
                table: "PaymentTypes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountId",
                table: "Products",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderId",
                table: "Products",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_AccountId",
                table: "Providers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_productId",
                table: "SaleDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_SaleId",
                table: "SaleDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PaymentTypeId",
                table: "Sales",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingBusiness_BusinessId",
                table: "SettingBusiness",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubModuleAccounts_ModuleAccountId",
                table: "SubModuleAccounts",
                column: "ModuleAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SubModuleAccounts_SubModuleId",
                table: "SubModuleAccounts",
                column: "SubModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubModules_ModuleId",
                table: "SubModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_AccountId",
                table: "Turns",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_BusinessId",
                table: "Turns",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessId",
                table: "Users",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "HistoryPrices");

            migrationBuilder.DropTable(
                name: "IncreasePriceAfterTwelves");

            migrationBuilder.DropTable(
                name: "Legit");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "OpenWorkTurns");

            migrationBuilder.DropTable(
                name: "SaleDetails");

            migrationBuilder.DropTable(
                name: "SettingBusiness");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "SubModuleAccounts");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "ModuleAccounts");

            migrationBuilder.DropTable(
                name: "SubModules");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}
