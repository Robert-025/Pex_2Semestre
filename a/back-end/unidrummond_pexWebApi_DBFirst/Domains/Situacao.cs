using System;
using System.Collections.Generic;

namespace unidrummond_pexWebApi_DBFirst.Domains;

public partial class Situacao
{
    public int IdSituacao { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}
