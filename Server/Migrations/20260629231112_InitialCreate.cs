using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminHerramientas.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RazonSocial = table.Column<string>(type: "varchar(155)", unicode: false, maxLength: 155, nullable: false),
                    RFC = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    EsAgencia = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    fechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuarioModifico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empresas__3214EC07727B5B99", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Herramientas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Herramie__3214EC0786FC08B3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intervalos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marcavehiculo = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    intervalo_dias = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    usuario_modifico = table.Column<int>(type: "int", nullable: true),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervalos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operarios",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Seccion = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: true),
                    IdTaller = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuarioModifico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Operario__06370DAD992741FD", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTarea = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    comisionTarea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    IDV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FECHAFIN = table.Column<DateTime>(type: "date", nullable: false),
                    BASTIDOR = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    MARCA = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    DES_MARCA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MODELO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DES_MODELO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COLOR = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DES_COLOR = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KM = table.Column<decimal>(type: "numeric(10,0)", nullable: true),
                    FAMILIA = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DES_FAMILIA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ANIO_VEHI = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehiculo__C4971C38CDABDCC6", x => x.IDV);
                    table.UniqueConstraint("AK_Vehiculos_BASTIDOR", x => x.BASTIDOR);
                });

            migrationBuilder.CreateTable(
                name: "Concesionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(155)", unicode: false, maxLength: 155, nullable: false),
                    fk_IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Localidad = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__concesio__3214EC07B3684BDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concesionarios_Empresas",
                        column: x => x.fk_IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HerramientasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_IdHerramienta = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FechaCompra = table.Column<DateTime>(type: "date", nullable: true),
                    Disponible = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Activo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Estado = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Etiqueta = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Herrrami__3214EC07BA3C80B3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HerramientasDetalles_Herramientas",
                        column: x => x.Fk_IdHerramienta,
                        principalTable: "Herramientas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_codigoOperario = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    nip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nips_Operarios_fk_codigoOperario",
                        column: x => x.fk_codigoOperario,
                        principalTable: "Operarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_codigoOperario = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    fk_codigoEncargado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    motivo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    codigoServicio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fechaSolicitud = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prestamo__C9249103DF55833E", x => x.IdPrestamos);
                    table.ForeignKey(
                        name: "FK_Prestamos_Encargado",
                        column: x => x.fk_codigoEncargado,
                        principalTable: "Operarios",
                        principalColumn: "Codigo");
                    table.ForeignKey(
                        name: "FK_Prestamos_Operarios",
                        column: x => x.fk_codigoOperario,
                        principalTable: "Operarios",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateTable(
                name: "Registros_lavados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_codigoOperario = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    fk_IdTarea = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    comisionRegistro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    fk_bastidor = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros_lavados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lavados_Operarios",
                        column: x => x.fk_codigoOperario,
                        principalTable: "Operarios",
                        principalColumn: "Codigo");
                    table.ForeignKey(
                        name: "FK_Lavados_Tareas",
                        column: x => x.fk_IdTarea,
                        principalTable: "Tareas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lavados_Vehiculo_Bastidor",
                        column: x => x.fk_bastidor,
                        principalTable: "Vehiculos",
                        principalColumn: "BASTIDOR");
                });

            migrationBuilder.CreateTable(
                name: "historial_mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_bastidor = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    fechaMantenimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdConcesionario = table.Column<int>(type: "int", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historial_Concesionarios",
                        column: x => x.IdConcesionario,
                        principalTable: "Concesionarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Historial_Vehiculo_Bastidor",
                        column: x => x.fk_bastidor,
                        principalTable: "Vehiculos",
                        principalColumn: "BASTIDOR");
                });

            migrationBuilder.CreateTable(
                name: "Prestamos_Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_IdPrestamo = table.Column<int>(type: "int", nullable: false),
                    fk_IdHerramienta = table.Column<int>(type: "int", nullable: false),
                    fechaEntrega = table.Column<DateTime>(type: "date", nullable: true),
                    comentario = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModifico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prestamo__3214EC07C59C3ECB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrestamosDetalle_Prestamos",
                        column: x => x.fk_IdPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamos");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concesionarios_fk_IdEmpresa",
                table: "Concesionarios",
                column: "fk_IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_HerramientasDetalle_Fk_IdHerramienta",
                table: "HerramientasDetalle",
                column: "Fk_IdHerramienta");

            migrationBuilder.CreateIndex(
                name: "IX_historial_mantenimientos_fk_bastidor",
                table: "historial_mantenimientos",
                column: "fk_bastidor");

            migrationBuilder.CreateIndex(
                name: "IX_historial_mantenimientos_IdConcesionario",
                table: "historial_mantenimientos",
                column: "IdConcesionario");

            migrationBuilder.CreateIndex(
                name: "IX_Nips_fk_codigoOperario",
                table: "Nips",
                column: "fk_codigoOperario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_fk_codigoEncargado",
                table: "Prestamos",
                column: "fk_codigoEncargado");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_fk_codigoOperario",
                table: "Prestamos",
                column: "fk_codigoOperario");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_Detalle_fk_IdPrestamo",
                table: "Prestamos_Detalle",
                column: "fk_IdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_lavados_fk_bastidor",
                table: "Registros_lavados",
                column: "fk_bastidor");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_lavados_fk_codigoOperario",
                table: "Registros_lavados",
                column: "fk_codigoOperario");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_lavados_fk_IdTarea",
                table: "Registros_lavados",
                column: "fk_IdTarea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HerramientasDetalle");

            migrationBuilder.DropTable(
                name: "historial_mantenimientos");

            migrationBuilder.DropTable(
                name: "Intervalos");

            migrationBuilder.DropTable(
                name: "Nips");

            migrationBuilder.DropTable(
                name: "Prestamos_Detalle");

            migrationBuilder.DropTable(
                name: "Registros_lavados");

            migrationBuilder.DropTable(
                name: "Herramientas");

            migrationBuilder.DropTable(
                name: "Concesionarios");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Operarios");
        }
    }
}
