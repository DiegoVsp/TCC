using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelhorAmigo.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MelhorAmigo.Paginas.Formulario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gato : ContentPage
    {
        public Gato()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            Endereco end = ViaCep.BuscarEnderecoViaCep(cep);

            ENDERECO.Text = end.logradouro;
            BAIRRO.Text = end.bairro;
            CEP.Text = end.cep;
            CIDADE.Text = end.localidade;
            UF.Text = end.uf;
        }


        public class MaskedBehavior : Behavior<Entry>
        {
            private string _mask = "";
            public string Mask
            {
                get => _mask;
                set
                {
                    _mask = value;
                    SetPositions();
                }
            }

            protected override void OnAttachedTo(Entry entry)
            {
                entry.TextChanged += OnEntryTextChanged;
                base.OnAttachedTo(entry);
            }

            protected override void OnDetachingFrom(Entry entry)
            {
                entry.TextChanged -= OnEntryTextChanged;
                base.OnDetachingFrom(entry);
            }

            IDictionary<int, char> _positions;

            void SetPositions()
            {
                if (string.IsNullOrEmpty(Mask))
                {
                    _positions = null;
                    return;
                }

                var list = new Dictionary<int, char>();
                for (var i = 0; i < Mask.Length; i++)
                    if (Mask[i] != 'X')
                        list.Add(i, Mask[i]);

                _positions = list;
            }

            private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
            {
                var entry = sender as Entry;

                var text = entry.Text;

                if (string.IsNullOrWhiteSpace(text) || _positions == null)
                    return;

                if (text.Length > _mask.Length)
                {
                    entry.Text = text.Remove(text.Length - 1);
                    return;
                }

                foreach (var position in _positions)
                    if (text.Length >= position.Key + 1)
                    {
                        var value = position.Value.ToString();
                        if (text.Substring(position.Key, 1) != value)
                            text = text.Insert(position.Key, value);
                    }

                if (entry.Text != text)
                    entry.Text = text;
            }
        }
    }
}