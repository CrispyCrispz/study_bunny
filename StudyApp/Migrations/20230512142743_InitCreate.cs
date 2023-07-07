using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyApp.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyBuddy_Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CourseName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyBuddy_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "StudyBuddy_Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HobbyName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyBuddy_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "StudyBuddy_Programs",
                columns: table => new
                {
                    ProgramOfStudyId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyBuddy_Programs", x => x.ProgramOfStudyId);
                });

            migrationBuilder.CreateTable(
                name: "StudyBuddy_Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyBuddy_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "StudyBuddy_Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Psswd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyBuddy_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "StudyBuddy_Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CurrentSchoolSchoolId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CurrentProgramProgramOfStudyId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    FirstName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pronouns = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Biography = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyBuddy_Profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Profiles_StudyBuddy_Programs_CurrentProgramProgramOfStudyId",
                        column: x => x.CurrentProgramProgramOfStudyId,
                        principalTable: "StudyBuddy_Programs",
                        principalColumn: "ProgramOfStudyId");
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Profiles_StudyBuddy_Schools_CurrentSchoolSchoolId",
                        column: x => x.CurrentSchoolSchoolId,
                        principalTable: "StudyBuddy_Schools",
                        principalColumn: "SchoolId");
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Profiles_StudyBuddy_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "StudyBuddy_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile",
                columns: table => new
                {
                    AspiringStudentsProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DesiredCoursesCourseId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile", x => new { x.AspiringStudentsProfileId, x.DesiredCoursesCourseId });
                    table.ForeignKey(
                        name: "FK_CourseProfile_StudyBuddy_Courses_DesiredCoursesCourseId",
                        column: x => x.DesiredCoursesCourseId,
                        principalTable: "StudyBuddy_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfile_StudyBuddy_Profiles_AspiringStudentsProfileId",
                        column: x => x.AspiringStudentsProfileId,
                        principalTable: "StudyBuddy_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile1",
                columns: table => new
                {
                    CurrentCoursesCourseId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CurrentStudentsProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile1", x => new { x.CurrentCoursesCourseId, x.CurrentStudentsProfileId });
                    table.ForeignKey(
                        name: "FK_CourseProfile1_StudyBuddy_Courses_CurrentCoursesCourseId",
                        column: x => x.CurrentCoursesCourseId,
                        principalTable: "StudyBuddy_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfile1_StudyBuddy_Profiles_CurrentStudentsProfileId",
                        column: x => x.CurrentStudentsProfileId,
                        principalTable: "StudyBuddy_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HobbyProfile",
                columns: table => new
                {
                    HobbiesHobbyId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    InterestedPeopleProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyProfile", x => new { x.HobbiesHobbyId, x.InterestedPeopleProfileId });
                    table.ForeignKey(
                        name: "FK_HobbyProfile_StudyBuddy_Hobbies_HobbiesHobbyId",
                        column: x => x.HobbiesHobbyId,
                        principalTable: "StudyBuddy_Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyProfile_StudyBuddy_Profiles_InterestedPeopleProfileId",
                        column: x => x.InterestedPeopleProfileId,
                        principalTable: "StudyBuddy_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileSchool",
                columns: table => new
                {
                    AlumnaeProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PreviousSchoolsSchoolId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSchool", x => new { x.AlumnaeProfileId, x.PreviousSchoolsSchoolId });
                    table.ForeignKey(
                        name: "FK_ProfileSchool_StudyBuddy_Profiles_AlumnaeProfileId",
                        column: x => x.AlumnaeProfileId,
                        principalTable: "StudyBuddy_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileSchool_StudyBuddy_Schools_PreviousSchoolsSchoolId",
                        column: x => x.PreviousSchoolsSchoolId,
                        principalTable: "StudyBuddy_Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyBuddy_Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DateOfDay = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    TimeOfDay = table.Column<TimeSpan>(type: "INTERVAL DAY(8) TO SECOND(7)", nullable: false),
                    RelatedSchoolSchoolId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    RelatedCourseCourseId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    RelatedProgramProgramOfStudyId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyBuddy_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Events_StudyBuddy_Courses_RelatedCourseCourseId",
                        column: x => x.RelatedCourseCourseId,
                        principalTable: "StudyBuddy_Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Events_StudyBuddy_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "StudyBuddy_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Events_StudyBuddy_Programs_RelatedProgramProgramOfStudyId",
                        column: x => x.RelatedProgramProgramOfStudyId,
                        principalTable: "StudyBuddy_Programs",
                        principalColumn: "ProgramOfStudyId");
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Events_StudyBuddy_Schools_RelatedSchoolSchoolId",
                        column: x => x.RelatedSchoolSchoolId,
                        principalTable: "StudyBuddy_Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "StudyBuddy_Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TimeStamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SenderProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecipientProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Read = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyBuddy_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Messages_StudyBuddy_Profiles_RecipientProfileId",
                        column: x => x.RecipientProfileId,
                        principalTable: "StudyBuddy_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyBuddy_Messages_StudyBuddy_Profiles_SenderProfileId",
                        column: x => x.SenderProfileId,
                        principalTable: "StudyBuddy_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventProfile",
                columns: table => new
                {
                    AttendeesProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AttendingEventsEventId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProfile", x => new { x.AttendeesProfileId, x.AttendingEventsEventId });
                    table.ForeignKey(
                        name: "FK_EventProfile_StudyBuddy_Events_AttendingEventsEventId",
                        column: x => x.AttendingEventsEventId,
                        principalTable: "StudyBuddy_Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventProfile_StudyBuddy_Profiles_AttendeesProfileId",
                        column: x => x.AttendeesProfileId,
                        principalTable: "StudyBuddy_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile_DesiredCoursesCourseId",
                table: "CourseProfile",
                column: "DesiredCoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile1_CurrentStudentsProfileId",
                table: "CourseProfile1",
                column: "CurrentStudentsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EventProfile_AttendingEventsEventId",
                table: "EventProfile",
                column: "AttendingEventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyProfile_InterestedPeopleProfileId",
                table: "HobbyProfile",
                column: "InterestedPeopleProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileSchool_PreviousSchoolsSchoolId",
                table: "ProfileSchool",
                column: "PreviousSchoolsSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Events_ProfileId",
                table: "StudyBuddy_Events",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Events_RelatedCourseCourseId",
                table: "StudyBuddy_Events",
                column: "RelatedCourseCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Events_RelatedProgramProgramOfStudyId",
                table: "StudyBuddy_Events",
                column: "RelatedProgramProgramOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Events_RelatedSchoolSchoolId",
                table: "StudyBuddy_Events",
                column: "RelatedSchoolSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Messages_RecipientProfileId",
                table: "StudyBuddy_Messages",
                column: "RecipientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Messages_SenderProfileId",
                table: "StudyBuddy_Messages",
                column: "SenderProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Profiles_CurrentProgramProgramOfStudyId",
                table: "StudyBuddy_Profiles",
                column: "CurrentProgramProgramOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Profiles_CurrentSchoolSchoolId",
                table: "StudyBuddy_Profiles",
                column: "CurrentSchoolSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyBuddy_Profiles_UserId",
                table: "StudyBuddy_Profiles",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseProfile");

            migrationBuilder.DropTable(
                name: "CourseProfile1");

            migrationBuilder.DropTable(
                name: "EventProfile");

            migrationBuilder.DropTable(
                name: "HobbyProfile");

            migrationBuilder.DropTable(
                name: "ProfileSchool");

            migrationBuilder.DropTable(
                name: "StudyBuddy_Messages");

            migrationBuilder.DropTable(
                name: "StudyBuddy_Events");

            migrationBuilder.DropTable(
                name: "StudyBuddy_Hobbies");

            migrationBuilder.DropTable(
                name: "StudyBuddy_Courses");

            migrationBuilder.DropTable(
                name: "StudyBuddy_Profiles");

            migrationBuilder.DropTable(
                name: "StudyBuddy_Programs");

            migrationBuilder.DropTable(
                name: "StudyBuddy_Schools");

            migrationBuilder.DropTable(
                name: "StudyBuddy_Users");
        }
    }
}
