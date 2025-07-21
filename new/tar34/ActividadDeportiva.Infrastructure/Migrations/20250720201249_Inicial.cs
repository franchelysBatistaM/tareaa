using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActividadDeportiva.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoKg = table.Column<double>(type: "float", nullable: false),
                    AlturaCm = table.Column<double>(type: "float", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "AlturaCm", "Apellido", "Correo", "FechaNacimiento", "Genero", "Nombre", "PesoKg", "Telefono" },
                values: new object[,]
                {
                    { 1, 160.0, "Batista", "Franche.fit@gmail.com", new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Femenina", "Franchelys", 40.0, "809-418-2018" },
                    { 2, 185.0, "Batista", "Frank.entrenamiento@gmail.com", new DateTime(1988, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Frankjerson", 78.0, "829-999-6088" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
