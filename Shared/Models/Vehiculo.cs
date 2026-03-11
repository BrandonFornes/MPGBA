using System;
using System.Collections.Generic;

namespace AdminHerramientas.Shared.Models;

public partial class Vehiculo
{
    public DateTime Fechafin { get; set; }

    public string Idv { get; set; } = null!;

    public string? Bastidor { get; set; }

    public string? Marca { get; set; }

    public string? DesMarca { get; set; }

    public string? Modelo { get; set; }

    public string? DesModelo { get; set; }

    public string? Color { get; set; }

    public string? DesColor { get; set; }

    public decimal? Km { get; set; }

    public string? Familia { get; set; }

    public string? DesFamilia { get; set; }

    public string? AnioVehi { get; set; }
}
