using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddDataV1 : Migration
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
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    Privacy = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
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
                    TargetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "WalletHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    TransactionStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    AppTransId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletHistory_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ArtworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ImageHash = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
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
                    TargetDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfConcept = table.Column<int>(type: "int", nullable: false),
                    NumberOfRevision = table.Column<int>(type: "int", nullable: false),
                    InitialPrice = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ProposalStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    OrdererId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Budget = table.Column<double>(type: "float", nullable: false),
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
                name: "Milestone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilestoneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Milestone_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Milestone_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposalAsset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProposalAssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_TransactionHistory_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Account",
                        principalColumn: "Id");
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
                columns: new[] { "Id", "Avatar", "Bio", "Birthdate", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "Fullname", "LastModificatedBy", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "https://i.pinimg.com/564x/ed/de/aa/eddeaaf250c19489e25bd0a2dd3e7756.jpg", "Tôi là người dùng mặc định", new DateTime(2000, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 14, 12, 37, 42, 345, DateTimeKind.Local), null, null, "user@example.com", "Người dùng mặc định", null, "/Yvo/zNSPcJB+6Roi0BD6gR/tx9tPXSqrslB+3Zy0rwOC2lA", 2, "user" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "https://i.pinimg.com/564x/be/85/2f/be852fd4ad1cb76b83ce962f618895bd.jpg", "Tôi là Trúc Lam Võ, tôi là một nghệ sĩ đầy tài năng", new DateTime(2002, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 15, 17, 15, 47, 890, DateTimeKind.Local), null, null, "lamlam@example.com", "Trúc Lam Võ", null, "P9i8PUWQ4DnT6Dnstg7HEXTlnFUDoZFTNJopEJ4UxxoK3zRn", 2, "lamlam" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "https://i.pinimg.com/564x/14/b0/3b/14b03bdcab41f458dd15c9f5669cef2d.jpg", "Tôi là Đặng Hoàng Anh, tôi là một nghệ sĩ đầy tài năng", new DateTime(2002, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 21, 19, 20, 47, 890, DateTimeKind.Local), null, null, "hoanganh@example.com", "Đặng Hoàng Anh", null, "RZX95v+qA/O+EKXLkilrMbLW+cKQ7jekrOE9uwWE4fSupbQM", 2, "hoanganh" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "https://i.pinimg.com/564x/6c/a3/4b/6ca34beddfbd279418c915d2258d698b.jpg", "Tôi là Nguyễn Trung Thông, tôi là một nghệ sĩ đầy tài năng", new DateTime(2002, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 27, 19, 23, 47, 890, DateTimeKind.Local), null, null, "thong@example.com", "Nguyễn Trung Thông", null, "BCpA8roVqTkU54PKIBXU4Iyl3YqyF5wYPagAXZ/1HYFEB9dh", 2, "thong" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "https://i.pinimg.com/736x/81/3c/57/813c57fcb969d58fac1672594da05532.jpg", "Tôi là Huỳnh Vạn Phú, tôi là một nghệ sĩ đầy tài năng", new DateTime(2002, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 30, 10, 21, 47, 890, DateTimeKind.Local), null, null, "phu@example.com", "Huỳnh Vạn Phú", null, "44p9oaVq2ED8i7Q6vKIaS//ynDYqhnLcHcX/W7sDDIa1m3v/", 2, "phuhuynh" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "https://i.pinimg.com/564x/7d/cd/61/7dcd61988b0add83b5ba9a656512593e.jpg", "Tôi là kiểm soát viên hệ thống", new DateTime(2001, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 14, 12, 37, 42, 345, DateTimeKind.Local), null, null, "mod@example.com", "Kiểm soát viên", null, "/yI89eEokmyCtc8FQcA8Salpuc2Gnv6+xvWUi9jfF3D56K8l", 1, "mod" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "https://i.pinimg.com/564x/0e/4b/7a/0e4b7aef4834bfc646775d8fd3705825.jpg", "Tôi là quản trị viên hệ thống", new DateTime(2000, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "admin@example.com", "Quản trị viên hệ thống", null, "tmb/sYLga1PDxUtRiIEU4YJtaG2HN58av/VA2S/8v19GLbSx", 0, "admin" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "https://i.pinimg.com/564x/79/ba/4f/79ba4f6c73168efb975a2d43cc4272a3.jpg", "Tôi là một thiết kế UI/UX tài năng, đã có nhiều dự án thành công với các công ty lớn, cũng là người sáng lập một công ty thiết kế đồ họa.", new DateTime(2002, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "nguyenhoang@example.com", "Nguyễn Hoàng", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "nguyenhoang" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "https://i.pinimg.com/564x/79/ba/4f/79ba4f6c73168efb975a2d43cc4272a3.jpg", "Tôi là một nhà thiết kế web có kinh nghiệm, đã tham gia vào nhiều dự án phức tạp và mang lại sự sáng tạo đặc biệt.", new DateTime(2002, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "tranminh@example.com", "Trần Minh", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "tranminh" },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "https://i.pinimg.com/564x/62/4a/2f/624a2fda3e0da8e55b4ea60b0949affa.jpg", "Tôi là một thiết kế 2D và 3D, đã tạo ra nhiều tác phẩm ấn tượng trong lĩnh vực phim hoạt hình và trò chơi điện tử.", new DateTime(2000, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "phamthanh@example.com", "Phạm Thanh", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "phamthanh" },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), "https://i.pinimg.com/564x/8f/52/88/8f5288392e58e7f69adecfdd1bb1d896.jpg", "Tôi là một họa sĩ chuyên về tranh kỹ thuật số, đã có nhiều triển lãm cá nhân và tham gia vào dự án nghệ thuật trên toàn thế giới.", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "ngothanhtu@example.com", "Ngô Thanh Tú", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "ngothanhtu" },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), "https://i.pinimg.com/564x/ad/c2/95/adc2953d7533371d1cdb95303d70babe.jpg", "Tôi là một thiết kế đồ họa sáng tạo, đã tham gia vào nhiều dự án quảng cáo và branding cho các thương hiệu lớn.", new DateTime(2002, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "truongthu@example.com", "Trương Thu", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "truongthu" },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), "https://i.pinimg.com/564x/9c/28/19/9c2819e41426236d748392299cd20246.jpg", "Tôi là một nhiếp ảnh gia có tên tuổi, đã chụp nhiều bức ảnh độc đáo về văn hóa và cảnh đẹp Việt Nam.", new DateTime(2002, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "levan@example.com", "Lê Văn", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "levan" },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), "https://i.pinimg.com/564x/ae/ca/78/aeca78f2453767acdbd8398c4f310025.jpg", "Tôi là một nhà thiết kế đồ họa sáng tạo, đã tham gia vào nhiều dự án quảng cáo, in ấn và branding.", new DateTime(2002, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "nguyenminh@example.com", "Nguyễn Minh", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "nguyenminh" },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), "https://i.pinimg.com/564x/2a/1c/40/2a1c400fa2d814b78ed36fd21a5316f5.jpg", "Tôi là một họa sĩ có gu thẩm mỹ độc đáo, tạo ra những tác phẩm nghệ thuật đa dạng và phong phú.", new DateTime(2002, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 9, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "hoangtuan@example.com", "Hoàng Tuấn", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "hoangtuan" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "https://i.pinimg.com/564x/10/3a/ed/103aed482f200ba1af9a50a2392a83f0.jpg", "Tôi là một thiết kế đồ họa trẻ tuổi nhưng tài năng, đã tham gia vào nhiều dự án sáng tạo và độc đáo.", new DateTime(1999, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "buiduong@example.com", "Bùi Dương", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "buiduong" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "https://i.pinimg.com/564x/17/f4/97/17f497af6f6b67bd9dbcb93c04dced89.jpg", "Tôi là một họa sĩ chuyên về tranh nghệ thuật, tạo ra những tác phẩm tươi sáng và lôi cuốn.", new DateTime(2003, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "phamha@example.com", "Phạm Hà", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "phamha" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "https://i.pinimg.com/564x/ba/74/40/ba744092fe6e7222d44a5e89cf483d6d.jpg", "Tôi là là một thiết kế UI/UX đam mê và sáng tạo, đã tham gia vào nhiều dự án thành công trong lĩnh vực công nghệ.", new DateTime(2002, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "doantrang@example.com", "Đoàn Trang", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "doantrang" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "https://i.pinimg.com/564x/de/09/b1/de09b1839700e9988e605df833a5450a.jpg", "Tôi là một nghệ sĩ 3D tài năng, đã tham gia vào việc tạo ra các mô hình 3D ấn tượng cho phim và trò chơi.", new DateTime(2002, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "tranduc@example.com", "Trần Đức", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "tranduc" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "https://i.pinimg.com/564x/1e/a0/59/1ea05967bf1e5e2054aaecd109a3c662.jpg", "Tôi là một nhà thiết kế đồ họa có tầm nhìn sáng tạo, đã đạt được nhiều giải thưởng trong ngành.", new DateTime(2003, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "nguyenhieu@example.com", "Nguyễn Hiếu", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "nguyenhieu" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "https://i.pinimg.com/564x/7b/78/42/7b784268d117a6d57a8d9a83c7eaa977.jpg", "Tôi là một họa sĩ trẻ có sức sáng tạo và tinh thần nghệ thuật cao, đã tham gia vào nhiều dự án nghệ thuật và thiết kế.", new DateTime(2002, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "vuthao@example.com", "Vũ Thảo", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "vuthao" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "https://i.pinimg.com/564x/7b/78/42/7b784268d117a6d57a8d9a83c7eaa977.jpg", "Tôi là một nhà thiết kế đồ họa có kinh nghiệm, đã tham gia vào việc phát triển các ứng dụng di động và giao diện người dùng.", new DateTime(2004, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "nguyentien@example.com", "Nguyễn Tiến", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "nguyentien" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "https://i.pinimg.com/564x/f9/7f/c4/f97fc4762b0ca1c3ba76c3b2e6c5041c.jpg", "Tôi là một họa sĩ nổi tiếng với phong cách nghệ thuật độc đáo và sáng tạo. Đã tham gia vào nhiều triển lãm nghệ thuật quốc tế và được biết đến với các tác phẩm nổi bật.", new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 10, 2, 10, 21, 47, 890, DateTimeKind.Local), null, null, "vudang@example.com", "Vũ Đăng", null, "A5tzNn90k1cgMCIWicwomDz/Wb1/BAWIDIVelEKhM6lHvuwh", 2, "vudang" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "ParentCategory" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Minh hoạ", null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Thiết kế đồ họa", null },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "UI/UX", null },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Kiến trúc", null },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Thời trang", null },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Đồ họa chuyển động", null },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "In ấn", null },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Đồ họa 3D", null },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Nghệ thuật số", null },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "Nhiếp ảnh", null },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), "Thiết kế sản phẩm", null },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), "Quảng cáo", null }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Màu sắc" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Trừu tượng" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Phong cảnh" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Thiên nhiên" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Hình học" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Anime" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Chân dung" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sáng tạo" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Kỹ thuật số" },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "Graffiti" },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), "Dự án cá nhân" },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), "Nghệ thuật số hóa" },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), "Thể thao" },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), "Chủ đề xã hội" },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), "Vintage" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Ảo" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Minimalism" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Figma" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Mèo" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Động vật hoang dã" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Nền tảng" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Nghệ thuật đương đại" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Chủ đề khoa học" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "Giao thông" }
                });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "Id", "CommentCount", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "LastModificatedBy", "LikeCount", "Privacy", "State", "Thumbnail", "ThumbnailName", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 2, 9, 37, 42, 345, DateTimeKind.Local), null, null, "Tuyển tập những bức vẽ về hoàng hôn", null, 8, 0, 1, "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain", "00000000-0000-0000-0000-000000000001_t.jpg", "Hoàng hôn rực nắng", 99 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 3, 22, 20, 45, 890, DateTimeKind.Local), null, null, "Khám phá sâu hơn về cảm xúc và tâm trạng trong cuộc sống", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn", "00000000-0000-0000-0000-000000000001_t.jpg", "Hành trình sâu cảm xúc", 327 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 4, 20, 55, 30, 456, DateTimeKind.Local), null, null, "Minh họa những cuộc chiến tiêu biểu của thời đại", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.k0SSs9Qn3tHNvlcMdMrG?w=1024&h=1024&rs=1&pid=ImgDetMain", "00000000-0000-0000-0000-000000000002_t.jpg", "Vẻ đẹp của lịch sử", 638 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 5, 15, 30, 3, 678, DateTimeKind.Local), null, null, "Tác phẩm thể hiện sự ảnh hưởng của quá khứ đối với hiện tại", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.Oe0vi0jHSKaHn5DZ267N?w=1024&h=1024&rs=1&pid=ImgDetMain", "00000000-0000-0000-0000-000000000004_t.jpg", "Dấu vết của quá khứ", 23 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 6, 7, 30, 15, 567, DateTimeKind.Local), null, null, "Minh họa cho hành trình không ngừng của sự sáng tạo", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn", "00000000-0000-0000-0000-000000000005_t.jpg", "Hành trình của sự sáng tạo", 779 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 7, 12, 40, 28, 901, DateTimeKind.Local), null, null, "Tượng trưng cho sự đồng hành và hỗ trợ của đối tác tâm lý", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn", "00000000-0000-0000-0000-000000000006_t.jpg", "Sự đồng hành của đối tác tâm lý", 245 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 9, 1, 30, 15, 567, DateTimeKind.Local), null, null, "Hình ảnh tượng trưng cho ánh sáng và năng lượng bên trong chúng ta", null, 0, 0, 1, "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn", "00000000-0000-0000-0000-000000000007_t.jpg", "Mặt trời bên trong", 356 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 1, 15, 30, 3, 678, DateTimeKind.Local), null, null, "Đây là tuyển tập tâm huyết của mình, nhớ like và comment để ủng hộ mình nha", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.yy76iMmgUCmXetlfQxqn?w=1024&h=1024&rs=1&pid=ImgDetMain", "00000000-0000-0000-0000-000000000008_t.jpg", "Tuyển tập minh hoạ sách tâm lý", 342 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 10, 4, 20, 10, 234, DateTimeKind.Local), null, null, "Minh họa cho tâm trạng lạc quan và hy vọng về tương lai", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn", "00000000-0000-0000-0000-000000000009_t.jpg", "Sự lạc quan của tương lai", 86 },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 10, 20, 55, 30, 456, DateTimeKind.Local), null, null, "Tượng trưng cho nơi gặp gỡ và kết nối tâm hồn con người", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn", "00000000-0000-0000-0000-00000000000a_t.jpg", "Nơi gặp gỡ tâm hồn", 145 },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 11, 15, 30, 3, 678, DateTimeKind.Local), null, null, "Tượng trưng cho vũ trụ rộng lớn và không gian của tâm trí con người", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain", "00000000-0000-0000-0000-00000000000b_t.jpg", "Vũ trụ tâm trí", 65 },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 11, 9, 37, 42, 345, DateTimeKind.Local), null, null, "Bức tranh thể hiện hành trình tìm kiếm và theo đuổi đam mê trong cuộc sống", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.MxQxUggA0RKmKdTjwAqw?pid=ImgGn", "00000000-0000-0000-0000-00000000000c_t.jpg", "Hành trình tìm kiếm đam mê", 234 },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 13, 15, 40, 28, 901, DateTimeKind.Local), null, null, "Bộ sưu tập người máy - biểu tượng của tương lai.", null, 0, 0, 1, "https://th.bing.com/th/id/OIG.D7FfBXsOQCjc28w68xZS?pid=ImgGn", "00000000-0000-0000-0000-00000000000e_t.jpg", "Kỷ nguyên mới", 123 },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), 0, new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2023, 11, 14, 15, 20, 45, 890, DateTimeKind.Local), null, null, "Cánh cụt cute", null, 0, 0, 0, "https://th.bing.com/th/id/OIG.MC3PObbEmuJhfsPJ8biQ?pid=ImgGn", "00000000-0000-0000-0000-00000000000f_t.jpg", "Tuyển tập ảnh cánh cụt cute", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 14, 17, 55, 30, 456, DateTimeKind.Local), null, null, "Tượng trưng cho biển cả tri thức sâu rộng và không ngừng mở rộng", null, 0, 0, 0, "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn", "00000000-0000-0000-0000-000000000010_t.jpg", "Biển cả của tri thức", 0 }
                });

            migrationBuilder.InsertData(
                table: "ChatBox",
                columns: new[] { "Id", "AccountId_1", "AccountId_2" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Reason", "ReportEntity", "ReportType", "State", "TargetId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 27, 15, 40, 28, 901, DateTimeKind.Local), "this is sexual harrasment", 2, 0, 0, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 12, 7, 15, 40, 28, 901, DateTimeKind.Local), "Inappropriate content", 2, 3, 1, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 12, 27, 15, 40, 28, 901, DateTimeKind.Local), "Abuse of platform", 2, 0, 2, new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 12, 28, 15, 40, 28, 901, DateTimeKind.Local), "Disallowed content", 2, 5, 0, new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 12, 29, 15, 40, 28, 901, DateTimeKind.Local), "Disallowed content", 2, 4, 0, new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 27, 15, 40, 28, 901, DateTimeKind.Local), "Not suitable", 2, 4, 0, new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 28, 15, 40, 28, 901, DateTimeKind.Local), "This is spam", 2, 2, 0, new Guid("00000000-0000-0000-0000-000000000007") }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeliveryTime", "Description", "LastModificatedBy", "LastModificatedOn", "NumberOfConcept", "NumberOfRevision", "ServiceName", "StartingPrice", "Thumbnail" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "2 - 3 tuần", "Mô tả Dịch vụ thiết kế", null, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Dịch vụ thiết kế", 100000.0, "https://3.imimg.com/data3/SQ/DN/MY-16602737/banner-design-services.png" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "4 - 6 tuần", "Mô tả Dịch vụ phát triển website", null, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Dịch vụ phát triển website", 150000.0, "https://laptopdieplinh.com/uploads/7%20c%C3%B4ng%20c%E1%BB%A5%20ph%C3%A1t%20tri%E1%BB%83n%20website%20b%E1%BA%A1n%20c%E1%BA%A7n%20bi%E1%BA%BFt%20-%200.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1 - 2 tuần", "Mô tả Dịch vụ in ấn", null, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Dịch vụ in ấn", 50000.0, "https://channel.mediacdn.vn/2022/3/17/photo-1-1647512803989607433836.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "3 - 4 tuần", "Mô tả Dịch vụ quản lý dự án", null, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Dịch vụ quản lý dự án", 120000.0, "https://www.inandaiduong.com/wp-content/uploads/2015/01/dich-vu-thiet-ke-in-an.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "AccountId", "Balance", "WithdrawInformation", "WithdrawMethod" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), 2000.0, "0902287461", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), 1000.0, "0939959417", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003"), 1000.0, "0902287462", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004"), 1000.0, "0902287463", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), 1000.0, "0902287464", 0 }
                });

            migrationBuilder.InsertData(
                table: "WalletHistory",
                columns: new[] { "Id", "Amount", "AppTransId", "CreatedBy", "CreatedOn", "PaymentMethod", "TransactionStatus", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 200.0, "240128_7635981", new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 7, 15, 30, 3, 678, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 2500.0, "180623_2054176", new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 10, 21, 20, 10, 234, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 2000.0, "210430_6849203", new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 14, 2, 59, 59, 0, DateTimeKind.Local), 0, 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 300.0, "190815_3095728", new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 12, 10, 12, 40, 28, 901, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 200.0, "220506_1478963", new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 11, 16, 9, 37, 42, 345, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 2500.0, "231112_8023456", new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 11, 29, 1, 30, 15, 567, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 1700.0, "200925_6193840", new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2023, 12, 1, 6, 59, 59, 999, DateTimeKind.Local), 0, 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 200.0, "171212_4357692", new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2023, 11, 19, 12, 40, 28, 901, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 2500.0, "160509_9270134", new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2023, 11, 29, 1, 30, 15, 567, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), 1700.0, "250321_4685027", new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2023, 12, 10, 12, 40, 28, 901, DateTimeKind.Local), 0, 1, 0 },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), 200.0, "231205_7890123", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2023, 11, 22, 12, 37, 42, 345, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), 2500.0, "200703_4567890", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2023, 11, 15, 10, 45, 20, 123, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), 1700.0, "180924_1234567", new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2023, 12, 5, 9, 37, 42, 345, DateTimeKind.Local), 0, 1, 0 },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), 3000.0, "210817_8901234", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2023, 11, 3, 17, 45, 20, 123, DateTimeKind.Local), 0, 1, 1 },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), 1500.0, "220129_5678901", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2023, 11, 17, 9, 59, 59, 0, DateTimeKind.Local), 0, 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 500.0, "160827_3456789", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2023, 11, 6, 1, 20, 45, 890, DateTimeKind.Local), 0, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "ArtworkId", "AssetName", "AssetTitle", "DeletedBy", "DeletedOn", "Description", "LastModificatedBy", "Location", "Price" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000008"), "PTS_1.zip", "File PTS tuyển tập minh hoạ sách tâm lý", null, null, "tập tin PTS tuyển tập minh hoạ sách tâm lý sẽ cung cấp một cái nhìn tổng quan và thú vị.", null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 10000.0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000e"), "PTS_1.zip", "Robot PTS", null, null, "Tặng các bạn", null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 0.0 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000000f"), "PTS_1.zip", "Canh cụt ZIP", null, null, null, null, "https://github.com/saadeghi/daisyui/archive/refs/tags/v4.5.0.zip", 12000.0 }
                });

            migrationBuilder.InsertData(
                table: "CategoryArtworkDetail",
                columns: new[] { "ArtworkId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000009") }
                });

            migrationBuilder.InsertData(
                table: "CategoryServiceDetail",
                columns: new[] { "CategoryId", "ServiceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ArtworkId", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "LastModificatedBy", "ReplyId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-00000000000e"), "Đây là một bức tranh rất đẹp", new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000e"), "Minh hoạ xuất sắc", new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000000e"), "10 điểm", new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000000f"), "Cute and funny", new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000000f"), "Like", new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ArtworkId", "ImageHash", "ImageName", "LastModificatedBy", "LastModificatedOn", "Location", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-00000000000e"), null, "00000000-0000-0000-0000-00000000000e_i1.jpg", null, null, "https://i.pinimg.com/originals/b5/7e/14/b57e14aa401d41db2072d1b0ccfbde2b.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000e"), null, "00000000-0000-0000-0000-00000000000e_i2.jpg", null, null, "https://i.pinimg.com/originals/04/b7/46/04b7460b2efef9c432dabbcda2507b71.jpg", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000000e"), null, "00000000-0000-0000-0000-00000000000e_i3.jpg", null, null, "https://i.pinimg.com/originals/d5/5e/e1/d55ee127c8dc1c7f9d94edc0ec596758.jpg", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000000f"), null, "00000000-0000-0000-0000-00000000000f_i0.jpg", null, null, "https://i.pinimg.com/originals/db/93/a1/db93a131d59201ed997d606ea33c4933.jpg", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000000f"), null, "00000000-0000-0000-0000-00000000000f_i1.jpg", null, null, "https://i.pinimg.com/originals/b5/d4/7e/b5d47e1cf4555983a8017e59409b4d4a.jpg", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000008"), null, "00000000-0000-0000-0000-000000000008_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.yy76iMmgUCmXetlfQxqn?w=1024&h=1024&rs=1&pid=ImgDetMain", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001"), null, "00000000-0000-0000-0000-000000000001_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.7WfKwqG.VAbgwQ87iaTU?w=1024&h=1024&rs=1&pid=ImgDetMain", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000002"), null, "00000000-0000-0000-0000-000000000002_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.mMOt1xWJJCHsRoPJXtHQ?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000003"), null, "00000000-0000-0000-0000-000000000003_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.k0SSs9Qn3tHNvlcMdMrG?w=1024&h=1024&rs=1&pid=ImgDetMain", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000004"), null, "00000000-0000-0000-0000-000000000004_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.Oe0vi0jHSKaHn5DZ267N?w=1024&h=1024&rs=1&pid=ImgDetMain", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000005"), null, "00000000-0000-0000-0000-000000000005_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.LTaVFacabNQc22SAk1r1?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000006"), null, "00000000-0000-0000-0000-000000000006_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.AoM9akz.gT4RMZ9R6DOh?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007"), null, "00000000-0000-0000-0000-000000000007_i0.jpg", null, null, "https://th.bing.com/th/id/OIG..gPcXaRan.FdnEjYCvT3?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000009"), null, "00000000-0000-0000-0000-000000000009_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.Uz66_wn15hsKPirpv6Pb?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-00000000000a"), null, "00000000-0000-0000-0000-00000000000a_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.78MNqZpoa6ReKmvZCHPI?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000001b"), new Guid("00000000-0000-0000-0000-00000000000b"), null, "00000000-0000-0000-0000-00000000000b_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.Iar__phrqaC3bhQLIHAZ?w=1024&h=1024&rs=1&pid=ImgDetMain", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000001d"), new Guid("00000000-0000-0000-0000-00000000000c"), null, "00000000-0000-0000-0000-00000000000c_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.MxQxUggA0RKmKdTjwAqw?pid=ImgGn", 0 },
                    { new Guid("00000000-0000-0000-0000-00000000001f"), new Guid("00000000-0000-0000-0000-000000000010"), null, "00000000-0000-0000-0000-000000000010_i0.jpg", null, null, "https://th.bing.com/th/id/OIG.5gNG99_0Acz4Y8CGOYlg?pid=ImgGn", 0 }
                });

            migrationBuilder.InsertData(
                table: "Like",
                columns: new[] { "AccountId", "ArtworkId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id", "Budget", "ChatBoxId", "CreatedBy", "CreatedOn", "Message", "RequestStatus", "ServiceId", "Timeline" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 0.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "yeu cau lam website ecommerce", 0, new Guid("00000000-0000-0000-0000-000000000001"), "2 - 3 tuần" });

            migrationBuilder.InsertData(
                table: "ServiceDetail",
                columns: new[] { "ArtworkId", "ServiceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "TagDetail",
                columns: new[] { "ArtworkId", "TagId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), new Guid("00000000-0000-0000-0000-000000000016") }
                });

            migrationBuilder.InsertData(
                table: "TransactionHistory",
                columns: new[] { "Id", "AssetId", "CreatedBy", "CreatedOn", "Detail", "Price", "ProposalId", "TransactionStatus" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 13, 22, 30, 3, 678, DateTimeKind.Local), "Mở khóa tài nguyên \"Cánh cụt ZIP\"", 12.0, null, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 15, 9, 59, 59, 0, DateTimeKind.Local), "Mở khóa tài nguyên \"File PTS tuyển tập minh hoạ sách tâm lý\"", 10.0, null, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 1, 14, 22, 30, 3, 678, DateTimeKind.Local), "Mở khóa tài nguyên \"Cánh cụt ZIP\"", 12.0, null, 1 }
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
                name: "IX_Milestone_CreatedBy",
                table: "Milestone",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_ProposalId",
                table: "Milestone",
                column: "ProposalId");

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
                name: "IX_TransactionHistory_AssetId",
                table: "TransactionHistory",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_CreatedBy",
                table: "TransactionHistory",
                column: "CreatedBy");

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
                name: "IX_WalletHistory_CreatedBy",
                table: "WalletHistory",
                column: "CreatedBy");
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
                name: "Milestone");

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
                name: "Wallet");

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
