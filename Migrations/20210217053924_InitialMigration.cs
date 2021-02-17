using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeerthiveeduAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDttm = table.Column<DateTime>(nullable: false),
                    EndDttm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    MessageDttm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PrevId = table.Column<int>(nullable: false),
                    HeaderId = table.Column<int>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameters_Parameters_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rituals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rituals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    EventId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FamilyTypeId = table.Column<int>(nullable: false),
                    FamilyTypesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyGroups_Parameters_FamilyTypesId",
                        column: x => x.FamilyTypesId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RitualBookingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<int>(nullable: false),
                    RitualId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    DiscountPrice = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RitualBookingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RitualBookingDetails_Rituals_RitualId",
                        column: x => x.RitualId,
                        principalTable: "Rituals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    FamilyGroupId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    CreatedDttm = table.Column<DateTime>(nullable: false),
                    VerifiedUserId = table.Column<long>(nullable: false),
                    VerifiedDttm = table.Column<DateTime>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_FamilyGroups_FamilyGroupId",
                        column: x => x.FamilyGroupId,
                        principalTable: "FamilyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    MemberPositionId = table.Column<int>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Committees_Parameters_MemberPositionId",
                        column: x => x.MemberPositionId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Committees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RitualBookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    RitualDate = table.Column<DateTime>(nullable: false),
                    BookedDate = table.Column<DateTime>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RitualBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RitualBookings_Parameters_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RitualBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRights",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    AppUserId = table.Column<long>(nullable: true),
                    RightsId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRights_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRights_Rights_RightsId",
                        column: x => x.RightsId,
                        principalTable: "Rights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FamilyGroups",
                columns: new[] { "Id", "FamilyTypeId", "FamilyTypesId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 101, null, true, "PularaKeerthiyil" },
                    { 2, 102, null, true, "OralasseryKeerthiyil" },
                    { 3, 103, null, true, "PallarmangalamKeerthiyil" }
                });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "HeaderId", "IsActive", "Name", "PrevId", "ShortCode" },
                values: new object[,]
                {
                    { 1, null, true, "Family Types", 0, "FT" },
                    { 2, null, true, "Committe Member Posts", 0, "CMT" },
                    { 3, null, true, "Photo Categories", 0, "PC" },
                    { 101, null, true, "Ezham Edam", 1, "EE" },
                    { 102, null, true, "Naalam Edam", 1, "NE" },
                    { 103, null, true, "Secretary", 2, "SC" },
                    { 104, null, true, "President", 2, "PST" },
                    { 105, null, true, "Executive Member", 2, "EXMEM" },
                    { 106, null, true, "Committee Member Profile", 3, "CMP" },
                    { 107, null, true, "Event Photos", 3, "EVNTP" },
                    { 108, null, true, "Web Photos", 3, "WEBP" }
                });

            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "Id", "IsActive", "Name", "ShortCode" },
                values: new object[,]
                {
                    { 1, true, "Administrator", "ADMIN" },
                    { 2, true, "VerificationUser", "VERIFICATION" }
                });

            migrationBuilder.InsertData(
                table: "UserRights",
                columns: new[] { "Id", "AppUserId", "IsActive", "RightsId", "UserId" },
                values: new object[] { 1L, null, true, 1, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Committees_MemberPositionId",
                table: "Committees",
                column: "MemberPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_UserId",
                table: "Committees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyGroups_FamilyTypesId",
                table: "FamilyGroups",
                column: "FamilyTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_HeaderId",
                table: "Parameters",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_EventId",
                table: "Photos",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RitualBookingDetails_RitualId",
                table: "RitualBookingDetails",
                column: "RitualId");

            migrationBuilder.CreateIndex(
                name: "IX_RitualBookings_StatusId",
                table: "RitualBookings",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RitualBookings_UserId",
                table: "RitualBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRights_AppUserId",
                table: "UserRights",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRights_RightsId",
                table: "UserRights",
                column: "RightsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyGroupId",
                table: "Users",
                column: "FamilyGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "RitualBookingDetails");

            migrationBuilder.DropTable(
                name: "RitualBookings");

            migrationBuilder.DropTable(
                name: "UserRights");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Rituals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rights");

            migrationBuilder.DropTable(
                name: "FamilyGroups");

            migrationBuilder.DropTable(
                name: "Parameters");
        }
    }
}
