using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBackKratek.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTerminal = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SlaveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StatusLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeRegisterTerminalFromControllers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    DescriptionRegisterTerminal = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    OldValue = table.Column<double>(type: "float", nullable: false),
                    NewValue = table.Column<double>(type: "float", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRegisterTerminalFromControllers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeRegisterTerminalFromControllers_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionCoalHourTerminals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    NameRegister = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ValueRegister = table.Column<double>(type: "float", nullable: false),
                    DateWrite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionCoalHourTerminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumptionCoalHourTerminals_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataTerminalJournals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    DescriptionsRegister = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ValueRegister = table.Column<double>(type: "float", nullable: false),
                    Flags = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAddValues = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberRegister = table.Column<int>(type: "int", nullable: false),
                    GroupRegister = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTerminalJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTerminalJournals_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataTerminals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    DescriptionsRegister = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ValueRegister = table.Column<double>(type: "float", nullable: false),
                    Flags = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAddValues = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberRegister = table.Column<int>(type: "int", nullable: false),
                    GroupRegister = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTerminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTerminals_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ErrorJournalTerminals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    NameDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateError = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorJournalTerminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErrorJournalTerminals_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ErrorTerminals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    NameDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateError = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorTerminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErrorTerminals_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    TypeEngine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeFrequency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Modbuss = table.Column<int>(type: "int", nullable: false),
                    Current = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastPoll = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frequencies_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SensorTerminals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    NameSensor = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AcessSensor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorTerminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorTerminals_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TelegramUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    NameContact = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelegramUsers_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TerminalSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    NumberPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConenctionsTerminalJobChannel = table.Column<bool>(type: "bit", nullable: false),
                    ConnectionsTerminalServicesChannel = table.Column<bool>(type: "bit", nullable: false),
                    AcessReadModbuss = table.Column<bool>(type: "bit", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressObject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeServices = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Acess = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeAsphan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PowerWanCoal = table.Column<double>(type: "float", nullable: false),
                    NormaWater = table.Column<double>(type: "float", nullable: false),
                    CapasityBunker = table.Column<double>(type: "float", nullable: false),
                    PowerBoiler = table.Column<double>(type: "float", nullable: false),
                    Ibr = table.Column<bool>(type: "bit", nullable: false),
                    PollFrequencies = table.Column<bool>(type: "bit", nullable: false),
                    MyProperty = table.Column<double>(type: "float", nullable: false),
                    DateLastInterogation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLoadCoal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChangeAsphan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionFirtware = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerminalSettings_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TerminalUser",
                columns: table => new
                {
                    TerminalsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalUser", x => new { x.TerminalsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TerminalUser_Terminals_TerminalsId",
                        column: x => x.TerminalsId,
                        principalTable: "Terminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerminalUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TypeChange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescParametr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OldValue = table.Column<int>(type: "int", nullable: false),
                    NewValue = table.Column<int>(type: "int", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultWriteClient = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Client = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NamePK = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChanges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataFrequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequencyId = table.Column<int>(type: "int", nullable: true),
                    NameRegister = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ValueRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DatePoll = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataFrequencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataFrequencies_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataFrequencyJournals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequencyId = table.Column<int>(type: "int", nullable: true),
                    NameRegister = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ValueRegister = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DatePoll = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataFrequencyJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataFrequencyJournals_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ErrorFrequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequencyId = table.Column<int>(type: "int", nullable: true),
                    NameError = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DateError = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorFrequencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErrorFrequencies_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ErrorJournalFrequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequencyId = table.Column<int>(type: "int", nullable: true),
                    NameError = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ActualError = table.Column<bool>(type: "bit", nullable: false),
                    DateError = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorJournalFrequencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErrorJournalFrequencies_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeRegisterTerminalFromControllers_TerminalId",
                table: "ChangeRegisterTerminalFromControllers",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionCoalHourTerminals_TerminalId",
                table: "ConsumptionCoalHourTerminals",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_DataFrequencies_FrequencyId",
                table: "DataFrequencies",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataFrequencyJournals_FrequencyId",
                table: "DataFrequencyJournals",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTerminalJournals_TerminalId",
                table: "DataTerminalJournals",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTerminals_TerminalId",
                table: "DataTerminals",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorFrequencies_FrequencyId",
                table: "ErrorFrequencies",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorJournalFrequencies_FrequencyId",
                table: "ErrorJournalFrequencies",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorJournalTerminals_TerminalId",
                table: "ErrorJournalTerminals",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorTerminals_TerminalId",
                table: "ErrorTerminals",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_TerminalId",
                table: "Frequencies",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorTerminals_TerminalId",
                table: "SensorTerminals",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramUsers_TerminalId",
                table: "TelegramUsers",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalSettings_TerminalId",
                table: "TerminalSettings",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalUser_UsersId",
                table: "TerminalUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChanges_UserId",
                table: "UserChanges",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeRegisterTerminalFromControllers");

            migrationBuilder.DropTable(
                name: "ConsumptionCoalHourTerminals");

            migrationBuilder.DropTable(
                name: "DataFrequencies");

            migrationBuilder.DropTable(
                name: "DataFrequencyJournals");

            migrationBuilder.DropTable(
                name: "DataTerminalJournals");

            migrationBuilder.DropTable(
                name: "DataTerminals");

            migrationBuilder.DropTable(
                name: "ErrorFrequencies");

            migrationBuilder.DropTable(
                name: "ErrorJournalFrequencies");

            migrationBuilder.DropTable(
                name: "ErrorJournalTerminals");

            migrationBuilder.DropTable(
                name: "ErrorTerminals");

            migrationBuilder.DropTable(
                name: "SensorTerminals");

            migrationBuilder.DropTable(
                name: "TelegramUsers");

            migrationBuilder.DropTable(
                name: "TerminalSettings");

            migrationBuilder.DropTable(
                name: "TerminalUser");

            migrationBuilder.DropTable(
                name: "UserChanges");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Terminals");
        }
    }
}
