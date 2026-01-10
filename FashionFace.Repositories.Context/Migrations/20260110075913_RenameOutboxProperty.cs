using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFace.Repositories.Context.Migrations
{
    /// <inheritdoc />
    public partial class RenameOutboxProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessingStartedAt",
                table: "UserToUserChatMessageSendOutbox",
                newName: "ClaimedAt");

            migrationBuilder.RenameColumn(
                name: "ProcessingStartedAt",
                table: "UserToUserChatMessageSendNotificationOutbox",
                newName: "ClaimedAt");

            migrationBuilder.RenameColumn(
                name: "ProcessingStartedAt",
                table: "UserToUserChatMessageReadOutbox",
                newName: "ClaimedAt");

            migrationBuilder.RenameColumn(
                name: "ProcessingStartedAt",
                table: "UserToUserChatMessageReadNotificationOutbox",
                newName: "ClaimedAt");

            migrationBuilder.RenameColumn(
                name: "ProcessingStartedAt",
                table: "UserToUserChatInvitationRejectedOutbox",
                newName: "ClaimedAt");

            migrationBuilder.RenameColumn(
                name: "ProcessingStartedAt",
                table: "UserToUserChatInvitationCreatedOutbox",
                newName: "ClaimedAt");

            migrationBuilder.RenameColumn(
                name: "ProcessingStartedAt",
                table: "UserToUserChatInvitationCanceledOutbox",
                newName: "ClaimedAt");

            migrationBuilder.RenameColumn(
                name: "ProcessingStartedAt",
                table: "UserToUserChatInvitationAcceptedOutbox",
                newName: "ClaimedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClaimedAt",
                table: "UserToUserChatMessageSendOutbox",
                newName: "ProcessingStartedAt");

            migrationBuilder.RenameColumn(
                name: "ClaimedAt",
                table: "UserToUserChatMessageSendNotificationOutbox",
                newName: "ProcessingStartedAt");

            migrationBuilder.RenameColumn(
                name: "ClaimedAt",
                table: "UserToUserChatMessageReadOutbox",
                newName: "ProcessingStartedAt");

            migrationBuilder.RenameColumn(
                name: "ClaimedAt",
                table: "UserToUserChatMessageReadNotificationOutbox",
                newName: "ProcessingStartedAt");

            migrationBuilder.RenameColumn(
                name: "ClaimedAt",
                table: "UserToUserChatInvitationRejectedOutbox",
                newName: "ProcessingStartedAt");

            migrationBuilder.RenameColumn(
                name: "ClaimedAt",
                table: "UserToUserChatInvitationCreatedOutbox",
                newName: "ProcessingStartedAt");

            migrationBuilder.RenameColumn(
                name: "ClaimedAt",
                table: "UserToUserChatInvitationCanceledOutbox",
                newName: "ProcessingStartedAt");

            migrationBuilder.RenameColumn(
                name: "ClaimedAt",
                table: "UserToUserChatInvitationAcceptedOutbox",
                newName: "ProcessingStartedAt");
        }
    }
}
