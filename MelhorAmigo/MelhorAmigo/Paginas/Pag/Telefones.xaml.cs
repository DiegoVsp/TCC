using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelhorAmigo.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MelhorAmigo.Paginas.Pag
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Telefones : ContentPage
    {
        public Telefones()
        {
            InitializeComponent();

            List<Tel> Lista = new List<Tel>();
            Lista.Add(new Tel() { Nome = "OUVIDORIA ANIMAL", Phone = "(16) 3303-3115 (7h às 13h)" });
            Lista.Add(new Tel() { Nome = "COLETA DE ANIMAIS MORTOS", Phone = "(16) 99750-4793" });
            Lista.Add(new Tel() { Nome = "ANIMAIS SILVESTRES", Phone = "0800-740-0440" });
            Lista.Add(new Tel() { Nome = "GUARDA MUNICIPAL", Phone = "(16) 3335-2370" });
            Lista.Add(new Tel() { Nome = "FEIRA DE ADOÇÃO ", Phone = "(16) 3301-1800" });

            ListaTelefones.ItemsSource = Lista;


        }


        //private async void Selecionado(object senders, SelectedItemChangedEventArgs e)
        //{
        //    Tel tel = e.SelectedItem as Tel;
        //    if(tel != null)
        //    {
        //        await DisplayAlert("Informações de Contato", $"{tel.Nome}", "OK");
        //    }
        //}
    }
}