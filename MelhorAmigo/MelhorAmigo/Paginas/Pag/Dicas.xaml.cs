using MelhorAmigo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MelhorAmigo.Paginas.Pag
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dicas : ContentPage
    {
        public Dicas()
        {
            InitializeComponent();
            List<dica> Dica = new List<dica>();
            Dica.Add(new dica() { nome = "Castração", info ="veja os cuidados pós castração" });
            Dica.Add(new dica() { nome = "Dica 2" });
            Dica.Add(new dica() { nome = "Dica 3" });
            Dica.Add(new dica() { nome = "Dica 4" });
            Dica.Add(new dica() { nome = "Dica 5" });

            ListaDicas.ItemsSource = Dica;
        }
    }
}