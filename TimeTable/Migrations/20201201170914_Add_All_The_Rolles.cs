using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTable.Migrations
{
    public partial class Add_All_The_Rolles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "086516e7-6d7e-4340-b6ef-0282c405bac6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a23af1e0-e6bd-4035-9493-7ed47f353cfb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b57697d-0223-4d70-8d50-fcc17f098723", "4ffbfd4b-7e14-4984-aa3f-963860bd77e8", "admin", "ADMIN" },
                    { "6edcb675-74d3-4a68-a7af-585e31970ce5", "66ca375b-83ff-45f9-a916-8213fe3400f5", "student", "STUDENT" },
                    { "43b1d8a3-c14f-4df2-bcf7-78a6a5c17ec9", "11e38eaf-526e-4ddf-b559-dc275cbc6795", "teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8435c51a-e666-424d-8fd2-35b00d91eff5", 0, "fee51f6f-f1fc-43ac-8adc-e7467e7878ab", "IdentityUser", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBNbVU32T7R2JD2AICT2jeR+hUvz1+2RZuym+mNjii4YhhiQ6dw9gNpnhgZVd1j+Vg==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9b57697d-0223-4d70-8d50-fcc17f098723", "8435c51a-e666-424d-8fd2-35b00d91eff5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43b1d8a3-c14f-4df2-bcf7-78a6a5c17ec9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6edcb675-74d3-4a68-a7af-585e31970ce5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b57697d-0223-4d70-8d50-fcc17f098723", "8435c51a-e666-424d-8fd2-35b00d91eff5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b57697d-0223-4d70-8d50-fcc17f098723");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8435c51a-e666-424d-8fd2-35b00d91eff5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a23af1e0-e6bd-4035-9493-7ed47f353cfb", "258c2afb-86b7-4b8c-866b-88a978c6e296", "student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "086516e7-6d7e-4340-b6ef-0282c405bac6", "0bf0bd38-435c-48fb-a683-8108c214f048", "teacher", "TEACHER" });
        }
    }
}
