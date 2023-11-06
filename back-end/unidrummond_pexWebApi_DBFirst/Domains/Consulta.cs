﻿using System;
using System.Collections.Generic;

namespace unidrummond_pexWebApi_DBFirst.Domains;

public partial class Consulta
{
    public int IdConsulta { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdMedico { get; set; }

    public DateTime DataConsulta { get; set; }

    public int? IdSituacao { get; set; }

    public string? Descricao { get; set; }

    public virtual Medico? IdMedicoNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual Situacao? IdSituacaoNavigation { get; set; }
}
