﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Service.Model;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Service
{
    public class ViaCEPService
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco buscarEnderecoViaCep(string cep)
        {
            string novoEnderecoURl = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.cep == null)
                return null;
            return end;
        }

    }
}
