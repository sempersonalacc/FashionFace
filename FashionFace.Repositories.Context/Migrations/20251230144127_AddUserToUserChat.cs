using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFace.Repositories.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToUserChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserToUserChatInvitation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InitiatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChatInvitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitation_AspNetUsers_InitiatorUserId",
                        column: x => x.InitiatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitation_AspNetUsers_TargetUserId",
                        column: x => x.TargetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToUserMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserMessage_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToUserChat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SettingsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserToUserChatApplicationUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "varchar(32)", nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", nullable: false),
                    LastReadMessagePositionIndex = table.Column<double>(type: "double precision", nullable: false),
                    UserToUserChatId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChatApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserChatApplicationUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatApplicationUser_UserToUserChat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "UserToUserChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatApplicationUser_UserToUserChat_UserToUserChat~",
                        column: x => x.UserToUserChatId,
                        principalTable: "UserToUserChat",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserToUserChatMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionIndex = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserToUserChatId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserChatMessage_UserToUserChat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "UserToUserChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatMessage_UserToUserChat_UserToUserChatId",
                        column: x => x.UserToUserChatId,
                        principalTable: "UserToUserChat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserToUserChatMessage_UserToUserMessage_MessageId",
                        column: x => x.MessageId,
                        principalTable: "UserToUserMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToUserChatSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatType = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChatSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserChatSettings_UserToUserChat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "UserToUserChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChat_SettingsId",
                table: "UserToUserChat",
                column: "SettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatApplicationUser_ApplicationUserId",
                table: "UserToUserChatApplicationUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatApplicationUser_ChatId",
                table: "UserToUserChatApplicationUser",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatApplicationUser_UserToUserChatId",
                table: "UserToUserChatApplicationUser",
                column: "UserToUserChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitation_InitiatorUserId",
                table: "UserToUserChatInvitation",
                column: "InitiatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitation_TargetUserId",
                table: "UserToUserChatInvitation",
                column: "TargetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatMessage_ChatId",
                table: "UserToUserChatMessage",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatMessage_MessageId",
                table: "UserToUserChatMessage",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatMessage_UserToUserChatId",
                table: "UserToUserChatMessage",
                column: "UserToUserChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatSettings_ChatId",
                table: "UserToUserChatSettings",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserMessage_ApplicationUserId",
                table: "UserToUserMessage",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToUserChat_UserToUserChatSettings_SettingsId",
                table: "UserToUserChat",
                column: "SettingsId",
                principalTable: "UserToUserChatSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToUserChat_UserToUserChatSettings_SettingsId",
                table: "UserToUserChat");

            migrationBuilder.DropTable(
                name: "UserToUserChatApplicationUser");

            migrationBuilder.DropTable(
                name: "UserToUserChatInvitation");

            migrationBuilder.DropTable(
                name: "UserToUserChatMessage");

            migrationBuilder.DropTable(
                name: "UserToUserMessage");

            migrationBuilder.DropTable(
                name: "UserToUserChatSettings");

            migrationBuilder.DropTable(
                name: "UserToUserChat");
        }
    }
}
