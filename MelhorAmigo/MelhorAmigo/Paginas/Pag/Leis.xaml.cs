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
    public partial class Leis : ContentPage
    {
        public Leis()
        {
            InitializeComponent();
            List<Lei> ListaLei = new List<Lei>();
            ListaLei.Add(new Lei() { nome = "LEI COMPLEMENTAR Nº827/12", info = "Política municipal de proteção aos animais" });
            ListaLei.Add(new Lei() { nome = "LEI MUNICIPAL Nº8.716/16", info = "Regulamenta os eventos de adoção de animais domésticos " });
            ListaLei.Add(new Lei() { nome = "LEI COMPLEMENTAR Nº 896/18", info = "Medidas confinamento de animais" });
            ListaLei.Add(new Lei() { nome = "LEI ORDINÁRIA Nº7929/13", info="Criação do fundo municipal de Proteção à fauna" });
            ListaLei.Add(new Lei() { nome = "Lei 5", info = "" });

            ListaLeis.ItemsSource = ListaLei;

        }
    }
}