using DesafioPerlink.Components;
using DesafioPerlink.Models;
using DesafioPerlink.Services;
using DesafioPerlink.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DesafioPerlink.ViewModels
{
    class ProcessoViewModel : ViewModelBase
    {
        ProcessoView pagina;

        public ProcessoViewModel(ProcessoView pagina)
        {
            this.pagina = pagina;
            CarregarClientes();
            CarregarEstados();
            ListarProcessos();
            ConfirmarCommand = new Command(Confirmar);
        }

        public CustomObservableCollection<Processo> Processos { get; set; } = new CustomObservableCollection<Processo>();

        public CustomObservableCollection<Cliente> Clientes { get; set; } = new CustomObservableCollection<Cliente>();

        private Cliente clienteSelecionado;
        public Cliente ClienteSelecionado
        {
            get { return clienteSelecionado; }
            set
            {
                clienteSelecionado = value;
                OnPropertyChanged();
            }
        }

        private string numero;
        public string Numero
        {
            get { return numero; }
            set
            {
                numero = value;
                OnPropertyChanged();
            }
        }

        public CustomObservableCollection<Estado> Estados { get; set; } = new CustomObservableCollection<Estado>();

        private Estado estadoSelecionado;
        public Estado EstadoSelecionado
        {
            get { return estadoSelecionado; }
            set
            {
                estadoSelecionado = value;
                OnPropertyChanged();
            }
        }

        private string valor;
        public string Valor
        {
            get { return valor; }
            set
            {
                valor = value;
                OnPropertyChanged();
            }
        }

        public Command ConfirmarCommand { get; set; }

        async void Confirmar()
        {
            try
            {
                ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
                chamadaWebApi.Post<Processo>(new Processo(clienteSelecionado, Status.Ativo, numero, estadoSelecionado, Conversor.StringParaDecimal(valor)));

                await pagina.DisplayAlert("Processo", "Processo cadastrado com sucesso.", "Ok");

                ClienteSelecionado = null;
                Numero = string.Empty;
                EstadoSelecionado = null;
                Valor = string.Empty;

                ListarProcessos();
            }
            catch (Exception ex)
            {
                await pagina.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        void CarregarClientes()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            Clientes.ApagarEnfileirar(chamadaWebApi.Get<Cliente>());
        }

        void CarregarEstados()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            Estados.ApagarEnfileirar(chamadaWebApi.Get<Estado>());
        }

        void ListarProcessos()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            Processos.ApagarEnfileirar(chamadaWebApi.Get<Processo>());
        }
    }
}
