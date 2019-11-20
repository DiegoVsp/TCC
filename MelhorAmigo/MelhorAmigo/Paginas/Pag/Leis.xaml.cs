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
            ListaLei.Add(new Lei() { nome = "Lei 1", info = "lei dos animais" });
            ListaLei.Add(new Lei() { nome = "Lei 2" });
            ListaLei.Add(new Lei() { nome = "Lei 3" });
            ListaLei.Add(new Lei() { nome = "Lei 4" });
            ListaLei.Add(new Lei() { nome = "Lei 5" });

            ListaLeis.ItemsSource = ListaLei;

        }
    }
}