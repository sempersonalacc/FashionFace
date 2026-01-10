using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFace.Repositories.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddCorrelationIdProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CorrelationId",
                table: "UserToUserChatMessageSendOutbox",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CorrelationId",
                table: "UserToUserChatMessageSendNotificationOutbox",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CorrelationId",
                table: "UserToUserChatMessageReadOutbox",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CorrelationId",
                table: "UserToUserChatMessageReadNotificationOutbox",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CorrelationId",
                table: "UserToUserChatInvitationRejectedOutbox",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CorrelationId",
                table: "UserToUserChatInvitationCreatedOutbox",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CorrelationId",
                table: "UserToUserChatInvitationCanceledOutbox",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CorrelationId",
                table: "UserToUserChatInvitationAcceptedOutbox",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "UserToUserChatMessageSendOutbox");

            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "UserToUserChatMessageSendNotificationOutbox");

            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "UserToUserChatMessageReadOutbox");

            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "UserToUserChatMessageReadNotificationOutbox");

            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "UserToUserChatInvitationRejectedOutbox");

            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "UserToUserChatInvitationCreatedOutbox");

            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "UserToUserChatInvitationCanceledOutbox");

            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "UserToUserChatInvitationAcceptedOutbox");
        }
    }
}
