using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace MelhorAmigo.Modelo
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDb;
        public MongoDbContext()
        {
            var client = new MongoClient("mongodb+srv://diegovespa:<password>@sos-melhor-amigo-k9t9y.azure.mongodb.net/test?retryWrites=true&w=majority");
            _mongoDb = client.GetDatabase("sosDB");
        }
        public IMongoCollection<Pessoa> Pessoa
        {
            get
            {
                return _mongoDb.GetCollection<Pessoa>("Pessoa");
            }
        }
    }
}
