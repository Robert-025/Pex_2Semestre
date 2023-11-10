using System;
using System.Collections.Generic;

namespace unidrummond_pexWebApi_DBFirst.Domains;

public partial class Medico
{
    public int? IdUsuario { get; set; }

    public int IdMedico { get; set; }

    public string Crm { get; set; } = null!;

    public int? IdEspecialidade { get; set; }

    public int? IdClinica { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Clinica IdClinicaNavigation { get; set; }

    public virtual Especialidade IdEspecialidadeNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }
}
