using unidrummond_pexWebApi_DBFirst.Domains;
using unidrummond_pexWebApi_DBFirst.Interfaces;

namespace unidrummond_pexWebApi_DBFirst.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// Objeto por onde serão chamado os métodos do Entity Framework Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Deleta uma especialidade por ID
        /// </summary>
        /// <param name="id">ID da especialidade deletada</param>
        public void DeleteEspecialidade(int id)
        {
            //Busca uma especialidade 
            Especialidade especialidadeBuscada = GetEspecialidadeById(id);

            //Remove a especialidade buscada da tabela
            ctx.Especialidades.Remove(especialidadeBuscada);

            //Salva as alterações na tabela
            ctx.SaveChanges();
        }

        /// <summary>
        /// Método responsável por listar todas as especialidades
        /// </summary>
        /// <returns>Uma lista com as especialidades</returns>
        public List<Especialidade> GetAllEspecialidades()
        {
            //Retorna uma lista das especialidades
            return ctx.Especialidades.ToList();
        }

        /// <summary>
        /// Lista uma especialidade pelo seu ID
        /// </summary>
        /// <param name="id">ID da especialidade buscada</param>
        /// <returns>A especialidade buscada</returns>
        public Especialidade GetEspecialidadeById(int id)
        {
            //Retorna a clinica buscada pelo ID passadi
            return ctx.Especialidades.Find(id);
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Especialidade nova a ser cadastrada</param>
        public void RegisterEspecialidade(Especialidade novaEspecialidade)
        {
            //Adiciona a especia
            ctx.Especialidades.Add(novaEspecialidade);

            //Salva a nova especialidade
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma especialidade
        /// </summary>
        /// <param name="id">ID da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com os novos parametros da especialidade</param>
        public void UpdateEspecialidade(int id, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = GetEspecialidadeById(id);

            //Verifica se o campo Nome novo foi informado
            if (especialidadeAtualizada.Nome != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                especialidadeBuscada.Nome = especialidadeAtualizada.Nome;
            }
        }
    }
}
