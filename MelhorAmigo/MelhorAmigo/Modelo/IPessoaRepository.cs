using System.Collections.Generic;
using System.Threading.Tasks;

namespace MelhorAmigo.Modelo
{
    public interface IPessoaRepository
    {
        Task Add(Pessoa pessoa);
        Task Update(Pessoa pessoa);
        Task Delete(string id);
        Task<Pessoa> GetPessoa(string id);
        Task<IEnumerable<Pessoa>> GetPessoa();
    }
}
