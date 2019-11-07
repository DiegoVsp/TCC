using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MelhorAmigo.Modelo
{
    public class PessoaRepository: IPessoaRepository
    {
        MongoDbContext db = new MongoDbContext();
        public async Task Add(Pessoa Pessoa, Pessoa pessoa)
        {
            try
            {
                await db.Pessoa.InsertOneAsync(pessoa);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Pessoa> GetPessoa(string id)
        {
            try
            {
                FilterDefinition<Pessoa> filter = Builders<Pessoa>.Filter.Eq("Id", id);
                return await db.Pessoa.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Pessoa>> GetPessoa()
        {
            try
            {
                return await db.Pessoa.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Pessoa pessoa)
        {
            try
            {
                await db.Pessoa.ReplaceOneAsync(filter: g => g.Id == pessoa.Id, replacement: pessoa);
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Pessoa> data = Builders<Pessoa>.Filter.Eq("Id", id);
                await db.Pessoa.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }

        public Task Add(Pessoa pessoa)
        {
            throw new System.NotImplementedException();
        }
    }
}
