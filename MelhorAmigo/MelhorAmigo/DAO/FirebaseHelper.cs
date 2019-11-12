using Firebase.Database;
using MelhorAmigo.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorAmigo.DAO
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://sos-2-9e023.firebaseio.com/");

        public async Task<List<Pessoa>> GetAllPessoas()
        {

            return (await firebase
              .Child("Pessoas")
              .OnceAsync<Pessoa>()).Select(item => new Pessoa
              {

                  endereco = item.Object.endereco,
                  Nome = item.Object.Nome,
                  Telefone = item.Object.Telefone,
                  Email = item.Object.Email,
                 


              }).ToList();
        }
        public async Task AddPessoa(Pessoa pessoa)
        {
            var a = JsonConvert.SerializeObject(pessoa, Formatting.Indented);

            await firebase
              .Child("Pessoas")
              .PostAsync(a);
        }
    }
}
