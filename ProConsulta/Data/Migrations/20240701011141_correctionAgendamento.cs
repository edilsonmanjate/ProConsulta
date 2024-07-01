using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class correctionAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Pacientes_MedicoId",
                table: "Agendamentos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f72e1dee-a25b-440e-8fb0-e69c9b569539", "AQAAAAIAAYagAAAAEKiu0h/AzAna9kSddJlp9nli0CYGimZQ2SlCBKHQhFx9dbsMgkg0TTnOis1IgkRP8Q==", "ceeddf06-a844-4966-928f-d27676397acb" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamentos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId",
                table: "Agendamentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamentos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e11fa76c-9fae-4d60-8d63-c5ca33d44333", "AQAAAAIAAYagAAAAEH+wkUtrGQVUOOx6d8biF3LrQRTLCuWF1lmr2IZJLR5TwFODA6o0lQfMw1Gk84Wj4g==", "c3fbcd8e-f9a2-4362-9ad4-ea667143b41f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Pacientes_MedicoId",
                table: "Agendamentos",
                column: "MedicoId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
