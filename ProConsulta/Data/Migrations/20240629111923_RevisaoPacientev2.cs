using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class RevisaoPacientev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e11fa76c-9fae-4d60-8d63-c5ca33d44333", "AQAAAAIAAYagAAAAEH+wkUtrGQVUOOx6d8biF3LrQRTLCuWF1lmr2IZJLR5TwFODA6o0lQfMw1Gk84Wj4g==", "c3fbcd8e-f9a2-4362-9ad4-ea667143b41f" });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Documento",
                table: "Pacientes",
                column: "Documento",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
