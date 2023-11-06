using System;
using System.Collections.Generic;

namespace unidrummond_pexWebApi_DBFirst.Domains;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public int? IdUsuario { get; set; }

    public long? Telefone { get; set; }

    public string Rg { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
