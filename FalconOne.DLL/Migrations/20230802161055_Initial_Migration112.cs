﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FalconOne.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration112 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceAndLeavePolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaximumVacationDaysPerYear = table.Column<int>(type: "int", nullable: false),
                    MaximumSickLeaveDaysPerYear = table.Column<int>(type: "int", nullable: false),
                    MaximumPersonalLeaveDaysPerYear = table.Column<int>(type: "int", nullable: false),
                    MaximumUnpaidLeaveDaysPerYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceAndLeavePolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceCaptureSchemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresTimeTracking = table.Column<bool>(type: "bit", nullable: false),
                    RequiresAttendanceApproval = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceCaptureSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreakAndMealPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreakDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    MealDuration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakAndMealPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoCharCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreeCharCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSummaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutJob = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSummaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentType = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    IsCurrentJob = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndPreviousPosition = table.Column<bool>(type: "bit", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileHeadline = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayCalendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayCalendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmploymentType = table.Column<int>(type: "int", nullable: false),
                    WorkerType = table.Column<int>(type: "int", nullable: false),
                    TimeType = table.Column<int>(type: "int", nullable: false),
                    EmployeeBand = table.Column<int>(type: "int", nullable: false),
                    PayGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeavePlans",
                columns: table => new
                {
                    LeavePlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalLeaveDays = table.Column<int>(type: "int", nullable: false),
                    RemainingLeaveDays = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeavePlans", x => x.LeavePlanId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemoteWorkEligibilityCriteria",
                columns: table => new
                {
                    CriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriteriaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresApproval = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoteWorkEligibilityCriteria", x => x.CriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "ShiftAllowancePolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercentage = table.Column<bool>(type: "bit", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAllowancePolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekOffPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekOffPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbsenceAndLeavePolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveTypes_AbsenceAndLeavePolicies_AbsenceAndLeavePolicyId",
                        column: x => x.AbsenceAndLeavePolicyId,
                        principalTable: "AbsenceAndLeavePolicies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttendanceCaptureMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodType = table.Column<int>(type: "int", nullable: false),
                    AttendanceCaptureSchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceCaptureMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceCaptureMethods_AttendanceCaptureSchemes_AttendanceCaptureSchemeId",
                        column: x => x.AttendanceCaptureSchemeId,
                        principalTable: "AttendanceCaptureSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hobbies_EmployeeSummaries_EmployeeSummaryId",
                        column: x => x.EmployeeSummaryId,
                        principalTable: "EmployeeSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_EmployeeSummaries_EmployeeSummaryId",
                        column: x => x.EmployeeSummaryId,
                        principalTable: "EmployeeSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperiennceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolidayCalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_HolidayCalendars_HolidayCalendarId",
                        column: x => x.HolidayCalendarId,
                        principalTable: "HolidayCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceTrackingPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkHours = table.Column<int>(type: "int", nullable: false),
                    GracePeriod = table.Column<TimeSpan>(type: "time", nullable: false),
                    LateArrivalThreshold = table.Column<TimeSpan>(type: "time", nullable: false),
                    EarlyDepartureThresHold = table.Column<TimeSpan>(type: "time", nullable: false),
                    BreakAndMealPeriodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequiresTimeTracking = table.Column<bool>(type: "bit", nullable: false),
                    RemoteWorkAllowed = table.Column<bool>(type: "bit", nullable: false),
                    RemoteWorkEligibilityCriteriaCriteriaId = table.Column<int>(type: "int", nullable: false),
                    AbsenceAndLeavePoliciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceTrackingPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceTrackingPolicies_AbsenceAndLeavePolicies_AbsenceAndLeavePoliciesId",
                        column: x => x.AbsenceAndLeavePoliciesId,
                        principalTable: "AbsenceAndLeavePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceTrackingPolicies_BreakAndMealPeriods_BreakAndMealPeriodsId",
                        column: x => x.BreakAndMealPeriodsId,
                        principalTable: "BreakAndMealPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceTrackingPolicies_RemoteWorkEligibilityCriteria_RemoteWorkEligibilityCriteriaCriteriaId",
                        column: x => x.RemoteWorkEligibilityCriteriaCriteriaId,
                        principalTable: "RemoteWorkEligibilityCriteria",
                        principalColumn: "CriteriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftDuration = table.Column<int>(type: "int", nullable: false),
                    ShiftType = table.Column<int>(type: "int", nullable: false),
                    ShiftAllowancePolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeShifts_ShiftAllowancePolicies_ShiftAllowancePolicyId",
                        column: x => x.ShiftAllowancePolicyId,
                        principalTable: "ShiftAllowancePolicies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PolicyDayWeekOffPolicy",
                columns: table => new
                {
                    PolicyDaysId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekOffPoliciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDayWeekOffPolicy", x => new { x.PolicyDaysId, x.WeekOffPoliciesId });
                    table.ForeignKey(
                        name: "FK_PolicyDayWeekOffPolicy_PolicyDays_PolicyDaysId",
                        column: x => x.PolicyDaysId,
                        principalTable: "PolicyDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyDayWeekOffPolicy_WeekOffPolicies_WeekOffPoliciesId",
                        column: x => x.WeekOffPoliciesId,
                        principalTable: "WeekOffPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftWeeklyOffRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeeklyOffDay = table.Column<int>(type: "int", nullable: false),
                    ShiftDurationInHours = table.Column<int>(type: "int", nullable: false),
                    EmployeeShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftWeeklyOffRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftWeeklyOffRules_EmployeeShifts_EmployeeShiftId",
                        column: x => x.EmployeeShiftId,
                        principalTable: "EmployeeShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addressess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addressess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addressess_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceAlias = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "'FOUSR' + CAST([ResourceId] AS nvarchar(max))"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationIssuedId = table.Column<long>(type: "bigint", nullable: true),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    BloodGroup = table.Column<int>(type: "int", nullable: true),
                    PhysicallyChallenged = table.Column<bool>(type: "bit", nullable: true),
                    ProfessionalSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.UniqueConstraint("AK_AspNetUsers_ResourceId", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_EmployeeSummaries_EmployeeSummaryId",
                        column: x => x.EmployeeSummaryId,
                        principalTable: "EmployeeSummaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_JobDetails_JobDetailsId",
                        column: x => x.JobDetailsId,
                        principalTable: "JobDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidencePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDetails_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetadataGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataGroups_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OverTimeAuthorizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApproverComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTimeAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverTimeAuthorizations_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OverTimeAuthorizations_AspNetUsers_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metadatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetadataGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metadatas_MetadataGroups_MetadataGroupId",
                        column: x => x.MetadataGroupId,
                        principalTable: "MetadataGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OverTimePolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverTimeThreshold = table.Column<TimeSpan>(type: "time", nullable: false),
                    OverTimeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OvertimeCalculationMethod = table.Column<int>(type: "int", nullable: false),
                    OverTimeAuthorizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTimePolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverTimePolicies_OverTimeAuthorizations_OverTimeAuthorizationId",
                        column: x => x.OverTimeAuthorizationId,
                        principalTable: "OverTimeAuthorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeeklyOffPolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeavePlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolidayCalenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceCaptureSchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceTrackingPolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftWeeklyOffRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftAllowancePolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OverTimePolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekOffPolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolidayCalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_AttendanceCaptureSchemes_AttendanceCaptureSchemeId",
                        column: x => x.AttendanceCaptureSchemeId,
                        principalTable: "AttendanceCaptureSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_AttendanceTrackingPolicies_AttendanceTrackingPolicyId",
                        column: x => x.AttendanceTrackingPolicyId,
                        principalTable: "AttendanceTrackingPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_EmployeeShifts_EmployeeShiftId",
                        column: x => x.EmployeeShiftId,
                        principalTable: "EmployeeShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_HolidayCalendars_HolidayCalendarId",
                        column: x => x.HolidayCalendarId,
                        principalTable: "HolidayCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_LeavePlans_LeavePlanId",
                        column: x => x.LeavePlanId,
                        principalTable: "LeavePlans",
                        principalColumn: "LeavePlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_OverTimePolicies_OverTimePolicyId",
                        column: x => x.OverTimePolicyId,
                        principalTable: "OverTimePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_ShiftAllowancePolicies_ShiftAllowancePolicyId",
                        column: x => x.ShiftAllowancePolicyId,
                        principalTable: "ShiftAllowancePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_ShiftWeeklyOffRules_ShiftWeeklyOffRuleId",
                        column: x => x.ShiftWeeklyOffRuleId,
                        principalTable: "ShiftWeeklyOffRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTimes_WeekOffPolicies_WeekOffPolicyId",
                        column: x => x.WeekOffPolicyId,
                        principalTable: "WeekOffPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayType = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceLogs_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttendanceLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    In = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Out = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttendanceLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLogs_AttendanceLogs_AttendanceLogId",
                        column: x => x.AttendanceLogId,
                        principalTable: "AttendanceLogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CommentedById",
                        column: x => x.CommentedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLocations",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLocations", x => new { x.DepartmentId, x.LocationId });
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartment",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartment", x => new { x.EmployeeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountAlias = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "'FOTEN' + CAST([AccountId] AS nvarchar(max))"),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Images_ProfilePictureId",
                        column: x => x.ProfilePictureId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_PostedById",
                        column: x => x.PostedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SecurityPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityPolicies_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SettingType = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteSettings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraceIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Scheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemLogs_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TenantUser",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUser", x => new { x.TenantId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TenantUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantUser_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantLocation",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantLocation", x => new { x.TenantId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_TenantLocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantLocation_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactionType = table.Column<int>(type: "int", nullable: false),
                    ReactedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactionOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_AspNetUsers_ReactedById",
                        column: x => x.ReactedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SecurityClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationPolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityClaims_SecurityPolicies_ApplicationPolicyId",
                        column: x => x.ApplicationPolicyId,
                        principalTable: "SecurityPolicies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SecurityClaims_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Navigation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Navigation_SecurityClaims_ApplicationClaimId",
                        column: x => x.ApplicationClaimId,
                        principalTable: "SecurityClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Navigation_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "Id", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("0919346e-e179-442e-90bb-f8af0c453afa"), "Trainee Engineer", null },
                    { new Guid("28c480fa-97bd-4c73-97d4-5496b1cb67c0"), "Associate Software Engineer", null }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("35d8761a-4cf6-490e-89b6-e11ac2f02a91"), "16.5102716", "80.4889922", "Hitech City", null },
                    { new Guid("402b7e41-58ae-4982-86d6-cc61c4aebdb8"), "16.5102716", "80.4889922", "Nidamanuru", null },
                    { new Guid("ee43507e-83c3-450b-be4d-4aa172ba6cef"), "78.4867° E", "17.3850° N", "Hyderabad", null },
                    { new Guid("feb25369-4b95-43d6-b7e3-da9bf2bf71be"), "16.5102716", "80.4889922", "Vijayawada", null }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "CreatedOn", "Host", "ModifiedOn", "Name", "ProfilePictureId" },
                values: new object[,]
                {
                    { new Guid("8eac86e2-80e0-4b47-bf46-d5f315ca47eb"), new DateTime(2023, 8, 2, 16, 10, 54, 224, DateTimeKind.Utc).AddTicks(6014), "api.falconone.com", null, "FalconOne", null },
                    { new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), new DateTime(2023, 8, 2, 16, 10, 54, 224, DateTimeKind.Utc).AddTicks(6009), "localhost", null, "development", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BloodGroup", "ConcurrencyStamp", "CreatedOn", "DateOfBirth", "DesignationId", "Discriminator", "Email", "EmailConfirmed", "EmployeeId", "EmployeeSummaryId", "FirstName", "Gender", "IsActive", "JobDetailsId", "LastName", "LockoutEnabled", "LockoutEnd", "MaritalStatus", "MiddleName", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "OrganizationIssuedId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhysicallyChallenged", "PostId", "ProfessionalSummary", "ProfilePictureId", "ResourceId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5090b588-6e3f-464a-994d-9cd2af4a0198"), 0, 0, "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==", new DateTime(2023, 8, 2, 16, 10, 54, 20, DateTimeKind.Utc).AddTicks(1124), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("28c480fa-97bd-4c73-97d4-5496b1cb67c0"), "Employee", "a@a.com", true, null, null, "Admin", 0, true, null, "User", false, null, 0, null, null, "a@a.com", "a", 2L, "AQAAAAIAAYagAAAAEBdfLSfmZ6NMsdj3L6vjF9FBxQ/QB36bTCqoDyXCy+2lE638YfSgJCrEWO4VxDqRLA==", "8886014997", false, false, null, null, null, 2, "UCQO32XEFNXIAZIR3LTNFDRRX7A2NHLK", false, "adminuser01" },
                    { new Guid("6521474a-6e39-4a5e-8628-cd89b4e922bc"), 0, 0, "AQAAAAEAACcQAAAAEP/x170yyX0uuRQdVFBRYelz5uo6tu1qjpJDWgKx9P0SHMyDKSl4vbXASElX+1GzDA==", new DateTime(2023, 8, 2, 16, 10, 54, 20, DateTimeKind.Utc).AddTicks(1116), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0919346e-e179-442e-90bb-f8af0c453afa"), "Employee", "b@b.com", true, null, null, "Basic", 0, true, null, "User", false, null, 0, null, null, "b@b.com", "b", 1L, "AQAAAAIAAYagAAAAELgEIIdOzH7XT9H3vNLLNfP7OFnaEgjnxzRDZxLjr5wu0cEB7gbqzVBYjIwbz/5Nww==", "8886014996", false, false, null, null, null, 1, "UCQO32XEFNXIAZIR3LTNFDRRX7A2NHLK", false, "basicuser01" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "BusinessUnitId", "CreatedOn", "ModifiedOn", "Name", "ProfilePictureId", "TenantId" },
                values: new object[,]
                {
                    { new Guid("b8246268-cfb1-4833-8b64-db989c8c15e3"), null, new DateTime(2023, 8, 2, 16, 10, 54, 20, DateTimeKind.Utc).AddTicks(658), null, ".NET", null, new Guid("8eac86e2-80e0-4b47-bf46-d5f315ca47eb") },
                    { new Guid("db9bba1e-4eba-4c44-9bd8-8ce0843ae458"), null, new DateTime(2023, 8, 2, 16, 10, 54, 20, DateTimeKind.Utc).AddTicks(641), null, "Development", null, new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc") }
                });

            migrationBuilder.InsertData(
                table: "SecurityPolicies",
                columns: new[] { "Id", "CreatedOn", "ModifiedOn", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("9fa14d9e-0d8e-4b51-85e4-c4bdd5873d14"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7015), null, "User", new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc") },
                    { new Guid("b7538a53-d3b2-4b66-ba40-97619cda8d00"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7020), null, "Admin", new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc") }
                });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "Id", "CreatedOn", "Description", "DisplayName", "ModifiedOn", "Name", "SettingType", "TenantId", "Value" },
                values: new object[,]
                {
                    { new Guid("03402523-7761-40c6-8b1e-90637068da57"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7239), "This is secondary color", "Secondary Color", null, "secondaryColor", 1, new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), "#205295" },
                    { new Guid("03c3646e-4496-44e2-9868-ce98e0f7431f"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7170), "This is primary color", "Primary Color", null, "primaryColor", 1, new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), "#144272" },
                    { new Guid("18a035d3-385e-495f-b1af-99155fea92a1"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7267), "This is primary color", "Primary Color", null, "primaryColor", 1, new Guid("8eac86e2-80e0-4b47-bf46-d5f315ca47eb"), "#144272" },
                    { new Guid("3dbac5ed-9834-4d03-8ae1-45298f49f585"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7253), "This is site theme", "Theme", null, "theme", 1, new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), "light" },
                    { new Guid("4ad80c98-cf63-401e-b355-b81e34dd2bfa"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7298), "This is secondary color", "Secondary Color", null, "secondaryColor", 1, new Guid("8eac86e2-80e0-4b47-bf46-d5f315ca47eb"), "#205295" },
                    { new Guid("705a7544-b591-42e2-8763-911e6fdf88a6"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7319), "This is site theme", "Theme", null, "theme", 1, new Guid("8eac86e2-80e0-4b47-bf46-d5f315ca47eb"), "light" }
                });

            migrationBuilder.InsertData(
                table: "TenantLocation",
                columns: new[] { "LocationId", "TenantId" },
                values: new object[,]
                {
                    { new Guid("feb25369-4b95-43d6-b7e3-da9bf2bf71be"), new Guid("8eac86e2-80e0-4b47-bf46-d5f315ca47eb") },
                    { new Guid("ee43507e-83c3-450b-be4d-4aa172ba6cef"), new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Admin", "Everything", new Guid("5090b588-6e3f-464a-994d-9cd2af4a0198") },
                    { 2, "User", "BasicThings", new Guid("6521474a-6e39-4a5e-8628-cd89b4e922bc") }
                });

            migrationBuilder.InsertData(
                table: "DepartmentLocations",
                columns: new[] { "DepartmentId", "LocationId" },
                values: new object[,]
                {
                    { new Guid("b8246268-cfb1-4833-8b64-db989c8c15e3"), new Guid("402b7e41-58ae-4982-86d6-cc61c4aebdb8") },
                    { new Guid("db9bba1e-4eba-4c44-9bd8-8ce0843ae458"), new Guid("35d8761a-4cf6-490e-89b6-e11ac2f02a91") }
                });

            migrationBuilder.InsertData(
                table: "EmployeeDepartment",
                columns: new[] { "DepartmentId", "EmployeeId" },
                values: new object[,]
                {
                    { new Guid("db9bba1e-4eba-4c44-9bd8-8ce0843ae458"), new Guid("5090b588-6e3f-464a-994d-9cd2af4a0198") },
                    { new Guid("b8246268-cfb1-4833-8b64-db989c8c15e3"), new Guid("6521474a-6e39-4a5e-8628-cd89b4e922bc") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedOn", "DepartmentId", "ModifiedOn", "PostedById", "PostedOn", "TenantId" },
                values: new object[] { new Guid("17bc5e50-b640-419b-807f-16ace5977e51"), "Hey this is new post on our site.", new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7388), null, null, new Guid("5090b588-6e3f-464a-994d-9cd2af4a0198"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7389), new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc") });

            migrationBuilder.InsertData(
                table: "SecurityClaims",
                columns: new[] { "Id", "ApplicationPolicyId", "CreatedOn", "Description", "ModifiedOn", "TenantId", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), new Guid("b7538a53-d3b2-4b66-ba40-97619cda8d00"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7062), "Database seeded", null, new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), "Admin", "Everything" },
                    { new Guid("f7a9b029-13db-4a48-bac2-3143a3b143c1"), new Guid("9fa14d9e-0d8e-4b51-85e4-c4bdd5873d14"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7111), "Database seeded", null, new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), "User", "BasicThings" }
                });

            migrationBuilder.InsertData(
                table: "TenantUser",
                columns: new[] { "TenantId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8eac86e2-80e0-4b47-bf46-d5f315ca47eb"), new Guid("5090b588-6e3f-464a-994d-9cd2af4a0198") },
                    { new Guid("8eac86e2-80e0-4b47-bf46-d5f315ca47eb"), new Guid("6521474a-6e39-4a5e-8628-cd89b4e922bc") },
                    { new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), new Guid("5090b588-6e3f-464a-994d-9cd2af4a0198") },
                    { new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), new Guid("6521474a-6e39-4a5e-8628-cd89b4e922bc") }
                });

            migrationBuilder.InsertData(
                table: "Navigation",
                columns: new[] { "Id", "ApplicationClaimId", "CreatedOn", "Description", "ModifiedOn", "Name", "TenantId", "URL" },
                values: new object[,]
                {
                    { new Guid("bf1c4717-ed55-4ad5-9e80-04e809244839"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7141), "User login", null, "Login", new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), "login" },
                    { new Guid("e1e8a44d-c060-49c1-aa06-d848be7c1c5d"), new Guid("c1f09df3-5590-4ee8-9b8c-d0315369a7af"), new DateTime(2023, 8, 2, 16, 10, 54, 225, DateTimeKind.Utc).AddTicks(7146), "User signup", null, "Singup", new Guid("f1adbf2c-b634-4d66-8de0-d154d74a0ffc"), "signup" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addressess_CountryId",
                table: "Addressess",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addressess_EmployeeId",
                table: "Addressess",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_TenantId",
                table: "AspNetRoles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DesignationId",
                table: "AspNetUsers",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeSummaryId",
                table: "AspNetUsers",
                column: "EmployeeSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobDetailsId",
                table: "AspNetUsers",
                column: "JobDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PostId",
                table: "AspNetUsers",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfilePictureId",
                table: "AspNetUsers",
                column: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCaptureMethods_AttendanceCaptureSchemeId",
                table: "AttendanceCaptureMethods",
                column: "AttendanceCaptureSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceLogs_EmployeeId",
                table: "AttendanceLogs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceLogs_LocationId",
                table: "AttendanceLogs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceLogs_UserId",
                table: "AttendanceLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceTrackingPolicies_AbsenceAndLeavePoliciesId",
                table: "AttendanceTrackingPolicies",
                column: "AbsenceAndLeavePoliciesId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceTrackingPolicies_BreakAndMealPeriodsId",
                table: "AttendanceTrackingPolicies",
                column: "BreakAndMealPeriodsId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceTrackingPolicies_RemoteWorkEligibilityCriteriaCriteriaId",
                table: "AttendanceTrackingPolicies",
                column: "RemoteWorkEligibilityCriteriaCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnits_TenantId",
                table: "BusinessUnits",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentedById",
                table: "Comments",
                column: "CommentedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_EmployeeId",
                table: "ContactDetails",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLocations_LocationId",
                table: "DepartmentLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BusinessUnitId",
                table: "Departments",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ProfilePictureId",
                table: "Departments",
                column: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_TenantId",
                table: "Departments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_TenantId",
                table: "Designations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartment_DepartmentId",
                table: "EmployeeDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShifts_ShiftAllowancePolicyId",
                table: "EmployeeShifts",
                column: "ShiftAllowancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_AttendanceCaptureSchemeId",
                table: "EmployeeTimes",
                column: "AttendanceCaptureSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_AttendanceTrackingPolicyId",
                table: "EmployeeTimes",
                column: "AttendanceTrackingPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_EmployeeShiftId",
                table: "EmployeeTimes",
                column: "EmployeeShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_HolidayCalendarId",
                table: "EmployeeTimes",
                column: "HolidayCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_LeavePlanId",
                table: "EmployeeTimes",
                column: "LeavePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_OverTimePolicyId",
                table: "EmployeeTimes",
                column: "OverTimePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_ShiftAllowancePolicyId",
                table: "EmployeeTimes",
                column: "ShiftAllowancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_ShiftWeeklyOffRuleId",
                table: "EmployeeTimes",
                column: "ShiftWeeklyOffRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimes_WeekOffPolicyId",
                table: "EmployeeTimes",
                column: "WeekOffPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_EmployeeSummaryId",
                table: "Hobbies",
                column: "EmployeeSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_HolidayCalendarId",
                table: "Holidays",
                column: "HolidayCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MediaId",
                table: "Images",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PostId",
                table: "Images",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_EmployeeSummaryId",
                table: "Interests",
                column: "EmployeeSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_AbsenceAndLeavePolicyId",
                table: "LeaveTypes",
                column: "AbsenceAndLeavePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TenantId",
                table: "Locations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_ExperienceId",
                table: "Media",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataGroups_EmployeeId",
                table: "MetadataGroups",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadatas_MetadataGroupId",
                table: "Metadatas",
                column: "MetadataGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Navigation_ApplicationClaimId",
                table: "Navigation",
                column: "ApplicationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Navigation_TenantId",
                table: "Navigation",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_OverTimeAuthorizations_ApprovedById",
                table: "OverTimeAuthorizations",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_OverTimeAuthorizations_RequestedById",
                table: "OverTimeAuthorizations",
                column: "RequestedById");

            migrationBuilder.CreateIndex(
                name: "IX_OverTimePolicies_OverTimeAuthorizationId",
                table: "OverTimePolicies",
                column: "OverTimeAuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDayWeekOffPolicy_WeekOffPoliciesId",
                table: "PolicyDayWeekOffPolicy",
                column: "WeekOffPoliciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_DepartmentId",
                table: "Posts",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostedById",
                table: "Posts",
                column: "PostedById");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TenantId",
                table: "Posts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PostId",
                table: "Reactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ReactedById",
                table: "Reactions",
                column: "ReactedById");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityClaims_ApplicationPolicyId",
                table: "SecurityClaims",
                column: "ApplicationPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityClaims_TenantId",
                table: "SecurityClaims",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityPolicies_TenantId",
                table: "SecurityPolicies",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftWeeklyOffRules_EmployeeShiftId",
                table: "ShiftWeeklyOffRules",
                column: "EmployeeShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_TenantId",
                table: "SiteSettings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ExperienceId",
                table: "Skills",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemLogs_TenantId",
                table: "SystemLogs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantLocation_LocationId",
                table: "TenantLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ProfilePictureId",
                table: "Tenants",
                column: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantUser_UserId",
                table: "TenantUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLogs_AttendanceLogId",
                table: "TimeLogs",
                column: "AttendanceLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addressess_AspNetUsers_EmployeeId",
                table: "Addressess",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_Tenants_TenantId",
                table: "AspNetRoles",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Designations_DesignationId",
                table: "AspNetUsers",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ProfilePictureId",
                table: "AspNetUsers",
                column: "ProfilePictureId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Posts_PostId",
                table: "AspNetUsers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceLogs_Locations_LocationId",
                table: "AttendanceLogs",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessUnits_Tenants_TenantId",
                table: "BusinessUnits",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLocations_Departments_DepartmentId",
                table: "DepartmentLocations",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLocations_Locations_LocationId",
                table: "DepartmentLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Images_ProfilePictureId",
                table: "Departments",
                column: "ProfilePictureId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Tenants_TenantId",
                table: "Departments",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Tenants_TenantId",
                table: "Designations",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_PostedById",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessUnits_Tenants_TenantId",
                table: "BusinessUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Tenants_TenantId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tenants_TenantId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Images_ProfilePictureId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Addressess");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttendanceCaptureMethods");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "DepartmentLocations");

            migrationBuilder.DropTable(
                name: "EmployeeDepartment");

            migrationBuilder.DropTable(
                name: "EmployeeTimes");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "Metadatas");

            migrationBuilder.DropTable(
                name: "Navigation");

            migrationBuilder.DropTable(
                name: "PolicyDayWeekOffPolicy");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SystemLogs");

            migrationBuilder.DropTable(
                name: "TenantLocation");

            migrationBuilder.DropTable(
                name: "TenantUser");

            migrationBuilder.DropTable(
                name: "TimeLogs");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AttendanceCaptureSchemes");

            migrationBuilder.DropTable(
                name: "AttendanceTrackingPolicies");

            migrationBuilder.DropTable(
                name: "LeavePlans");

            migrationBuilder.DropTable(
                name: "OverTimePolicies");

            migrationBuilder.DropTable(
                name: "ShiftWeeklyOffRules");

            migrationBuilder.DropTable(
                name: "HolidayCalendars");

            migrationBuilder.DropTable(
                name: "MetadataGroups");

            migrationBuilder.DropTable(
                name: "SecurityClaims");

            migrationBuilder.DropTable(
                name: "PolicyDays");

            migrationBuilder.DropTable(
                name: "WeekOffPolicies");

            migrationBuilder.DropTable(
                name: "AttendanceLogs");

            migrationBuilder.DropTable(
                name: "AbsenceAndLeavePolicies");

            migrationBuilder.DropTable(
                name: "BreakAndMealPeriods");

            migrationBuilder.DropTable(
                name: "RemoteWorkEligibilityCriteria");

            migrationBuilder.DropTable(
                name: "OverTimeAuthorizations");

            migrationBuilder.DropTable(
                name: "EmployeeShifts");

            migrationBuilder.DropTable(
                name: "SecurityPolicies");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ShiftAllowancePolicies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmployeeSummaries");

            migrationBuilder.DropTable(
                name: "JobDetails");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "BusinessUnits");
        }
    }
}
