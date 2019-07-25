using DesafioPerlink.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioPerlink.Models
{
    class Cliente : ModelBase
    {
        public Cliente(string nome, string cnpj, Estado estado)
        {
            Nome = nome;
            Cnpj = cnpj;
            Estado = estado;
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Informe o nome do cliente.");
                nome = value.Trim().ToUpper();
            }
        }

        private string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Informe o cnpj.");
                //if (!DocumentValidator.IsCNPJ(value)) throw new Exception("CNPJ inválido");
                cnpj = value.Trim();
            }
        }

        private Estado estado;
        public Estado Estado
        {
            get { return estado; }
            private set
            {
                estado = value ?? throw new Exception("Informe o estado.");
            }
        }
    }
}
