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
            throw new NotImplementedException();
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
        public Clinica GetClinica(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todas as clínicas com seus médicos 
        /// </summary>
        /// <returns>Uma lista de clínicas com seus médicos</returns>
        public List<Clinica> GetMedicos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastra uma nova clínica  
        /// </summary>
        /// <param name="novaClinica">Objeto com as informações que serão cadastradas</param>
        public void RegisterClinica(Clinica novaClinica)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Atualiza uma clínica específica
        /// </summary>
        /// <param name="id">ID da clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com o s campos que serão atualizados</param>
        public void UpdateClinica(int id, Clinica clinicaAtualizada)
        {
            throw new NotImplementedException();
        }
    }
}
