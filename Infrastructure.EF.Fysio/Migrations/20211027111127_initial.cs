using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.EF.Fysio.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    diagnosisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnosisCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bodyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pathology = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.diagnosisId);
                });

            migrationBuilder.CreateTable(
                name: "practitioners",
                columns: table => new
                {
                    practitionerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_practitioners", x => x.practitionerId);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    treatmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    treatmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hasMandatoryExplanation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.treatmentId);
                });

            migrationBuilder.CreateTable(
                name: "treatmentPlans",
                columns: table => new
                {
                    treatmentPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    treatmentId = table.Column<int>(type: "int", nullable: false),
                    weeklyAppointments = table.Column<int>(type: "int", nullable: false),
                    sessionDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diagnosisId = table.Column<int>(type: "int", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treatmentPlans", x => x.treatmentPlanId);
                });

            migrationBuilder.CreateTable(
                name: "patientFiles",
                columns: table => new
                {
                    fileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mainPractitionerpractitionerId = table.Column<int>(type: "int", nullable: true),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    mainComplaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diagnosisCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    intakeBypractitionerId = table.Column<int>(type: "int", nullable: true),
                    treatmentPlanId = table.Column<int>(type: "int", nullable: false),
                    IntakeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    intakeSupervisedBypractitionerId = table.Column<int>(type: "int", nullable: true),
                    employeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientFiles", x => x.fileId);
                    table.ForeignKey(
                        name: "FK_patientFiles_practitioners_intakeBypractitionerId",
                        column: x => x.intakeBypractitionerId,
                        principalTable: "practitioners",
                        principalColumn: "practitionerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_patientFiles_practitioners_intakeSupervisedBypractitionerId",
                        column: x => x.intakeSupervisedBypractitionerId,
                        principalTable: "practitioners",
                        principalColumn: "practitionerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_patientFiles_practitioners_mainPractitionerpractitionerId",
                        column: x => x.mainPractitionerpractitionerId,
                        principalTable: "practitioners",
                        principalColumn: "practitionerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_patientFiles_treatmentPlans_treatmentPlanId",
                        column: x => x.treatmentPlanId,
                        principalTable: "treatmentPlans",
                        principalColumn: "treatmentPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    patientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientFileId = table.Column<int>(type: "int", nullable: false),
                    studentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.patientId);
                    table.ForeignKey(
                        name: "FK_patients_patientFiles_patientFileId",
                        column: x => x.patientFileId,
                        principalTable: "patientFiles",
                        principalColumn: "fileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    appointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isTreatment = table.Column<bool>(type: "bit", nullable: false),
                    treatmentId = table.Column<int>(type: "int", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    specialties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientId = table.Column<int>(type: "int", nullable: true),
                    practitionerId = table.Column<int>(type: "int", nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.appointmentId);
                    table.ForeignKey(
                        name: "FK_appointments_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointments_practitioners_practitionerId",
                        column: x => x.practitionerId,
                        principalTable: "practitioners",
                        principalColumn: "practitionerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointments_Treatment_treatmentId",
                        column: x => x.treatmentId,
                        principalTable: "Treatment",
                        principalColumn: "treatmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    commentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientFileId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    practitionerId = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientId = table.Column<int>(type: "int", nullable: true),
                    visibleForPatient = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.commentId);
                    table.ForeignKey(
                        name: "FK_comments_patientFiles_patientFileId",
                        column: x => x.patientFileId,
                        principalTable: "patientFiles",
                        principalColumn: "fileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_practitioners_practitionerId",
                        column: x => x.practitionerId,
                        principalTable: "practitioners",
                        principalColumn: "practitionerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    appUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientId = table.Column<int>(type: "int", nullable: true),
                    practitionerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.appUserId);
                    table.ForeignKey(
                        name: "FK_users_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_practitioners_practitionerId",
                        column: x => x.practitionerId,
                        principalTable: "practitioners",
                        principalColumn: "practitionerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_appointmentId",
                table: "appointments",
                column: "appointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patientId",
                table: "appointments",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_practitionerId",
                table: "appointments",
                column: "practitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_treatmentId",
                table: "appointments",
                column: "treatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_commentId",
                table: "comments",
                column: "commentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_patientFileId",
                table: "comments",
                column: "patientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_patientId",
                table: "comments",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_practitionerId",
                table: "comments",
                column: "practitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_diagnosisId",
                table: "Diagnosis",
                column: "diagnosisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patientFiles_fileId",
                table: "patientFiles",
                column: "fileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patientFiles_intakeBypractitionerId",
                table: "patientFiles",
                column: "intakeBypractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_patientFiles_intakeSupervisedBypractitionerId",
                table: "patientFiles",
                column: "intakeSupervisedBypractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_patientFiles_mainPractitionerpractitionerId",
                table: "patientFiles",
                column: "mainPractitionerpractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_patientFiles_treatmentPlanId",
                table: "patientFiles",
                column: "treatmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_patients_patientFileId",
                table: "patients",
                column: "patientFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patients_patientId",
                table: "patients",
                column: "patientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_practitioners_practitionerId",
                table: "practitioners",
                column: "practitionerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_treatmentId",
                table: "Treatment",
                column: "treatmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_treatmentPlans_treatmentPlanId",
                table: "treatmentPlans",
                column: "treatmentPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_patientId",
                table: "users",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_users_practitionerId",
                table: "users",
                column: "practitionerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "patientFiles");

            migrationBuilder.DropTable(
                name: "practitioners");

            migrationBuilder.DropTable(
                name: "treatmentPlans");
        }
    }
}
