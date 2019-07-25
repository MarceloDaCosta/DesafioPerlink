using DesafioPerlink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPerlink.Services
{
    class ChamadaWebApi
    {
        static List<Estado> estados = new List<Estado>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Processo> processos = new List<Processo>();

        static ChamadaWebApi()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();

            #region Estados
            estados.Add(new Estado("AC", "ACRE"));
            estados.Add(new Estado("AL", "ALAGOAS"));
            estados.Add(new Estado("AP", "AMAPÁ"));
            estados.Add(new Estado("AM", "AMAZONAS"));
            estados.Add(new Estado("BA", "BAHIA"));
            estados.Add(new Estado("CE", "CEARÁ"));
            estados.Add(new Estado("ES", "ESPÍRITO SANTO"));
            estados.Add(new Estado("GO", "GOIÁS"));
            estados.Add(new Estado("MA", "MARANHÃO"));
            estados.Add(new Estado("MT", "MATO GROSSO"));
            estados.Add(new Estado("MS", "MATO GROSSO DO SUL"));
            estados.Add(new Estado("MG", "MINAS GERAIS"));
            estados.Add(new Estado("PA", "PARÁ"));
            estados.Add(new Estado("PB", "PARAÍBA"));
            estados.Add(new Estado("PR", "PARANÁ"));
            estados.Add(new Estado("PE", "PERNAMBUCO"));
            estados.Add(new Estado("PI", "PIAUÍ"));
            estados.Add(new Estado("RJ", "RIO DE JANEIRO"));
            estados.Add(new Estado("RN", "RIO GRANDE DO NORTE"));
            estados.Add(new Estado("RS", "RIO GRANDE DO SUL"));
            estados.Add(new Estado("RO", "RONDÔNIA"));
            estados.Add(new Estado("RR", "RORAIMA"));
            estados.Add(new Estado("SC", "SANTA CATARINA"));
            estados.Add(new Estado("SP", "SÃO PAULO"));
            estados.Add(new Estado("SE", "SERGIPE"));
            estados.Add(new Estado("TO", "TOCANTINS"));
            estados.Add(new Estado("DF", "DISTRITO FEDERAL"));
            #endregion

            #region Clientes
            clientes.Add(new Cliente("EMPRESA A", "00000000000001", chamadaWebApi.Get<Estado>("RJ")) { Id = 1 });
            clientes.Add(new Cliente("EMPRESA B", "00000000000002", chamadaWebApi.Get<Estado>("SP")) { Id = 2 });
            #endregion

            #region Processos
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("1"), Status.Ativo, "00001CIVELRJ", chamadaWebApi.Get<Estado>("RJ"), 200000) { DataCriacao = new DateTime(2007, 10, 10) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("1"), Status.Ativo, "00002CIVELSP", chamadaWebApi.Get<Estado>("SP"), 100000) { DataCriacao = new DateTime(2007, 10, 20) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("1"), Status.Inativo, "00003TRABMG", chamadaWebApi.Get<Estado>("MG"), 10000) { DataCriacao = new DateTime(2007, 10, 30) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("1"), Status.Inativo, "00004CIVELRJ", chamadaWebApi.Get<Estado>("RJ"), 20000) { DataCriacao = new DateTime(2007, 11, 10) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("1"), Status.Ativo, "00005CIVELSP", chamadaWebApi.Get<Estado>("SP"), 35000) { DataCriacao = new DateTime(2007, 11, 15) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("2"), Status.Ativo, "00006CIVELRJ", chamadaWebApi.Get<Estado>("RJ"), 20000) { DataCriacao = new DateTime(2007, 5, 1) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("2"), Status.Ativo, "00007CIVELRJ", chamadaWebApi.Get<Estado>("RJ"), 700000) { DataCriacao = new DateTime(2007, 6, 2) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("2"), Status.Inativo, "00008CIVELSP", chamadaWebApi.Get<Estado>("SP"), 500) { DataCriacao = new DateTime(2007, 7, 3) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("2"), Status.Ativo, "00009CIVELSP", chamadaWebApi.Get<Estado>("SP"), 32000) { DataCriacao = new DateTime(2007, 8, 4) });
            processos.Add(new Processo(chamadaWebApi.Get<Cliente>("2"), Status.Inativo, "00010TRABAM", chamadaWebApi.Get<Estado>("AM"), 1000) { DataCriacao = new DateTime(2007, 9, 5) });
            #endregion
        }

        /// <summary>
        /// Retorna uma lista do tipo informado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Get<T>() where T : class
        {
            //Este método deve ser substituído para fazer chamada a um web service.
            if (typeof(T) == typeof(Estado))
            {
                return (List<T>)Convert.ChangeType(estados, typeof(List<T>));
            }
            else if (typeof(T) == typeof(Cliente))
            {
                return (List<T>)Convert.ChangeType(clientes, typeof(List<T>));
            }
            else if (typeof(T) == typeof(Processo))
            {
                return (List<T>)Convert.ChangeType(processos, typeof(List<T>));
            }

            return null;
        }

        /// <summary>
        /// Retorna uma instância do tipo informado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="chave"></param>
        /// <returns></returns>
        public T Get<T>(string chave) where T : class
        {
            //Este método deve ser substituído para fazer chamada a um web service.
            if (typeof(T) == typeof(Estado))
            {
                return (T)Convert.ChangeType(estados.Where(x => x.UF == chave).FirstOrDefault(), typeof(T));
            }
            else if(typeof(T) == typeof(Cliente))
            {
                return (T)Convert.ChangeType(clientes.Where(x => x.Id.ToString() == chave).FirstOrDefault(), typeof(T));
            }

            return null;
        }

        public void Post<T>(object objeto) where T : class
        {
            //Este método deve ser substituído para fazer chamada a um web service.
            if (typeof(T) == typeof(Cliente))
            {
                Cliente cliente = (Cliente)objeto;
                cliente.Id = clientes.Max(x => x.Id) + 1;
                clientes.Add(cliente);
            }
            else if (typeof(T) == typeof(Processo))
            {
                Processo processo = (Processo)objeto;
                processo.Id = processos.Max(x => x.Id) + 1;
                processos.Add(processo);
            }
        }
    }
}
