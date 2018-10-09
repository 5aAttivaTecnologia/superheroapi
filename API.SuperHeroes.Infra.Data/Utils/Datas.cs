using System;
using System.Collections.Generic;
using System.Text;

namespace API.SuperHeroes.Infra.Data.Utils
{
    public static class Datas
    {
        public static int ObterIdadePorNascimento(DateTime dataNascimento)
        {
            var dataAtual = DateTime.Now;
            var idade = dataAtual.Year - dataNascimento.Year;
            if (dataNascimento > dataAtual.AddYears(-idade)) idade--;

            return idade;
        }
    }
}
