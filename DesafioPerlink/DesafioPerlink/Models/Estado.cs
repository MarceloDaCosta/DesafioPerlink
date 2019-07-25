using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioPerlink.Models
{
    class Estado : ModelBase
    {
        public Estado(string uf, string nome)
        {
            UF = uf;
            Nome = nome;
        }

        public string UF { get; private set; }
        public string Nome { get; private set; }
    }
}
