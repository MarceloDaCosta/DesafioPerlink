using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioPerlink.Models
{
    public enum Status
    {
        Ativo,
        Inativo
    }

    class Processo : ModelBase
    {
        public Processo(Cliente cliente, Status status, string numero, Estado estado, decimal valor)
        {
            Cliente = cliente;
            Status = status;
            Numero = numero;
            Estado = estado;
            Valor = valor;
            DataCriacao = DateTime.Now.Date;
        }

        private Cliente cliente;
        public Cliente Cliente
        {
            get { return cliente; }
            private set
            {
                cliente = value ?? throw new Exception("Informe o cliente.");
            }
        }

        public Status Status { get; private set; }

        private string numero;
        public string Numero
        {
            get { return numero; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Informe o número do processo.");
                numero = value.Trim().ToUpper();
            }
        }

        private Estado estado;
        public Estado Estado
        {
            get { return estado; }
            private set
            {
                estado = value ?? throw new Exception("Informe o estado do processo.");
            }
        }

        private DateTime dataCriacao;
        public DateTime DataCriacao
        {
            get { return dataCriacao; }
            set
            {
                if (value == default(DateTime)) throw new Exception("Informe a data de criação.");
                dataCriacao = value;
            }
        }

        private decimal valor;
        public decimal Valor
        {
            get { return valor; }
            private set
            {
                if (value == default(decimal)) throw new Exception("Informe o valor do processo.");
                valor = value;
            }
        }
    }
}
