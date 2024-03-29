﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MelhorAmigo.Modelo;
using MelhorAmigo.DAO;

namespace MelhorAmigo.Paginas.Formulario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cachorro : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public Cachorro()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }


        private async void btnEnvia(object sender, EventArgs args)
        {
            var endereco = (new Endereco()
            {
                bairro = BAIRRO.Text,
                cep = CEP.Text,
                localidade = LOCALIDADE.Text,
                logradouro = LOGRADOURO.Text,
                numero = NUMERO.Text,
                uf = UF.Text
            });
            var pessoa = (new Pessoa()
            {
                Nome = NOME.Text,
                Email = EMAIL.Text,
                Telefone = TELEFONE.Text,
                endereco = endereco, //envia as informações de endereço para o banco
                Data =DateTime.Now,
                tipo = "Cachorro",

            });
            //
            await firebaseHelper.AddPessoa(pessoa);

            NOME.Text = string.Empty;
            CEP.Text = string.Empty;
            LOGRADOURO.Text = string.Empty;
            NUMERO.Text = string.Empty;
            BAIRRO.Text = string.Empty;
            LOCALIDADE.Text = string.Empty;
            TELEFONE.Text = string.Empty;
            EMAIL.Text = string.Empty;
            UF.Text = string.Empty;


            await DisplayAlert("Sucesso", "Formulário adicionado com sucesso", "OK");


            var allPessoas = await firebaseHelper.GetAllPessoas();

            try
            {
                if (!ValidarCampos())
                {

                }
            }
            catch
            {
                if (EMAIL.Text == null)
                {
                    _ = DisplayAlert("ERRO", "Preencha corretamente o campo E-MAIL", "OK");
                }
                if (CEP.Text == null)
                {
                    _ = DisplayAlert("ERRO", "Preencha corretamente o campo CEP", "OK");
                }
            }
        }
        private void BuscarCEP(object sender, EventArgs args)
        {

            try
            {
                string cep = CEP.Text.Trim();

                if (isValidCEP(cep))
                {
                    try
                    {

                        Endereco end = ViaCep.BuscarEnderecoViaCep(cep);

                        if (end != null)
                        {
                            LOGRADOURO.Text = end.logradouro;
                            BAIRRO.Text = end.bairro;
                            CEP.Text = end.cep;
                            LOCALIDADE.Text = end.localidade;
                            UF.Text = end.uf;
                        }
                        else
                        {
                            CEP.Text = "";
                        }


                    }
                    catch (Exception e)
                    {
                        DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                    }
                }
            }
            catch
            {

            }

        }
        private bool ValidarCampos()
        {
            bool formatoCorreto = true;
            if (EMAIL.Text != string.Empty)
            {
                if (!isValidEmail(EMAIL.Text))
                {
                    formatoCorreto = false;
                    DisplayAlert("ATENÇÃO", "O E-mail informado é inválido. Por favor verifique.", "OK");
                    EMAIL.Focus();
                    return formatoCorreto;
                }
                if (CEP.Text != string.Empty)

                {


                    if (!isValidCEP(CEP.Text))

                    {

                        formatoCorreto = false;

                        DisplayAlert("ATENÇÃO", "O CEP Informado é inválido. Por favor verifique.", "OK");

                        CEP.Focus();
                        return formatoCorreto;

                    }

                }
            }
            return formatoCorreto;
        }

        private bool isValidCEP(string cep)
        {
            {



                if (cep.Length == 8)

                {

                    cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);



                    CEP.Text = cep;

                }


                return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
            }
        }

        private bool isValidEmail(string email)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(email, ("(?<user>[^@]+)@(?<host>.+)"));
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