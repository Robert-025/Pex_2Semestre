 using System;
using System.Collections.Generic;

namespace unidrummond_pexWebApi_DBFirst.Domains;

public partial class Clinica
{
    public int IdClinica { get; set; }

    public string RazaoSocial { get; set; } = null!;

    public string NomeClinica { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public TimeSpan? HorarioAbertura { get; set; }

    public TimeSpan? HorarioFechamento { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
