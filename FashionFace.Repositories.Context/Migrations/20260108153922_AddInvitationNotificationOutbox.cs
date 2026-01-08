using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFace.Repositories.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddInvitationNotificationOutbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserToUserChatInvitationAcceptedOutbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvitationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitiatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OutboxStatus = table.Column<int>(type: "integer", nullable: false),
                    AttemptCount = table.Column<int>(type: "integer", nullable: false),
                    ProcessingStartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChatInvitationAcceptedOutbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationAcceptedOutbox_AspNetUsers_Initiato~",
                        column: x => x.InitiatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationAcceptedOutbox_AspNetUsers_TargetUs~",
                        column: x => x.TargetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationAcceptedOutbox_UserToUserChatInvita~",
                        column: x => x.InvitationId,
                        principalTable: "UserToUserChatInvitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationAcceptedOutbox_UserToUserChat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "UserToUserChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToUserChatInvitationCanceledOutbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvitationId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitiatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OutboxStatus = table.Column<int>(type: "integer", nullable: false),
                    AttemptCount = table.Column<int>(type: "integer", nullable: false),
                    ProcessingStartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChatInvitationCanceledOutbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationCanceledOutbox_AspNetUsers_Initiato~",
                        column: x => x.InitiatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationCanceledOutbox_AspNetUsers_TargetUs~",
                        column: x => x.TargetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationCanceledOutbox_UserToUserChatInvita~",
                        column: x => x.InvitationId,
                        principalTable: "UserToUserChatInvitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToUserChatInvitationCreatedOutbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvitationId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitiatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OutboxStatus = table.Column<int>(type: "integer", nullable: false),
                    AttemptCount = table.Column<int>(type: "integer", nullable: false),
                    ProcessingStartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChatInvitationCreatedOutbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationCreatedOutbox_AspNetUsers_Initiator~",
                        column: x => x.InitiatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationCreatedOutbox_AspNetUsers_TargetUse~",
                        column: x => x.TargetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationCreatedOutbox_UserToUserChatInvitat~",
                        column: x => x.InvitationId,
                        principalTable: "UserToUserChatInvitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToUserChatInvitationRejectedOutbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvitationId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitiatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OutboxStatus = table.Column<int>(type: "integer", nullable: false),
                    AttemptCount = table.Column<int>(type: "integer", nullable: false),
                    ProcessingStartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUserChatInvitationRejectedOutbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationRejectedOutbox_AspNetUsers_Initiato~",
                        column: x => x.InitiatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationRejectedOutbox_AspNetUsers_TargetUs~",
                        column: x => x.TargetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToUserChatInvitationRejectedOutbox_UserToUserChatInvita~",
                        column: x => x.InvitationId,
                        principalTable: "UserToUserChatInvitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationAcceptedOutbox_ChatId",
                table: "UserToUserChatInvitationAcceptedOutbox",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationAcceptedOutbox_InitiatorUserId",
                table: "UserToUserChatInvitationAcceptedOutbox",
                column: "InitiatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationAcceptedOutbox_InvitationId",
                table: "UserToUserChatInvitationAcceptedOutbox",
                column: "InvitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationAcceptedOutbox_TargetUserId",
                table: "UserToUserChatInvitationAcceptedOutbox",
                column: "TargetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationCanceledOutbox_InitiatorUserId",
                table: "UserToUserChatInvitationCanceledOutbox",
                column: "InitiatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationCanceledOutbox_InvitationId",
                table: "UserToUserChatInvitationCanceledOutbox",
                column: "InvitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationCanceledOutbox_TargetUserId",
                table: "UserToUserChatInvitationCanceledOutbox",
                column: "TargetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationCreatedOutbox_InitiatorUserId",
                table: "UserToUserChatInvitationCreatedOutbox",
                column: "InitiatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationCreatedOutbox_InvitationId",
                table: "UserToUserChatInvitationCreatedOutbox",
                column: "InvitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationCreatedOutbox_TargetUserId",
                table: "UserToUserChatInvitationCreatedOutbox",
                column: "TargetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationRejectedOutbox_InitiatorUserId",
                table: "UserToUserChatInvitationRejectedOutbox",
                column: "InitiatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationRejectedOutbox_InvitationId",
                table: "UserToUserChatInvitationRejectedOutbox",
                column: "InvitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToUserChatInvitationRejectedOutbox_TargetUserId",
                table: "UserToUserChatInvitationRejectedOutbox",
                column: "TargetUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToUserChatInvitationAcceptedOutbox");

            migrationBuilder.DropTable(
                name: "UserToUserChatInvitationCanceledOutbox");

            migrationBuilder.DropTable(
                name: "UserToUserChatInvitationCreatedOutbox");

            migrationBuilder.DropTable(
                name: "UserToUserChatInvitationRejectedOutbox");
        }
    }
}
