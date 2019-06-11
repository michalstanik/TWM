using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TWM.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableName = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    KeyValues = table.Column<string>(nullable: true),
                    OldValues = table.Column<string>(nullable: true),
                    NewValues = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorldHeritage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnescoId = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsoCodes = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldHeritage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ContinentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Continent_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TripCode = table.Column<string>(nullable: true, computedColumnSql: "'TR-' + CONVERT(varchar(10),[Id])"),
                    StarRating = table.Column<double>(nullable: false),
                    TripManagerId = table.Column<string>(nullable: true),
                    TripTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_TUser_TripManagerId",
                        column: x => x.TripManagerId,
                        principalTable: "TUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trip_TripType_TripTypeId",
                        column: x => x.TripTypeId,
                        principalTable: "TripType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OfficialName = table.Column<string>(nullable: true),
                    Alpha2Code = table.Column<string>(nullable: true),
                    Alpha3Code = table.Column<string>(nullable: true),
                    Area = table.Column<long>(nullable: false),
                    RegionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTrip",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false),
                    TUserId = table.Column<string>(nullable: false),
                    IsOrganiser = table.Column<bool>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrip", x => new { x.TripId, x.TUserId });
                    table.ForeignKey(
                        name: "FK_UserTrip_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTrip_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    LocationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_LocationType_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCountryAssessment",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    TUserId = table.Column<string>(nullable: false),
                    AreaLevelAssessment = table.Column<long>(nullable: false),
                    CountryKnowledgeType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCountryAssessment", x => new { x.CountryId, x.TUserId });
                    table.ForeignKey(
                        name: "FK_UserCountryAssessment_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCountryAssessment_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorldHeritageCountry",
                columns: table => new
                {
                    WorldHeritageId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldHeritageCountry", x => new { x.WorldHeritageId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_WorldHeritageCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorldHeritageCountry_WorldHeritage_WorldHeritageId",
                        column: x => x.WorldHeritageId,
                        principalTable: "WorldHeritage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StopName = table.Column<string>(nullable: true),
                    StopDescription = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false),
                    TripId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stop_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stop_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_RegionId",
                table: "Country",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CountryId",
                table: "Location",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationTypeId",
                table: "Location",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_ContinentId",
                table: "Region",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_LocationId",
                table: "Stop",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_TripId",
                table: "Stop",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TripManagerId",
                table: "Trip",
                column: "TripManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TripTypeId",
                table: "Trip",
                column: "TripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCountryAssessment_TUserId",
                table: "UserCountryAssessment",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrip_TUserId",
                table: "UserTrip",
                column: "TUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldHeritageCountry_CountryId",
                table: "WorldHeritageCountry",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "Stop");

            migrationBuilder.DropTable(
                name: "UserCountryAssessment");

            migrationBuilder.DropTable(
                name: "UserTrip");

            migrationBuilder.DropTable(
                name: "WorldHeritageCountry");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "WorldHeritage");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropTable(
                name: "TUser");

            migrationBuilder.DropTable(
                name: "TripType");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Continent");
        }
    }
}
