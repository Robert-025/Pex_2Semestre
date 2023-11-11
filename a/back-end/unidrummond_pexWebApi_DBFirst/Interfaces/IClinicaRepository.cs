using unidrummond_pexWebApi_DBFirst.Domains;

namespace unidrummond_pexWebApi_DBFirst.Interfaces
{
    /// <summary>
    /// Responsável por ClinicaRepository
    /// </summary>
    public interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as clínicas cadastradas no projeto
        /// </summary>
        /// <returns>Uma lista de clínicas</returns>
        List<Clinica> GetAllClinicas();

        /// <summary>
        /// Busca uma clínica específica   
        /// </summary>
        /// <param name="id">Id da clínica que será buscada</param>
        /// <returns>A clínica desejada</returns>
        Clinica GetClinicaById(int id);

        /// <summary>
        /// Cadastra uma nova clínica  
        /// </summary>
        /// <param name="novaClinica">Objeto com as informações que serão cadastradas</param>
        void RegisterClinica(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma clínica específica
        /// </summary>
        /// <param name="id">ID da clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com o s campos que serão atualizados</param>
        void UpdateClinica(int id, Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma clínica
        /// </summary>
        /// <param name="id">ID da clínica que será deletada</param>
        void DeleteClinica(int id);

        /// <summary>
        /// Lista todas as clínicas com seus médicos 
        /// </summary>
        /// <returns>Uma lista de clínicas com seus médicos</returns>
        List<Clinica> GetMedicos();
    }
}
