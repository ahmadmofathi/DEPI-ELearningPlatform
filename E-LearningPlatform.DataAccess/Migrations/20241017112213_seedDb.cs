using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_LearningPlatform.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Enrollments_EnrollmentId",
                table: "Progress");

            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Users_UserId",
                table: "Progress");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Account_AccountId1",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_requests",
                table: "requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Progress",
                table: "Progress");

            migrationBuilder.DropIndex(
                name: "IX_Progress_UserId",
                table: "Progress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Progress");

            migrationBuilder.RenameTable(
                name: "requests",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "Progress",
                newName: "Progresses");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Progress_EnrollmentId",
                table: "Progresses",
                newName: "IX_Progresses_EnrollmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Progresses",
                table: "Progresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccessFailedCount", "AccountId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "322337c3-589f-4e5f-9681-b2357a142e90", 0, 2, "1aef65b4-1718-4f4b-8bf7-9728c51819c2", "design@example.com", false, "Ahmed", "Fathi", false, null, null, null, "hashedPassword2", null, false, "8ac64b2e-d24c-4a11-b4a7-ac6b9dacf4ac", false, "Ahmed" },
                    { "7fdd22b5-e225-4071-8a1a-a4742bf984fc", 0, 1, "118825f2-82af-4214-b795-1ddc20da12de", "dev@example.com", false, "Mohamed", "Khaled", false, null, null, null, "hashedPassword1", null, false, "864331b4-869c-420b-87d8-149e5aa375c2", false, "mokhaled" },
                    { "b983ee66-785a-496e-a2a5-ecc5a859d4a4", 0, 3, "5d467e6a-73c5-46fa-82da-5722f31cee5c", "marketing@example.com", false, "Mohamed", "Ashraf", false, null, null, null, "hashedPassword3", null, false, "3775ac6e-8156-475c-81f5-6d89370e7101", false, "moAshraf" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Development" },
                    { 2, "Design" },
                    { 3, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 17, 11, 22, 12, 435, DateTimeKind.Utc).AddTicks(6756), 1 },
                    { 2, 2, new DateTime(2024, 10, 17, 11, 22, 12, 435, DateTimeKind.Utc).AddTicks(6760), 2 },
                    { 3, 3, new DateTime(2024, 10, 17, 11, 22, 12, 435, DateTimeKind.Utc).AddTicks(6761), 3 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Qualifications", "SocialMediaLink", "UserId" },
                values: new object[,]
                {
                    { 1, "PhD in Computer Science", "https://twitter.com/instructor1", 1 },
                    { 2, "MFA in Design", "https://linkedin.com/instructor2", 2 },
                    { 3, "MBA in Marketing", "https://instagram.com/instructor3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "CourseId", "CreationDate", "Description", "RequestStatus", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 17, 11, 22, 12, 435, DateTimeKind.Utc).AddTicks(6805), "Request for additional materials", "Pending", 1 },
                    { 2, 2, new DateTime(2024, 10, 17, 11, 22, 12, 435, DateTimeKind.Utc).AddTicks(6807), "Request for a refund", "Completed", 2 },
                    { 3, 3, new DateTime(2024, 10, 17, 11, 22, 12, 435, DateTimeKind.Utc).AddTicks(6808), "Request for course feedback", "In Progress", 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CategoryId", "CourseName", "Description", "NoOfVideos", "Price" },
                values: new object[,]
                {
                    { 1, 1, "ASP.NET Core", "Learn ASP.NET Core", 10, 99 },
                    { 2, 2, "Photoshop Basics", "Learn the basics of Photoshop", 5, 49 },
                    { 3, 3, "Digital Marketing", "Introduction to Digital Marketing", 8, 79 }
                });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "Id", "EnrollmentId", "VideoId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_VideoId",
                table: "Progresses",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Enrollments_EnrollmentId",
                table: "Progresses",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Videos_VideoId",
                table: "Progresses",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_AccountId1",
                table: "Users",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Enrollments_EnrollmentId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Videos_VideoId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_AccountId1",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Progresses",
                table: "Progresses");

            migrationBuilder.DropIndex(
                name: "IX_Progresses_VideoId",
                table: "Progresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "322337c3-589f-4e5f-9681-b2357a142e90");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "7fdd22b5-e225-4071-8a1a-a4742bf984fc");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "b983ee66-785a-496e-a2a5-ecc5a859d4a4");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "requests");

            migrationBuilder.RenameTable(
                name: "Progresses",
                newName: "Progress");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Progresses_EnrollmentId",
                table: "Progress",
                newName: "IX_Progress_EnrollmentId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_requests",
                table: "requests",
                column: "RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Progress",
                table: "Progress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_UserId",
                table: "Progress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Enrollments_EnrollmentId",
                table: "Progress",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Users_UserId",
                table: "Progress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Account_AccountId1",
                table: "Users",
                column: "AccountId1",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
