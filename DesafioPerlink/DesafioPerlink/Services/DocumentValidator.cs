using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioPerlink.Services
{
    class DocumentValidator
    {
        private static int DigitoVerificadorEmModulo11(string valor, int maiorMultiplicador = 0, int menorMultiplicador = 0)
        {
            if (string.IsNullOrEmpty(valor)) throw new Exception("Informe um valor para cálculo do módulo 11.");
            string caracteresValidos = "0123456789";
            for (int i = 0; i < valor.Length; i++)
                if (!caracteresValidos.Contains(valor.Substring(i, 1))) throw new Exception("Só pode haver caracteres numéricos para cálculo do módulo 11.");

            int soma = 0;
            int multiplicador = menorMultiplicador == 0 ? 2 : menorMultiplicador;

            for (int intPos = valor.Length - 1; intPos >= 0; intPos--)
            {
                soma += Convert.ToInt32(valor[intPos].ToString()) * multiplicador;
                if (multiplicador == (maiorMultiplicador == 0 ? valor.Length + 1 : maiorMultiplicador))
                    multiplicador = (menorMultiplicador == 0 ? 2 : menorMultiplicador);
                else
                    multiplicador++;
            }

            int resto = (soma % 11);
            return (resto == 0 || resto == 1 ? 0 : (11 - resto));

        }
        public static bool IsCNPJ(string cnpj)
        {
            if (cnpj.Length != 14) return false;

            int digito;
            digito = DigitoVerificadorEmModulo11(cnpj.Substring(0, 12), 9);
            if (digito.ToString() != cnpj.Substring(12, 1)) return false;
            digito = DigitoVerificadorEmModulo11(cnpj.Substring(0, 13), 9);
            if (digito.ToString() != cnpj.Substring(13, 1)) return false;

            return true;
        }
    }
}
