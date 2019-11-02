﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MelhorAmigo.Paginas.Pag
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Apoie : ContentPage
    {
        public Apoie()
        {
            InitializeComponent();
        }
        private void apoiar(object sender, EventArgs args)
        {
            if (rdbDez.IsChecked)
            {
                Navigation.PushAsync(new Doacoes.DoarDez());
            }
            else if (rdbVinte.IsChecked)
            {
                Navigation.PushAsync(new Doacoes.DoarVinte());
                //DisplayAlert("Olá", "Opção de R$ 20,00 escolhida", "OK");
            }
            else if (rdbTrinta.IsChecked)
            {
                Navigation.PushAsync(new Doacoes.DoarTrinta());
                //DisplayAlert("Olá", "Opção de R$ 30,00 escolhida", "OK");
            }
            else if (rdbQuarenta.IsChecked)
            {
                Navigation.PushAsync(new Doacoes.DoarQuarenta());
                //DisplayAlert("Olá", "Opção de R$ 40,00 escolhida", "OK");
            }
            else if (rdbCinquenta.IsChecked)
            {
                Navigation.PushAsync(new Doacoes.DoarCinquenta());
                //DisplayAlert("Olá", "Opção de R$ 50,00 escolhida", "OK");
            }
        }
    }
}