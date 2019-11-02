﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MelhorAmigo.Paginas.Inicio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuInicio : ContentPage
    {
        public MenuInicio()
        {
            InitializeComponent();
        }
        private void apoie(object sender, EventArgs args)
        {
            //App.Current.MainPage = new NavigationPage(new Pag.Apoie()) { BarBackgroundColor = Color.Black };
            Navigation.PushAsync(new Pag.Apoie());

        }
        private void adote(object sender, EventArgs args)
        {
            //App.Current.MainPage = new NavigationPage(new Pag.Adote()) { BarBackgroundColor = Color.Black };
            Navigation.PushAsync(new Pag.Adote());
        }
    }
}