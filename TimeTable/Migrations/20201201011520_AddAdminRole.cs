using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTable.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d501fafa-ce65-4318-a686-adf7fa89e8ed", "aa00c3b9-dd31-4121-84ca-d485d17c35fe" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d501fafa-ce65-4318-a686-adf7fa89e8ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa00c3b9-dd31-4121-84ca-d485d17c35fe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcc9e6f0-44a7-4d9a-9ac3-0153673831c6", "2a5e1e74-9d7f-47d9-8afa-71b513fbd95f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1723aa01-5d7a-486d-b87b-0d214560d08e", 0, "77e13a2b-e75a-4996-becb-cf0f15806b69", "IdentityUser", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJAlsvAoeL4F9IK5uGKqfq8Snhzni1oUTtPSHfLjTTwwQ4X0nhYTMIwVJVikEksecQ==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dcc9e6f0-44a7-4d9a-9ac3-0153673831c6", "1723aa01-5d7a-486d-b87b-0d214560d08e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dcc9e6f0-44a7-4d9a-9ac3-0153673831c6", "1723aa01-5d7a-486d-b87b-0d214560d08e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcc9e6f0-44a7-4d9a-9ac3-0153673831c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1723aa01-5d7a-486d-b87b-0d214560d08e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d501fafa-ce65-4318-a686-adf7fa89e8ed", "f4d5f9dc-ad66-4162-8790-a1abea5c51ce", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aa00c3b9-dd31-4121-84ca-d485d17c35fe", 0, "921cc7d3-a276-4277-abff-ba5b12779127", "IdentityUser", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAENKCK0sTN0sIgIkwn7yqpcMt6iLA4Z2JtVMVcDnIeSmcW4pZKJjwHArVDtzOx2RJpw==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d501fafa-ce65-4318-a686-adf7fa89e8ed", "aa00c3b9-dd31-4121-84ca-d485d17c35fe" });
        }
    }
}
