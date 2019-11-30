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
            ListaLei.Add(new Lei() { id = 1, nome = "LEI COMPLEMENTAR Nº827/12", info = "Política municipal de proteção aos animais" });
            ListaLei.Add(new Lei() { id = 2, nome = "LEI MUNICIPAL Nº8.716/16", info = "Regulamenta os eventos de adoção de animais domésticos " });
            ListaLei.Add(new Lei() { id = 3, nome = "LEI COMPLEMENTAR Nº 896/18", info = "Medidas confinamento de animais" });
            ListaLei.Add(new Lei() { id = 4, nome = "LEI ORDINÁRIA Nº7929/13", info="Criação do fundo municipal de Proteção à fauna" });
            ListaLei.Add(new Lei() { id = 5, nome = "LEI COMPLEMENTAR Nº 877", info = "" });

            ListaLeis.ItemsSource = ListaLei;

        }

        async private void ListaLeis_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelecionado = e.Item as Lei;
            switch (itemSelecionado.id)
            {
                case 1:
                    await Navigation.PushAsync(new Paginas.Laws.Lei_Num_827_12());
                    break;
                case 2:
                    await Navigation.PushAsync(new Paginas.Laws.Lei_Num_8716_16());
                    break;
                case 3:
                    await Navigation.PushAsync(new Paginas.Laws.Lei_Num_896_18());
                    break;
                case 4:
                    await Navigation.PushAsync(new Paginas.Laws.Lei_Num_7929_13());
                    break;
                case 5:
                    await Navigation.PushAsync(new Paginas.Laws.Lei_Num_877_16());
                    break;

            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}