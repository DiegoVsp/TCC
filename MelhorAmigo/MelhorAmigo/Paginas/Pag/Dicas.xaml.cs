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
        }
        private void castracao(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Tips.Castracao());
        }
        private void vacinacao(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Tips.Vacinacao());
        }
        private void chipagem(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Tips.Chipagem());
        }
        private void adocao(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Tips.Adocao());
        }
        private void doacao(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Tips.DoacaoAnimais());
        }
        private void denuncias(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Tips.Denuncias());
        }
    }
}