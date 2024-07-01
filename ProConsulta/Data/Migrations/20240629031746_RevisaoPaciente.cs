using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class RevisaoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pacientes_Documento",
                table: "Pacientes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af6ca99-20bf-44fc-8c88-37350bb56402", "AQAAAAIAAYagAAAAEF32LjbiKmawzUfV93AmtNR4e3R0K8lcDIlZLN6F7XeAdkc1kzwKGhOs0/A/jumbqQ==", "02653f4f-0a52-484e-a836-0cd1cfb88d86" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5615c90-ec4d-4501-a57e-46b8dccc83c2", "AQAAAAIAAYagAAAAEFEXv1QlU5lLxw/RFILDVVJdE/AGM0kvt25a5PNhU4VCWjyhATVFHDedwWVKbfacqg==", "097ca640-3436-4cad-b0e8-8c115d865bc6" });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Documento",
                table: "Pacientes",
                column: "Documento",
                unique: true);
        }
    }
}
