using System;
using System.Collections.Generic;

namespace WebMundo.Models;

public partial class Usuario
{
    public string Usr { get; set; } = null!;

    public string? Clave { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? FecCreacion { get; set; }

    public DateTime? FecAct { get; set; }

    public Usuario(string usr)
    {
        Usr = usr;
    }

    public string obtnerPwd()
    {

        return "";
    }


}
