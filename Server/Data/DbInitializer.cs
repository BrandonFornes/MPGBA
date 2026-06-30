using System;
using System.Linq;
using AdminHerramientas.Server.Models;
using AdminHerramientas.Shared.Models;

namespace AdminHerramientas.Server.Data;
    public static class DbInitializer
    {
        public static void Seed(AlpContext context)
        {
            var hoy = DateTime.Now;

            // 1. SEED: EMPRESAS
            if (!context.Empresas.Any())
            {
                context.Empresas.AddRange(
                    new Empresa { Id = 1, RazonSocial = "Corporativo Automotriz del Noroeste", RFC = "CAN101010AA1", EsAgencia = true, Activo = true, fechaModificacion = hoy, usuarioModifico = 1 },
                    new Empresa { Id = 2, RazonSocial = "Servicios Industriales Obregón", RFC = "SIO202020BB2", EsAgencia = false, Activo = true, fechaModificacion = hoy, usuarioModifico = 1 }
                );
                context.SaveChanges();
            }

            // 2. SEED: CONCESIONARIOS
            if (!context.Concesionarios.Any())
            {
                context.Concesionarios.AddRange(
                    new Concesionario { Id = 101, Nombre = "Toyota Obregón Centro", FkIdEmpresa = 1, Localidad = "Obregón", Activo = true, FechaModificacion = hoy, UsuarioModifico = 1 },
                    new Concesionario { Id = 102, Nombre = "Nissan Norte Talleres", FkIdEmpresa = 1, Localidad = "Hermosillo", Activo = true, FechaModificacion = hoy, UsuarioModifico = 1 }
                );
                context.SaveChanges();
            }

            // 3. SEED: INTERVALOS
            if (!context.Intervalos.Any())
            {
                context.Intervalos.AddRange(
                    new Intervalo { marcavehiculo = "TOY", Intervalo_dias = 180, Activo = true, UsuarioModifico = 1, FechaModificacion = hoy },
                    new Intervalo { marcavehiculo = "NIS", Intervalo_dias = 120, Activo = true, UsuarioModifico = 1, FechaModificacion = hoy }
                );
                context.SaveChanges();
            }

            // 4. SEED: VEHÍCULOS
            if (!context.Vehiculos.Any())
            {
                context.Vehiculos.AddRange(
                    new Vehiculo { Idv = "V001", Bastidor = "TOY123456789X", Marca = "TOY", DesMarca = "Toyota", Modelo = "HILUX", DesModelo = "Hilux Doble Cabina", Color = "BLA", DesColor = "Blanco", Km = 45000, AnioVehi = "2024", Fechafin = hoy.AddYears(5) },
                    new Vehiculo { Idv = "V002", Bastidor = "NIS987654321Z", Marca = "NIS", DesMarca = "Nissan", Modelo = "NP300", DesModelo = "NP300 Chasis", Color = "GRI", DesColor = "Gris Plata", Km = 12000, AnioVehi = "2025", Fechafin = hoy.AddYears(6) }
                );
                context.SaveChanges();
            }

            // 5. SEED: HISTORIAL DE MANTENIMIENTOS
            if (!context.HistorialMantenimientos.Any())
            {
                context.HistorialMantenimientos.AddRange(
                    new HistorialMantenimiento { FkBastidor = "TOY123456789X", fechaMantenimiento = hoy.AddDays(-200), IdConcesionario = 101, FechaModificacion = hoy, UsuarioModifico = 1, Activo = true },
                    new HistorialMantenimiento { FkBastidor = "NIS987654321Z", fechaMantenimiento = hoy.AddDays(-10), IdConcesionario = 102, FechaModificacion = hoy, UsuarioModifico = 1, Activo = true }
                );
                context.SaveChanges();
            }

            // 6. SEED: HERRAMIENTAS
            if (!context.Herramientas.Any())
            {
                context.Herramientas.AddRange(
                    new Herramienta { Tipo = "Escáner Automotriz", FechaModificacion = hoy, UsuarioModifico = 1, Activo = true },
                    new Herramienta { Tipo = "Pistola de Impacto", FechaModificacion = hoy, UsuarioModifico = 1, Activo = true }
                );
                context.SaveChanges();
            }

            // 7. SEED: DETALLE DE HERRAMIENTAS
            if (!context.HerramientasDetalles.Any())
            {
                var herramientas = context.Herramientas.ToList();
                context.HerramientasDetalles.AddRange(
                    new HerramientasDetalle { FkIdHerramienta = herramientas[0].Id, Descripcion = "Launch X431 Pro V", FechaCompra = hoy.AddMonths(-12), Disponible = true, Activo = true, Estado = "Excelente", Etiqueta = "ESC-01", FechaModificacion = hoy, UsuarioModifico = 1 },
                    new HerramientasDetalle { FkIdHerramienta = herramientas[1].Id, Descripcion = "Milwaukee M18 Fuel 1/2", FechaCompra = hoy.AddMonths(-6), Disponible = true, Activo = true, Estado = "Bueno", Etiqueta = "PIS-02", FechaModificacion = hoy, UsuarioModifico = 1 }
                );
                context.SaveChanges();
            }

            // 8. SEED: OPERARIOS
            if (!context.Operarios.Any())
            {
                context.Operarios.AddRange(
                    new Operario { Codigo = "OP-001", Nombre = "Juan Pérez López", Seccion = "Mecánica General", IdTaller = 1, Activo = true, FechaModificacion = hoy, UsuarioModifico = 1 },
                    new Operario { Codigo = "ENC-02", Nombre = "Carlos Mendoza", Seccion = "Supervisor de Taller", IdTaller = 1, Activo = true, FechaModificacion = hoy, UsuarioModifico = 1 }
                );
                context.SaveChanges();
            }

            // 9. SEED: NIPS
            if (!context.Nips.Any())
            {
                context.Nips.AddRange(
                    new Nip { Fk_codigoOperario = "OP-001", ValorNip = "1234", FechaModificacion = hoy, UsuarioModifico = 1, Activo = true },
                    new Nip { Fk_codigoOperario = "ENC-02", ValorNip = "4321", FechaModificacion = hoy, UsuarioModifico = 1, Activo = true }
                );
                context.SaveChanges();
            }

            // 10. SEED: TAREAS
            if (!context.Tareas.Any())
            {
                context.Tareas.AddRange(
                    new Tarea { NombreTarea = "Lavado de Motor Completo", ComisionTarea = 150.00m, FechaModificacion = hoy, UsuarioModifico = 1, Activo = true },
                    new Tarea { NombreTarea = "Lavado de Carrocería y Aspirado", ComisionTarea = 80.00m, FechaModificacion = hoy, UsuarioModifico = 1, Activo = true }
                );
                context.SaveChanges();
            }

            // 11. SEED: REGISTROS DE LAVADO
            if (!context.RegistrosLavados.Any())
            {
                var tarea = context.Tareas.First();
                context.RegistrosLavados.AddRange(
                    new RegistrosLavado { FkCodigoOperario = "OP-001", FkIdTarea = tarea.Id, Fecha = hoy, ComisionRegistro = tarea.ComisionTarea, FechaModificacion = hoy, UsuarioModifico = 1, Activo = true, FkBastidor = "TOY123456789X" }
                );
                context.SaveChanges();
            }

            // 12. SEED: PRÉSTAMOS
            if (!context.Prestamos.Any())
            {
                context.Prestamos.AddRange(
                    new Prestamo { FkCodigoOperario = "OP-001", FkCodigoEncargado = "ENC-02", Motivo = "Diagnóstico de Check Engine", CodigoServicio = "SERV-992", FechaSolicitud = hoy.AddHours(-2), FechaModificacion = hoy, UsuarioModifico = 1, Activo = true }
                );
                context.SaveChanges();
            }

            // 13. SEED: PRÉSTAMOS DETALLE
            if (!context.PrestamosDetalles.Any())
            {
                var prestamo = context.Prestamos.First();
                var herramientaDetalle = context.HerramientasDetalles.First();
                context.PrestamosDetalles.AddRange(
                    new PrestamosDetalle { FkIdPrestamo = prestamo.IdPrestamos, FkIdHerramienta = herramientaDetalle.Id, FechaEntrega = null, Comentario = "Se entrega con estuche completo", Activo = true, FechaModificacion = hoy, UsuarioModifico = 1 }
                );
                context.SaveChanges();
            }
        }
    }