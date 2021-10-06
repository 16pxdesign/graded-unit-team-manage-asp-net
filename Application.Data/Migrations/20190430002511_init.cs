using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Flat = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Opposition = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    KO = table.Column<DateTime>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Result = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Skill_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    SRU = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.SRU);
                    table.ForeignKey(
                        name: "FK_Members_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Half = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Team = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    SRU = table.Column<string>(nullable: false),
                    Position = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.SRU);
                    table.ForeignKey(
                        name: "FK_Player_Members_SRU",
                        column: x => x.SRU,
                        principalTable: "Members",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    CoachSRU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Members_CoachSRU",
                        column: x => x.CoachSRU,
                        principalTable: "Members",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PlayerSRU = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Player_PlayerSRU",
                        column: x => x.PlayerSRU,
                        principalTable: "Player",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthIssues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PlayerSRU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthIssues_Player_PlayerSRU",
                        column: x => x.PlayerSRU,
                        principalTable: "Player",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Junior",
                columns: table => new
                {
                    SRU = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junior", x => x.SRU);
                    table.ForeignKey(
                        name: "FK_Junior_Player_SRU",
                        column: x => x.SRU,
                        principalTable: "Player",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    PlayerSRU = table.Column<string>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => new { x.PlayerSRU, x.SkillId });
                    table.ForeignKey(
                        name: "FK_Profile_Player_PlayerSRU",
                        column: x => x.PlayerSRU,
                        principalTable: "Player",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Senior",
                columns: table => new
                {
                    SRU = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senior", x => x.SRU);
                    table.ForeignKey(
                        name: "FK_Senior_Player_SRU",
                        column: x => x.SRU,
                        principalTable: "Player",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TrainingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TrainingId = table.Column<int>(nullable: false),
                    PlayerSRU = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.UniqueConstraint("AK_Attendance_PlayerSRU_TrainingId", x => new { x.PlayerSRU, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_Attendance_Player_PlayerSRU",
                        column: x => x.PlayerSRU,
                        principalTable: "Player",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    Signature = table.Column<DateTime>(nullable: false),
                    JuniorId = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guardians_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guardians_Junior_JuniorId",
                        column: x => x.JuniorId,
                        principalTable: "Junior",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeniorSRU = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kin_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kin_Senior_SeniorSRU",
                        column: x => x.SeniorSRU,
                        principalTable: "Senior",
                        principalColumn: "SRU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TrainingId",
                table: "Activities",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_TrainingId",
                table: "Attendance",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_AddressId",
                table: "Doctor",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PlayerSRU",
                table: "Doctor",
                column: "PlayerSRU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_AddressId",
                table: "Guardians",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_JuniorId",
                table: "Guardians",
                column: "JuniorId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthIssues_PlayerSRU",
                table: "HealthIssues",
                column: "PlayerSRU");

            migrationBuilder.CreateIndex(
                name: "IX_Kin_AddressId",
                table: "Kin",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kin_SeniorSRU",
                table: "Kin",
                column: "SeniorSRU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_AddressId",
                table: "Members",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_PlayerSRU",
                table: "Profile",
                column: "PlayerSRU");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_SkillId",
                table: "Profile",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GameId",
                table: "Scores",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ParentId",
                table: "Skill",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_CoachSRU",
                table: "Training",
                column: "CoachSRU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.DropTable(
                name: "HealthIssues");

            migrationBuilder.DropTable(
                name: "Kin");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Junior");

            migrationBuilder.DropTable(
                name: "Senior");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
