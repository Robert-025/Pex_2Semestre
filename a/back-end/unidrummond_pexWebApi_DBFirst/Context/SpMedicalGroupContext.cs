using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using unidrummond_pexWebApi_DBFirst.Domains;

namespace unidrummond_pexWebApi_DBFirst.Context;

public partial class SpMedicalGroupContext : DbContext
{
    public SpMedicalGroupContext()
    {
    }

    public SpMedicalGroupContext(DbContextOptions<SpMedicalGroupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinica> Clinicas { get; set; }

    public virtual DbSet<Consulta> Consultas { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Situacao> Situacoes { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=SPMedicalGroup2; Trusted_Connection=true; user id=sa; pwd=Paiemae2@; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasKey(e => e.IdClinica).HasName("PK__clinicas__C73A6055D6238E4A");

            entity.ToTable("clinicas");

            entity.HasIndex(e => e.Cnpj, "UQ__clinicas__35BD3E48A1E9FF63").IsUnique();

            entity.HasIndex(e => e.Endereco, "UQ__clinicas__9456D4065DC22109").IsUnique();

            entity.Property(e => e.IdClinica).HasColumnName("idClinica");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cnpj");
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.HorarioAbertura).HasColumnName("horarioAbertura");
            entity.Property(e => e.HorarioFechamento).HasColumnName("horarioFechamento");
            entity.Property(e => e.NomeClinica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nomeClinica");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("razaoSocial");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__consulta__CA9C61F532C0AC08");

            entity.ToTable("consultas");

            entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");
            entity.Property(e => e.DataConsulta)
                .HasColumnType("smalldatetime")
                .HasColumnName("dataConsulta");
            entity.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.IdMedico).HasColumnName("idMedico");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.IdSituacao)
                .HasDefaultValueSql("((1))")
                .HasColumnName("idSituacao");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdMedico)
                .HasConstraintName("FK__consultas__idMed__52593CB8");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__consultas__idPac__5165187F");

            entity.HasOne(d => d.IdSituacaoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdSituacao)
                .HasConstraintName("FK__consultas__idSit__534D60F1");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidade).HasName("PK__especial__4096980598857504");

            entity.ToTable("especialidades");

            entity.HasIndex(e => e.Nome, "UQ__especial__6F71C0DC338956EF").IsUnique();

            entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__medicos__4E03DEBA1B89252C");

            entity.ToTable("medicos");

            entity.HasIndex(e => e.Crm, "UQ__medicos__D836F7D1CF40CBF2").IsUnique();

            entity.Property(e => e.IdMedico).HasColumnName("idMedico");
            entity.Property(e => e.Crm)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("crm");
            entity.Property(e => e.IdClinica).HasColumnName("idClinica");
            entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdClinicaNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdClinica)
                .HasConstraintName("FK__medicos__idClini__4E88ABD4");

            entity.HasOne(d => d.IdEspecialidadeNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdEspecialidade)
                .HasConstraintName("FK__medicos__idEspec__4D94879B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__medicos__idUsuar__4CA06362");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__paciente__F48A08F2503B8722");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.Rg, "UQ__paciente__32143310E2D30B8A").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__paciente__D836E71F51C5020C").IsUnique();

            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cpf");
            entity.Property(e => e.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Rg)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rg");
            entity.Property(e => e.Telefone).HasColumnName("telefone");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__pacientes__idUsu__48CFD27E");
        });

        modelBuilder.Entity<Situacao>(entity =>
        {
            entity.HasKey(e => e.IdSituacao).HasName("PK__situacoe__12AFD1977BA32849");

            entity.ToTable("situacoes");

            entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descricao");
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__tiposUsu__BDD0DFE1EAEDB90D");

            entity.ToTable("tiposUsuarios");

            entity.HasIndex(e => e.TituloTipo, "UQ__tiposUsu__4908F7FAEFCF04D4").IsUnique();

            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.TituloTipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tituloTipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__645723A67109CCB4");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E61645E9CB29B").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("senha");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__usuarios__idTipo__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
