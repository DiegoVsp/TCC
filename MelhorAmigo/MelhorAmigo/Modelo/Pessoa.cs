using System;
using System.Collections.Generic;
using System.Text;


namespace MelhorAmigo.Modelo
{
    public class Pessoa
    {
        public string tipo;

        public string Nome { get; set; }
        
        public string Telefone { get; set; }
        
        public string Email { get; set; }

        public string data { get;set; }

        public Endereco endereco { get; set; }

       public Pessoa()
        {
            endereco = new Endereco();
        }

    }

}
