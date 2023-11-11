using Microsoft.EntityFrameworkCore;
using unidrummond_pexWebApi_DBFirst.Domains;
using unidrummond_pexWebApi_DBFirst.Interfaces;

namespace unidrummond_pexWebApi_DBFirst.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Objeto por onde serão chamado os métodos do Entity Framework Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Deleta uma clínica
        /// </summary>
        /// <param name="id">ID da clínica que será deletada</param>
        public void DeleteClinica(int id)
        {
            //Busca uma clinica pelo seu id
            Clinica clinicaBuscada = GetClinicaById(id);

            //Remove a clinica buscada da lista de clinicas
            ctx.Clinicas.Remove(clinicaBuscada);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as clínicas cadastradas no projeto
        /// </summary>
        /// <returns>Uma lista de clínicas</returns>
        public List<Clinica> GetAllClinicas()
        {
            //Usa o contexto para retornar uma lista com todas as clínicas
            return ctx.Clinicas.ToList();
        }

        /// <summary>
        /// Busca uma clínica específica   
        /// </summary>
        /// <param name="id">Id da clínica que será buscada</param>
        /// <returns>A clínica desejada</returns>
        public Clinica GetClinicaById(int id)
        {
            //Retorna a clinica buscada pelo ID
            return ctx.Clinicas.Find(id);
        }

        /// <summary>
        /// Lista todas as clínicas com seus médicos 
        /// </summary>
        /// <returns>Uma lista de clínicas com seus médicos</returns>
        public List<Clinica> GetMedicos()
        {
            //Retorna a lista de clinicas incluindo os médicos
            return ctx.Clinicas.Include(c => c.Medicos).ToList();
        }

        /// <summary>
        /// Cadastra uma nova clínica  
        /// </summary>
        /// <param name="novaClinica">Objeto com as informações que serão cadastradas</param>
        public void RegisterClinica(Clinica novaClinica)
        {
            //Adiciona a nova clinica na tabela de clinicas
            ctx.Clinicas.Add(novaClinica);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma clínica específica
        /// </summary>
        /// <param name="id">ID da clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com o s campos que serão atualizados</param>
        public void UpdateClinica(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = GetClinicaById(id);

            //Verifica se o campo razaoSocial novo foi informado
            if (clinicaAtualizada.RazaoSocial != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }

            //Verifica se o campo nomeClinica novo foi informado
            if (clinicaAtualizada.NomeClinica != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.NomeClinica = clinicaAtualizada.NomeClinica;
            }

            //Verifica se o campo endereco novo foi informado
            if (clinicaAtualizada.Endereco != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            //Verifica se o campo cnpj novo foi informado
            if (clinicaAtualizada.Cnpj != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            }

            //Verifica se o campo horarioAbertura novo foi informado
            if (clinicaAtualizada.HorarioAbertura != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
            }

            //Verifica se o campo horarioFechamento novo foi informado
            if (clinicaAtualizada.HorarioFechamento != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;
            }

            //Atualiza a clinicaBuscada
            ctx.Clinicas.Update(clinicaBuscada);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }
    }
}
