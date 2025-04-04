using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPannel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_Actee",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_Application",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_ApplicationPackage",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_ConfigurationLock",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_ConfigurationPassword",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_ConfigurationSession",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_Mask",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_Menu",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_Permission",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_Service",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_User",
                schema: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_UserRole",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "tbApplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_Application"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RedirectUrls = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientScope = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorizationGrandType = table.Column<int>(type: "int", nullable: false),
                    IpRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAutoApprove = table.Column<bool>(type: "bit", nullable: false),
                    Scheduled = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LockEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbBiometricType",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBiometricType", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "tbOauthToken",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TokenType = table.Column<short>(type: "smallint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbOauthToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_User"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginAttempt = table.Column<int>(type: "int", nullable: false),
                    Scheduled = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TwoFactor = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbApplicationPackage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_ApplicationPackage"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbApplicationPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbApplicationPackage_tbApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "tbApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbConfigurationLock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_ConfigurationLock"),
                    CaptchaNeeded = table.Column<bool>(type: "bit", nullable: false),
                    FailedLoginAmountBeforeCaptcha = table.Column<short>(type: "smallint", nullable: false),
                    LockTimeInterval = table.Column<int>(type: "int", nullable: false),
                    LockType = table.Column<short>(type: "smallint", nullable: false),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConfigurationLock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbConfigurationLock_tbApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "tbApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbConfigurationPassword",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_ConfigurationPassword"),
                    IsComplex = table.Column<bool>(type: "bit", nullable: false),
                    MustBeChangedInFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    MustContainChar = table.Column<bool>(type: "bit", nullable: false),
                    MustContainUpperCase = table.Column<bool>(type: "bit", nullable: false),
                    IsPolicyNeeded = table.Column<bool>(type: "bit", nullable: false),
                    MinPassLength = table.Column<short>(type: "smallint", nullable: false),
                    MaxPassLength = table.Column<short>(type: "smallint", nullable: false),
                    NumericPassNotEqual = table.Column<short>(type: "smallint", nullable: false),
                    WillPassExpire = table.Column<bool>(type: "bit", nullable: false),
                    ExpireDaysAmount = table.Column<short>(type: "smallint", nullable: false),
                    RedirectToCustomUrlAfterChangePass = table.Column<bool>(type: "bit", nullable: false),
                    UrlAfterChangePass = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConfigurationPassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbConfigurationPassword_tbApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "tbApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbConfigurationSession",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_ConfigurationSession"),
                    IsConcurrentActive = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyCount = table.Column<int>(type: "int", nullable: false),
                    SessionTimeout = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConfigurationSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbConfigurationSession_tbApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "tbApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbLoginPolicy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LockTypes = table.Column<short>(type: "smallint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LockStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LockEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLoginPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbLoginPolicy_tbUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbUserBiometric",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiometricTitle = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserBiometric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbUserBiometric_tbBiometricType_BiometricTitle",
                        column: x => x.BiometricTitle,
                        principalTable: "tbBiometricType",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbUserBiometric_tbUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbActee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_Actee"),
                    Uuid = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ActeeType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StatusType = table.Column<int>(type: "int", nullable: false),
                    ApplicationPackageId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbActee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbActee_tbApplicationPackage_ApplicationPackageId",
                        column: x => x.ApplicationPackageId,
                        principalTable: "tbApplicationPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProperties",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ConfigurationPasswordId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProperties", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserProperties_tbConfigurationPassword_ConfigurationPasswordId",
                        column: x => x.ConfigurationPasswordId,
                        principalTable: "tbConfigurationPassword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProperties_tbUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbMenu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_Menu"),
                    MenuKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActeeId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbMenu_tbActee_ActeeId",
                        column: x => x.ActeeId,
                        principalTable: "tbActee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbService",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_Service"),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    ServiceKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rest = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActeeId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbService_tbActee_ActeeId",
                        column: x => x.ActeeId,
                        principalTable: "tbActee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbMask",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_Mask"),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbPermission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_Permission"),
                    ActeeId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Granting = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbPermission_tbActee_ActeeId",
                        column: x => x.ActeeId,
                        principalTable: "tbActee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Authority = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbRole_tbApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "tbApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbRole_tbPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "tbPermission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbUserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Seq_UserRole"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbUserRole_tbRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbUserRole_tbUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbActee_ApplicationPackageId",
                table: "tbActee",
                column: "ApplicationPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbApplicationPackage_ApplicationId",
                table: "tbApplicationPackage",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbConfigurationLock_ApplicationId",
                table: "tbConfigurationLock",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbConfigurationPassword_ApplicationId",
                table: "tbConfigurationPassword",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbConfigurationSession_ApplicationId",
                table: "tbConfigurationSession",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbLoginPolicy_UserId",
                table: "tbLoginPolicy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbMask_PermissionId",
                table: "tbMask",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbMenu_ActeeId",
                table: "tbMenu",
                column: "ActeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbPermission_ActeeId",
                table: "tbPermission",
                column: "ActeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbPermission_RoleId",
                table: "tbPermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbRole_ApplicationId",
                table: "tbRole",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbRole_PermissionId",
                table: "tbRole",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbService_ActeeId",
                table: "tbService",
                column: "ActeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbUser_Email",
                table: "tbUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbUserBiometric_BiometricTitle",
                table: "tbUserBiometric",
                column: "BiometricTitle");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserBiometric_UserId",
                table: "tbUserBiometric",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserRole_RoleId",
                table: "tbUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserRole_UserId",
                table: "tbUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProperties_ConfigurationPasswordId",
                table: "UserProperties",
                column: "ConfigurationPasswordId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbMask_tbPermission_PermissionId",
                table: "tbMask",
                column: "PermissionId",
                principalTable: "tbPermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbPermission_tbRole_RoleId",
                table: "tbPermission",
                column: "RoleId",
                principalTable: "tbRole",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbActee_tbApplicationPackage_ApplicationPackageId",
                table: "tbActee");

            migrationBuilder.DropForeignKey(
                name: "FK_tbRole_tbApplications_ApplicationId",
                table: "tbRole");

            migrationBuilder.DropForeignKey(
                name: "FK_tbRole_tbPermission_PermissionId",
                table: "tbRole");

            migrationBuilder.DropTable(
                name: "tbConfigurationLock");

            migrationBuilder.DropTable(
                name: "tbConfigurationSession");

            migrationBuilder.DropTable(
                name: "tbLoginPolicy");

            migrationBuilder.DropTable(
                name: "tbMask");

            migrationBuilder.DropTable(
                name: "tbMenu");

            migrationBuilder.DropTable(
                name: "tbOauthToken");

            migrationBuilder.DropTable(
                name: "tbService");

            migrationBuilder.DropTable(
                name: "tbUserBiometric");

            migrationBuilder.DropTable(
                name: "tbUserRole");

            migrationBuilder.DropTable(
                name: "UserProperties");

            migrationBuilder.DropTable(
                name: "tbBiometricType");

            migrationBuilder.DropTable(
                name: "tbConfigurationPassword");

            migrationBuilder.DropTable(
                name: "tbUser");

            migrationBuilder.DropTable(
                name: "tbApplicationPackage");

            migrationBuilder.DropTable(
                name: "tbApplications");

            migrationBuilder.DropTable(
                name: "tbPermission");

            migrationBuilder.DropTable(
                name: "tbActee");

            migrationBuilder.DropTable(
                name: "tbRole");

            migrationBuilder.DropSequence(
                name: "Seq_Actee",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_Application",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_ApplicationPackage",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_ConfigurationLock",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_ConfigurationPassword",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_ConfigurationSession",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_Mask",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_Menu",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_Permission",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_Service",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_User",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "Seq_UserRole",
                schema: "dbo");
        }
    }
}
