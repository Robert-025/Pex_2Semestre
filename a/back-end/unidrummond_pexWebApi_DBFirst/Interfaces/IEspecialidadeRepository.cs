using unidrummond_pexWebApi_DBFirst.Domains;

namespace unidrummond_pexWebApi_DBFirst.Interfaces
{
    public interface IEspecialidadeRepository
    {
        /// <summary>
        /// Método responsável por listar todas as especialidades
        /// </summary>
        /// <returns>Uma lista com as especialidades</returns>
        List<Especialidade> GetAllEspecialidades();

        /// <summary>
        /// Lista uma especialidade pelo seu ID
        /// </summary>
        /// <param name="id">ID da especialidade buscada</param>
        /// <returns>A especialidade buscada</returns>
        Especialidade GetEspecialidadeById(int id);

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Especialidade nova a ser cadastrada</param>
        void RegisterEspecialidade(Especialidade novaEspecialidade);

        /// <summary>
        /// Deleta uma especialidade por ID
        /// </summary>
        /// <param name="id">ID da especialidade deletada</param>
        void DeleteEspecialidade(int id);

        /// <summary>
        /// Atualiza uma especialidade
        /// </summary>
        /// <param name="id">ID da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com os novos parametros da especialidade</param>
        void UpdateEspecialidade(int id,  Especialidade especialidadeAtualizada);
    }
}
