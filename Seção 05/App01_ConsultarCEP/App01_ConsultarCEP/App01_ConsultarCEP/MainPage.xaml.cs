using App01_ConsultarCEP.Service;
using App01_ConsultarCEP.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += buscarCep;
        }

        private void buscarCep(object sende, EventArgs args)
        {
            string cep = CEP.Text.Trim();

            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCEPService.buscarEnderecoViaCep(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0}, {1}, {2}", end.localidade, end.uf, end.logradouro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado", "Ok");
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("Erro crítico", e.Message, "Ok");
                }
            }
        }

        private bool isValidCep(string cep)
        {
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracters", "Ok");
                return false;
            }

            int novoCep = 0;
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números", "Ok");
                return false;
            }
            return true;             
        }
    }
}
