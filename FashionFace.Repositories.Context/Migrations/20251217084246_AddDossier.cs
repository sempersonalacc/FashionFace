using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFace.Repositories.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddDossier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Filter",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Dossier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossier_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DossierMediaAggregate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DossierId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaAggregateId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionIndex = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierMediaAggregate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierMediaAggregate_Dossier_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DossierMediaAggregate_MediaAggregate_MediaAggregateId",
                        column: x => x.MediaAggregateId,
                        principalTable: "MediaAggregate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filter_ApplicationUserId",
                table: "Filter",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossier_ProfileId",
                table: "Dossier",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DossierMediaAggregate_DossierId",
                table: "DossierMediaAggregate",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierMediaAggregate_MediaAggregateId",
                table: "DossierMediaAggregate",
                column: "MediaAggregateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_AspNetUsers_ApplicationUserId",
                table: "Filter",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filter_AspNetUsers_ApplicationUserId",
                table: "Filter");

            migrationBuilder.DropTable(
                name: "DossierMediaAggregate");

            migrationBuilder.DropTable(
                name: "Dossier");

            migrationBuilder.DropIndex(
                name: "IX_Filter_ApplicationUserId",
                table: "Filter");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Filter");
        }
    }
}
