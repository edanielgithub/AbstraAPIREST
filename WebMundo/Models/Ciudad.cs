using System;
using System.Collections.Generic;

namespace WebMundo.Models;

public partial class Ciudad
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Poblacion { get; set; }

    public decimal? Superficie { get; set; }

    public string? Pais { get; set; }

    public DateTime? FecCreacion { get; set; }

    public DateTime? FecAct { get; set; }
}
