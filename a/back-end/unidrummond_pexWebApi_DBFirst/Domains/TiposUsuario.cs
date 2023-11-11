using System;
using System.Collections.Generic;

namespace unidrummond_pexWebApi_DBFirst.Domains;

public partial class TiposUsuario
{
    public int IdTipo { get; set; }

    public string TituloTipo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
