using System;
using System.Collections.Generic;

namespace unidrummond_pexWebApi_DBFirst.Domains;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdTipo { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public string Senha { get; set; } = null!;

    public virtual TiposUsuario? IdTipoNavigation { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
