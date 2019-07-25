using DesafioPerlink.Components;
using DesafioPerlink.Models;
using DesafioPerlink.Services;
using DesafioPerlink.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DesafioPerlink.ViewModels
{
    class ResultadoViewModel : ViewModelBase
    {
        ResultadoView pagina;

        public ResultadoViewModel(ResultadoView pagina)
        {
            this.pagina = pagina;
            ConfirmarCommand = new Command(Confirmar);
            CarregarResultados();
        }

        public CustomObservableCollection<Resultado> Resultados { get; set; } = new CustomObservableCollection<Resultado>();

        private Resultado resultadoSelecionado;
        public Resultado ResultadoSelecionado
        {
            get { return resultadoSelecionado; }
            set
            {
                resultadoSelecionado = value;
                LimparResultado();
                OnPropertyChanged();
            }
        }

        private bool visualizarSoma;
        public bool VisualizarSoma
        {
            get { return visualizarSoma; }
            set
            {
                visualizarSoma = value;
                OnPropertyChanged();
            }
        }

        private decimal valorSoma;
        public decimal ValorSoma
        {
            get { return valorSoma; }
            set
            {
                valorSoma = value;
                OnPropertyChanged();
            }
        }

        private bool visualizarMedia;
        public bool VisualizarMedia
        {
            get { return visualizarMedia; }
            set
            {
                visualizarMedia = value;
                OnPropertyChanged();
            }
        }

        private decimal valorMedia;
        public decimal ValorMedia
        {
            get { return valorMedia; }
            set
            {
                valorMedia = value;
                OnPropertyChanged();
            }
        }

        private bool visualizarNumeroProcessos;
        public bool VisualizarNumeroProcessos
        {
            get { return visualizarNumeroProcessos; }
            set
            {
                visualizarNumeroProcessos = value;
                OnPropertyChanged();
            }
        }

        private int numeroProcessos;
        public int NumeroProcessos
        {
            get { return numeroProcessos; }
            set
            {
                numeroProcessos = value;
                OnPropertyChanged();
            }
        }

        private bool visualizarProcessosSetembro2007;
        public bool VisualizarProcessosSetembro2007
        {
            get { return visualizarProcessosSetembro2007; }
            set
            {
                visualizarProcessosSetembro2007 = value;
                OnPropertyChanged();
            }
        }

        public CustomObservableCollection<Processo> ProcessosSetembro2007 { get; set; } = new CustomObservableCollection<Processo>();

        private bool visualizarProcessosMesmoEstadoDoCliente;
        public bool VisualizarProcessosMesmoEstadoDoCliente
        {
            get { return visualizarProcessosMesmoEstadoDoCliente; }
            set
            {
                visualizarProcessosMesmoEstadoDoCliente = value;
                OnPropertyChanged();
            }
        }

        public CustomObservableCollection<Processo> ProcessosMesmoEstadoDoCliente { get; set; } = new CustomObservableCollection<Processo>();

        private bool visualizarProcessosTrab;
        public bool VisualizarProcessosTrab
        {
            get { return visualizarProcessosTrab; }
            set
            {
                visualizarProcessosTrab = value;
                OnPropertyChanged();
            }
        }

        public CustomObservableCollection<Processo> ProcessosTrab { get; set; } = new CustomObservableCollection<Processo>();

        public Command ConfirmarCommand { get; set; }

        void CarregarResultados()
        {
            List<Resultado> resultados = new List<Resultado>();
            resultados.Add(new Resultado("Soma dos processos ativos"));
            resultados.Add(new Resultado("Média dos valores do RJ"));
            resultados.Add(new Resultado("Números de processos acima de R$100.000,00"));
            resultados.Add(new Resultado("Processos de setembro de 2007"));
            resultados.Add(new Resultado("Processos de mesmo estado do cliente"));
            resultados.Add(new Resultado("Processos TRAB"));
            Resultados.ApagarEnfileirar(resultados);
        }

        void LimparResultado()
        {
            VisualizarSoma = false;
            VisualizarMedia = false;
            VisualizarNumeroProcessos = false;
            VisualizarProcessosSetembro2007 = false;
            VisualizarProcessosMesmoEstadoDoCliente = false;
            VisualizarProcessosTrab = false;
        }

        async void Confirmar()
        {
            try
            {
                LimparResultado();

                int resultado = Resultados.IndexOf(resultadoSelecionado);
                switch (resultado)
                {
                    case 0:
                        VisualizarSoma = true;
                        CalcularSomaDosProcessosAtivos();
                        break;
                    case 1:
                        VisualizarMedia = true;
                        CalcularMediaDosProcessosDoRJ();
                        break;
                    case 2:
                        VisualizarNumeroProcessos = true;
                        CalcularNumeroProcessosAcimaDeCemMilReais();
                        break;
                    case 3:
                        VisualizarProcessosSetembro2007 = true;
                        CalcularProcessosSetembro2007();
                        break;
                    case 4:
                        VisualizarProcessosMesmoEstadoDoCliente = true;
                        CalcularProcessosMesmoEstadoDoCliente();
                        break;
                    case 5:
                        VisualizarProcessosTrab = true;
                        CalcularProcessosTrab();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await pagina.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        void CalcularSomaDosProcessosAtivos()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            List<Processo> processos = chamadaWebApi.Get<Processo>();
            if (processos == null)
                ValorSoma = 0;
            else
                ValorSoma = processos.Where(x => x.Status == Status.Ativo).ToList().Sum(x => x.Valor);
        }

        void CalcularMediaDosProcessosDoRJ()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            List<Processo> processos = chamadaWebApi.Get<Processo>();
            if (processos == null)
                ValorMedia = 0;
            else
                ValorMedia = processos.Where(x => x.Estado.UF == "RJ").ToList().Average(x => x.Valor);
        }

        void CalcularNumeroProcessosAcimaDeCemMilReais()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            List<Processo> processos = chamadaWebApi.Get<Processo>();
            if (processos == null)
                NumeroProcessos = 0;
            else
                NumeroProcessos = processos.Where(x => x.Valor > 100000).ToList().Count();
        }

        void CalcularProcessosSetembro2007()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            List<Processo> processos = chamadaWebApi.Get<Processo>();
            ProcessosSetembro2007.ApagarEnfileirar(processos.Where(x => x.DataCriacao.Month == 9 && x.DataCriacao.Year == 2007));
        }

        void CalcularProcessosMesmoEstadoDoCliente()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            List<Processo> processos = chamadaWebApi.Get<Processo>();
            ProcessosMesmoEstadoDoCliente.ApagarEnfileirar(processos.Where(x => x.Estado.UF == x.Cliente.Estado.UF));
        }

        void CalcularProcessosTrab()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            List<Processo> processos = chamadaWebApi.Get<Processo>();
            ProcessosTrab.ApagarEnfileirar(processos.Where(x => x.Numero.Contains("TRAB")));
        }
    }

    class Resultado
    {
        public Resultado(string descricao)
        {
            Descricao = descricao;
        }
        public string Descricao { get; private set; }
    }
}
