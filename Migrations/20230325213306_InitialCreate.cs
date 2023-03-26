using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

//This is auto-generated file after I ran migration. 
namespace HRAS_2023.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    StockID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.StockID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", maxLength: 9, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    insurer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ZIP = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    streetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCurrentlyCheckedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.SSN);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    userName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BirthDate = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleInitial = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxOccupancy = table.Column<int>(type: "int", nullable: false),
                    HourlyRate = table.Column<long>(type: "bigint", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingName",
                        column: x => x.BuildingName,
                        principalTable: "Buildings",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingName",
                table: "Rooms",
                column: "BuildingName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
