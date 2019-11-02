﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MelhorAmigo.Paginas.Doacoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoarVinte : ContentPage
    {
        public DoarVinte()
        {
            InitializeComponent();
        }
        public void Carregando(object sender, EventArgs args)
        {
            LblStatus.Text = "Carregando...";
        }
        public void Carregado(object sender, EventArgs args)
        {
            LblStatus.Text = "Finalizado.";
        }
    }
}