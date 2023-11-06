using System;
using System.Collections.Generic;

namespace unidrummond_pexWebApi_DBFirst.Domains;

public partial class Especialidade
{
    public int IdEspecialidade { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
