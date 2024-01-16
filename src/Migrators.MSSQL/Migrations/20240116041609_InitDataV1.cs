using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitDataV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModificatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategory",
                        column: x => x.ParentCategory,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    TagName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artwork",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Privacy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModificatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artwork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artwork_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    BlockingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => new { x.BlockingId, x.BlockedId });
                    table.ForeignKey(
                        name: "FK_Block_Account_BlockedId",
                        column: x => x.BlockedId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Block_Account_BlockingId",
                        column: x => x.BlockingId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatBox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AccountId_1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId_2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatBox_Account_AccountId_1",
                        column: x => x.AccountId_1,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatBox_Account_AccountId_2",
                        column: x => x.AccountId_2,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Privacy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collection_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => new { x.AccountId, x.FollowerId });
                    table.ForeignKey(
                        name: "FK_Follow_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follow_Account_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    SentToAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NotifyType = table.Column<int>(type: "int", nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    NotificatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Account_SentToAccount",
                        column: x => x.SentToAccount,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ReportType = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportEntity = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    ReportedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ServiceName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumberOfConcept = table.Column<int>(type: "int", nullable: false),
                    NumberOfRevision = table.Column<int>(type: "int", nullable: false),
                    StartingPrice = table.Column<double>(type: "float", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModificatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ATid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RTid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    WithdrawMethod = table.Column<int>(type: "int", nullable: false),
                    WithdrawInformation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    AssetTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AssetName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    LastModificatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryArtworkDetail",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryArtworkDetail", x => new { x.CategoryId, x.ArtworkId });
                    table.ForeignKey(
                        name: "FK_CategoryArtworkDetail_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryArtworkDetail_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModificatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Comment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    LastModificatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.AccountId, x.ArtworkId });
                    table.ForeignKey(
                        name: "FK_Like_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagDetail",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagDetail", x => new { x.TagId, x.ArtworkId });
                    table.ForeignKey(
                        name: "FK_TagDetail_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagDetail_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ChatBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_ChatBox_ChatBoxId",
                        column: x => x.ChatBoxId,
                        principalTable: "ChatBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookmark",
                columns: table => new
                {
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmark", x => new { x.ArtworkId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_Bookmark_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookmark_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryServiceDetail",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryServiceDetail", x => new { x.CategoryId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_CategoryServiceDetail_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryServiceDetail_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ChatBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InitialPrice = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ProposalStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposal_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposal_ChatBox_ChatBoxId",
                        column: x => x.ChatBoxId,
                        principalTable: "ChatBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposal_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Timeline = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Request_ChatBox_ChatBoxId",
                        column: x => x.ChatBoxId,
                        principalTable: "ChatBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetail",
                columns: table => new
                {
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetail", x => new { x.ServiceId, x.ArtworkId });
                    table.ForeignKey(
                        name: "FK_ServiceDetail_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDetail_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    TransactionStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletHistory_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposalAsset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Concept = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Version = table.Column<double>(type: "float", nullable: false),
                    AssetLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposalAsset_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vote = table.Column<double>(type: "float", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TransactionStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Avatar", "Bio", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "Fullname", "LastModificatedBy", "LastModificatedOn", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), "https://i.pinimg.com/564x/6c/a3/4b/6ca34beddfbd279418c915d2258d698b.jpg", null, null, new DateTime(2024, 1, 16, 11, 16, 9, 634, DateTimeKind.Local).AddTicks(3537), null, null, "thong@example.com", "Nguyễn Trung Thông", null, new DateTime(2024, 1, 16, 11, 16, 9, 634, DateTimeKind.Local).AddTicks(3538), "BCpA8roVqTkU54PKIBXU4Iyl3YqyF5wYPagAXZ/1HYFEB9dh", 2, "thong" },
                    { new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), "https://i.pinimg.com/564x/ed/de/aa/eddeaaf250c19489e25bd0a2dd3e7756.jpg", null, null, new DateTime(2024, 1, 16, 11, 16, 9, 628, DateTimeKind.Local).AddTicks(9861), null, null, "lamlam@example.com", "Trúc Lam Võ", null, new DateTime(2024, 1, 16, 11, 16, 9, 628, DateTimeKind.Local).AddTicks(9864), "P9i8PUWQ4DnT6Dnstg7HEXTlnFUDoZFTNJopEJ4UxxoK3zRn", 2, "lamlam" },
                    { new Guid("7d580000-c214-88a4-5141-08dc1445b3e3"), "https://i.pinimg.com/564x/0e/4b/7a/0e4b7aef4834bfc646775d8fd3705825.jpg", null, null, new DateTime(2024, 1, 16, 11, 16, 9, 642, DateTimeKind.Local).AddTicks(4141), null, null, "admin@example.com", "Quản trị viên hệ thống", null, new DateTime(2024, 1, 16, 11, 16, 9, 642, DateTimeKind.Local).AddTicks(4141), "tmb/sYLga1PDxUtRiIEU4YJtaG2HN58av/VA2S/8v19GLbSx", 0, "admin" },
                    { new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), "https://i.pinimg.com/736x/81/3c/57/813c57fcb969d58fac1672594da05532.jpg", null, null, new DateTime(2024, 1, 16, 11, 16, 9, 637, DateTimeKind.Local).AddTicks(584), null, null, "phu@example.com", "Huỳnh Vạn Phú", null, new DateTime(2024, 1, 16, 11, 16, 9, 637, DateTimeKind.Local).AddTicks(584), "44p9oaVq2ED8i7Q6vKIaS//ynDYqhnLcHcX/W7sDDIa1m3v/", 2, "phuhuynh" },
                    { new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), "https://i.pinimg.com/564x/14/b0/3b/14b03bdcab41f458dd15c9f5669cef2d.jpg", null, null, new DateTime(2024, 1, 16, 11, 16, 9, 631, DateTimeKind.Local).AddTicks(6615), null, null, "hoanganh@example.com", "Đặng Hoàng Anh", null, new DateTime(2024, 1, 16, 11, 16, 9, 631, DateTimeKind.Local).AddTicks(6615), "RZX95v+qA/O+EKXLkilrMbLW+cKQ7jekrOE9uwWE4fSupbQM", 2, "hoanganh" },
                    { new Guid("7d580000-c214-88a4-cc1d-08dc1445b3e0"), "https://i.pinimg.com/564x/be/85/2f/be852fd4ad1cb76b83ce962f618895bd.jpg", null, null, new DateTime(2024, 1, 16, 11, 16, 9, 626, DateTimeKind.Local).AddTicks(2967), null, null, "user@example.com", "Người dùng mặc định", null, new DateTime(2024, 1, 16, 11, 16, 9, 626, DateTimeKind.Local).AddTicks(2985), "/Yvo/zNSPcJB+6Roi0BD6gR/tx9tPXSqrslB+3Zy0rwOC2lA", 2, "user" },
                    { new Guid("7d580000-c214-88a4-e5f6-08dc1445b3e2"), "https://i.pinimg.com/564x/7d/cd/61/7dcd61988b0add83b5ba9a656512593e.jpg", null, null, new DateTime(2024, 1, 16, 11, 16, 9, 639, DateTimeKind.Local).AddTicks(7415), null, null, "mod@example.com", "Kiểm soát viên", null, new DateTime(2024, 1, 16, 11, 16, 9, 639, DateTimeKind.Local).AddTicks(7415), "/yI89eEokmyCtc8FQcA8Salpuc2Gnv6+xvWUi9jfF3D56K8l", 1, "mod" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "ParentCategory" },
                values: new object[,]
                {
                    { new Guid("1b7a9c43-d8d3-4a64-9c4b-c5823e22a3f3"), "In ấn", null },
                    { new Guid("490f5bd6-1a32-4e9b-9236-5794c97526e1"), "Đồ họa 3D", null },
                    { new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e"), "Minh hoạ", null },
                    { new Guid("6dfe4e90-98e1-43e5-b2c1-ef7fd9e6fb67"), "Đồ họa chuyển động", null },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5"), "Nhiếp ảnh", null },
                    { new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a"), "Thiết kế đồ họa", null },
                    { new Guid("a6d7e9b2-85af-4f01-bd97-2c3bbd3a7e09"), "Kiến trúc", null },
                    { new Guid("c51283f7-6d58-4a70-9bf2-13d3b5bc8456"), "UI/UX", null },
                    { new Guid("ced1a254-ecac-47e4-ae18-5d23c2711bf5"), "Nghệ thuật số", null },
                    { new Guid("e839e134-9158-4d2d-a04f-503fdd2d2751"), "Quảng cáo", null },
                    { new Guid("e839e134-9158-4d2d-a04f-503fdd2d275e"), "Thiết kế sản phẩm", null },
                    { new Guid("f4e81ac1-1a6e-47c3-92fc-7a54ae95d689"), "Thời trang", null }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec1"), "Màu sắc" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec2"), "Trừu tượng" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec3"), "Phong cảnh" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec4"), "Thiên nhiên" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5"), "Hình học" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec6"), "Anime" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec7"), "Chân dung" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec8"), "Sáng tạo" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec9"), "Kỹ thuật số" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95eca"), "Graffiti" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecb"), "Dự án cá nhân" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecc"), "Nghệ thuật số hóa" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecd"), "Thể thao" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ece"), "Chủ đề xã hội" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecf"), "Vintage" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed0"), "Ảo" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed1"), "Minimalism" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed2"), "Figma" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed3"), "Mèo" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed4"), "Động vật hoang dã" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed5"), "Nền tảng" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed6"), "Nghệ thuật đương đại" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed7"), "Chủ đề khoa học" },
                    { new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed8"), "Giao thông" }
                });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "LastModificatedBy", "Privacy", "Thumbnail", "ThumbnailName", "Title" },
                values: new object[,]
                {
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f5e"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Đây là tuyển tập tâm huyết của mình, nhớ like và comment để ủng hộ mình nha", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "35966d1a-9b08-4743-b1c3-474a58350f5e_t.jpg", "Tuyển tập minh hoạ sách tâm lý" },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Đây là tuyển tập tâm huyết của mình, nhớ like và comment để ủng hộ mình nha", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "35966d1a-9b08-4743-b1c3-474a58350f6e_t.jpg", "Tuyển tập minh hoạ sách tâm lý" },
                    { new Guid("3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Bức tranh thể hiện sự huyền bí và phức tạp của tâm trí con người", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "3f22b8d1-0d5b-4da0-9f4e-876c1586c5b3_t.jpg", "Sự huyền bí của tâm trí" },
                    { new Guid("56f86f82-4622-4710-8d1c-b8c1664711a2"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tác phẩm thể hiện sự ảnh hưởng của quá khứ đối với hiện tại", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "56f86f82-4622-4710-8d1c-b8c1664711a2_t.jpg", "Dấu vết của quá khứ" },
                    { new Guid("5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tượng trưng cho sự đồng hành và hỗ trợ của đối tác tâm lý", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "5fdaf3c7-6c68-45fb-9610-b67b8a1d0bd0_t.jpg", "Sự đồng hành của đối tác tâm lý" },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7d580000-c214-88a4-7ad3-08dc1445b3e2"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 0, "https://i.pximg.net/c/250x250_80_a2/custom-thumb/img/2023/11/13/18/56/54/113380427_p0_custom1200.jpg", "72fbdead-0704-4f69-82ec-0cd09218fef9_t.jpg", "Touhou Project Image Cute" },
                    { new Guid("7a04e5c7-ffea-45da-80d2-875b0a0b8d35"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Bức tranh thể hiện hành trình tìm kiếm và theo đuổi đam mê trong cuộc sống", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "7a04e5c7-ffea-45da-80d2-875b0a0b8d35_t.jpg", "Hành trình tìm kiếm đam mê" },
                    { new Guid("8c24a1d8-9f14-44cd-9e86-2c542d14413c"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Minh họa cho hành trình không ngừng của sự sáng tạo", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "8c24a1d8-9f14-44cd-9e86-2c542d14413c_t.jpg", "Hành trình của sự sáng tạo" },
                    { new Guid("91f9a14d-66a9-43da-8e43-2579baf7c8a7"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Minh họa cho tâm trạng lạc quan và hy vọng về tương lai", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "91f9a14d-66a9-43da-8e43-2579baf7c8a7_t.jpg", "Sự lạc quan của tương lai" },
                    { new Guid("9202bb7f-71f3-4641-b1d4-9bc858416d84"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tượng trưng cho vũ trụ rộng lớn và không gian của tâm trí con người", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "9202bb7f-71f3-4641-b1d4-9bc858416d84_t.jpg", "Vũ trụ tâm trí" },
                    { new Guid("ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sách tìm hiểu về những bí mật đằng sau tâm lý con người", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "ab5e5cda-2b09-4ba1-8d6c-74f169c8a9a3_t.jpg", "Bí mật tâm lý học" },
                    { new Guid("b1c16326-7a16-4f6b-a76d-cf15ce2c71d3"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tượng trưng cho nơi gặp gỡ và kết nối tâm hồn con người", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "b1c16326-7a16-4f6b-a76d-cf15ce2c71d3_t.jpg", "Nơi gặp gỡ tâm hồn" },
                    { new Guid("e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Khám phá sâu hơn về cảm xúc và tâm trạng trong cuộc sống", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "e74b9b62-1f9e-4a12-97e1-8c79c9a2aeb7_t.jpg", "Hành trình sâu cảm xúc" },
                    { new Guid("f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tượng trưng cho biển cả tri thức sâu rộng và không ngừng mở rộng", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "f7e4df8d-b4b7-4a39-8f2b-74f5d4b512a4_t.jpg", "Biển cả của tri thức" },
                    { new Guid("fb7c52b9-64f8-4e84-a992-14b8bcb6ea35"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Hình ảnh tượng trưng cho ánh sáng và năng lượng bên trong chúng ta", null, 0, "https://hiu.vn/wp-content/uploads/2022/02/review-nganh-tam-ly-hoc-1024x768.jpg", "fb7c52b9-64f8-4e84-a992-14b8bcb6ea35_t.jpg", "Mặt trời bên trong" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeliveryTime", "Description", "LastModificatedBy", "LastModificatedOn", "NumberOfConcept", "NumberOfRevision", "ServiceName", "StartingPrice", "Thumbnail" },
                values: new object[] { new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532"), new Guid("7d580000-c214-88a4-3886-08dc1445b3e1"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "2 - 3 tuần", "Mô tả Dịch vụ thiết kế", null, new DateTime(2024, 1, 16, 11, 16, 9, 656, DateTimeKind.Local).AddTicks(1390), 2, 2, "Dịch vụ thiết kế", 100000.0, "https://3.imimg.com/data3/SQ/DN/MY-16602737/banner-design-services.png" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "ArtworkId", "AssetName", "AssetTitle", "DeletedBy", "DeletedOn", "Description", "LastModificatedBy", "Location", "Order", "Price" },
                values: new object[,]
                {
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "PTS_1.zip", "Touhout PTS", null, null, "Tặng các bạn", null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 0, 0.0 },
                    { new Guid("8225058f-9f38-49f2-a68d-d9237b0a550f"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "PTS_1.zip", "Tàu hũ ZIP", null, null, null, null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 0, 72000.0 },
                    { new Guid("ec114537-eadb-49d4-ad49-675d06ce6ccc"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "PTS_1.zip", "File PTS tuyển tập minh hoạ sách tâm lý", null, null, "Mua đê", null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 0, 100000.0 }
                });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("1b7a9c43-d8d3-4a64-9c4b-c5823e22a3f3") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e") },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("57dbdb36-f9ad-4926-9fb6-2df15969ed5e") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a") },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("ced1a254-ecac-47e4-ae18-5d23c2711bf5") }
                });

            migrationBuilder.InsertData(
                table: "CategoryServiceDetail",
                columns: new[] { "CategoryId", "ServiceId" },
                values: new object[] { new Guid("8b0f2e91-9a3c-4d6e-b8e7-23c5a41a2f0a"), new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532") });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ArtworkId", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "LastModificatedBy", "ReplyId" },
                values: new object[,]
                {
                    { new Guid("457f3324-5594-4526-ab24-25c63e5ee7bd"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "10 điểm", new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("5075efb6-cd23-4cea-8882-2f5669c70ea7"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "Like", new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("74524095-a079-44b0-9e2a-a8e67ae6b06e"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "Minh hoạ xuất sắc", new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("8ea03178-3cc7-40e5-9344-a6a96c492a42"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "Đây là một bức tranh rất đẹp", new Guid("7d580000-c214-88a4-a3f1-08dc1445b3e1"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("e05281fb-cfb2-4dc3-9be8-d8ae59016f9a"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "Cute and funny", new Guid("7d580000-c214-88a4-0f12-08dc1445b3e2"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("01aa2232-7628-4227-b034-1c1a32cad359"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "35966d1a-9b08-4743-b1c3-474a58350f6e_i1.jpg", null, null, "https://www.dtv-ebook.com/images/files_2/2023/022023/tam-ly-hoc-toi-pham-phac-hoa-chan-dung-ke-pham-toi-diep-hong-vu.jpg", 0 },
                    { new Guid("36208d9b-471a-4a88-be28-adabfd1f2ae5"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "72fbdead-0704-4f69-82ec-0cd09218fef9_i0.jpg", null, null, "https://i.pximg.net/img-original/img/2023/11/13/18/56/54/113380427_p0.png", 0 },
                    { new Guid("5d96552b-ff92-4064-8858-5e1e96ee9899"), new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), "72fbdead-0704-4f69-82ec-0cd09218fef9_i1.jpg", null, null, "https://i.pximg.net/img-original/img/2023/11/13/18/56/54/113380427_p1.png", 1 },
                    { new Guid("ae8fb7be-5c63-481e-b997-2ada5ac5392b"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "35966d1a-9b08-4743-b1c3-474a58350f6e_i2.jpg", null, null, "https://lh3.googleusercontent.com/QKQqZt0RivsBmyjwFI8EomO6YZ2-hnSsiwLdKG9btAiNhVjiwpKtzTiULFqTRCo5JUOe5t8f6Be_sZ9ZBYRD7v3EYwqzlkomHabN_LqntP61rVbqqk9wuQqgVY4Dmk7JseAHmjbNWRacbMJynaBXgCoYvcQzAuYPOgNj-P2CAEWroKZcieC2GDyal2x02Cw0izhqYNCnJAQLnEPSErSXgYNBoSb3KlmjHcev9zq2KXRaorp04_aKLN5-iewZ27ee9OWmSuwfvnGgjSK98rKdtGfnqw5U_1cp1R89brso1E8VCIhFGfRTKijJMdCtjE3VbpyO_3vI46D5UVbJZB3N-c0-DulKgbP1EFp5p_wbgBwL2AQVAgQCB2TJ1IS_hVKqVS1GZ3xsCleYb7xTkaqqcojQIbR1GYMxirT_u2jU6xHq6ycB2w6UPCo_DZJfVhieyZXzjpIa92pN-6UM4I-Ou54BnFpvANrOxfOWxblViYR43PrSdHgu5XGGQYg2SYKvuAqbzkpOLpcnyRQBxDPV6bCMURXDTvnmRQj1Rl_14MEW278wjOe-D39mATYeEO6Xfq445Wu9SUEcXd40soLtSNcun92XJ-j_0Dyr1Dd2argkutkMXgiqRHyZxN1hfadB_T1xQ3Ln9TA8oSRrYEmoUIXi4iS9XD08kj5FZf-slMLA_KQeYT7F2Alkx11IBq2aahNUlf1FTWykZVpyxAr0DNjCypS44Lbmqsdw7xfQzKT8WrLR=w400-h500-no", 1 },
                    { new Guid("ff16271c-c04a-4cec-b6f1-04b555659b5a"), new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), "35966d1a-9b08-4743-b1c3-474a58350f6e_i3.jpg", null, null, "https://vietbooks.info/attachments/upload_2023-2-3_11-29-1-png.19599/", 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiceDetail",
                columns: new[] { "ArtworkId", "ServiceId" },
                values: new object[] { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("1c8542d4-41bd-492b-9d21-905c6a8b0532") });

            migrationBuilder.InsertData(
                table: "TagDetail",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec2") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec5") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec8") },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ec9") },
                    { new Guid("35966d1a-9b08-4743-b1c3-474a58350f6e"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ecb") },
                    { new Guid("72fbdead-0704-4f69-82ec-0cd09218fef9"), new Guid("7cfdb5fc-7fe7-48e9-a1a2-78b788f95ed6") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Username",
                table: "Account",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_CreatedBy",
                table: "Artwork",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ArtworkId",
                table: "Asset",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Block_BlockedId",
                table: "Block",
                column: "BlockedId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_CollectionId",
                table: "Bookmark",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategory",
                table: "Category",
                column: "ParentCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryArtworkDetail_ArtworkId",
                table: "CategoryArtworkDetail",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryServiceDetail_ServiceId",
                table: "CategoryServiceDetail",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBox_AccountId_1",
                table: "ChatBox",
                column: "AccountId_1");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBox_AccountId_2",
                table: "ChatBox",
                column: "AccountId_2");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_CreatedBy",
                table: "Collection",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ArtworkId",
                table: "Comment",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatedBy",
                table: "Comment",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ReplyId",
                table: "Comment",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_FollowerId",
                table: "Follow",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ArtworkId",
                table: "Image",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_ArtworkId",
                table: "Like",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatBoxId",
                table: "Message",
                column: "ChatBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_CreatedBy",
                table: "Message",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_SentToAccount",
                table: "Notification",
                column: "SentToAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_ChatBoxId",
                table: "Proposal",
                column: "ChatBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_CreatedBy",
                table: "Proposal",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_ServiceId",
                table: "Proposal",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalAsset_ProposalId",
                table: "ProposalAsset",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CreatedBy",
                table: "Report",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ChatBoxId",
                table: "Request",
                column: "ChatBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_CreatedBy",
                table: "Request",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ServiceId",
                table: "Request",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_CreatedBy",
                table: "Review",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProposalId",
                table: "Review",
                column: "ProposalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_CreatedBy",
                table: "Service",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetail_ArtworkId",
                table: "ServiceDetail",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagName",
                table: "Tag",
                column: "TagName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagDetail_ArtworkId",
                table: "TagDetail",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_AccountId",
                table: "TransactionHistory",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_AssetId",
                table: "TransactionHistory",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_ProposalId",
                table: "TransactionHistory",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_ATid",
                table: "UserToken",
                column: "ATid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_RTid",
                table: "UserToken",
                column: "RTid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_AccountId",
                table: "Wallet",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletHistory_WalletId",
                table: "WalletHistory",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Bookmark");

            migrationBuilder.DropTable(
                name: "CategoryArtworkDetail");

            migrationBuilder.DropTable(
                name: "CategoryServiceDetail");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProposalAsset");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "ServiceDetail");

            migrationBuilder.DropTable(
                name: "TagDetail");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "WalletHistory");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Proposal");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Artwork");

            migrationBuilder.DropTable(
                name: "ChatBox");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
