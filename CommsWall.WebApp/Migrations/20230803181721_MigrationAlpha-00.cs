using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommsWall.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAlpha00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatSubscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysIdentifier = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateSubscribed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSubscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GroupDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatGroups_ChatSubscribers_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "ChatSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    TargetIdentifier = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSessions", x => x.Id);
                    table.UniqueConstraint("AK_User_UniqueTargetKind", x => new { x.SenderId, x.TargetIdentifier, x.Category });
                    table.ForeignKey(
                        name: "FK_ChatSessions_ChatSubscribers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "ChatSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetUserID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_ChatSubscribers_TargetUserID",
                        column: x => x.TargetUserID,
                        principalTable: "ChatSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DatePromoted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAdmin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupAdmin_ChatGroups_ChatGroupId",
                        column: x => x.ChatGroupId,
                        principalTable: "ChatGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupAdmin_ChatSubscribers_UserID",
                        column: x => x.UserID,
                        principalTable: "ChatSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMember_ChatGroups_ChatGroupId",
                        column: x => x.ChatGroupId,
                        principalTable: "ChatGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupMember_ChatSubscribers_UserID",
                        column: x => x.UserID,
                        principalTable: "ChatSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionID = table.Column<int>(type: "int", nullable: false),
                    TextMessage = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatSessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "ChatSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatGroups_CreatorID",
                table: "ChatGroups",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SessionID",
                table: "ChatMessages",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAdmin_ChatGroupId",
                table: "GroupAdmin",
                column: "ChatGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAdmin_UserID",
                table: "GroupAdmin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_ChatGroupId",
                table: "GroupMember",
                column: "ChatGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_UserID",
                table: "GroupMember",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TargetUserID",
                table: "Notifications",
                column: "TargetUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "GroupAdmin");

            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ChatSessions");

            migrationBuilder.DropTable(
                name: "ChatGroups");

            migrationBuilder.DropTable(
                name: "ChatSubscribers");
        }
    }
}
