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
    class ClienteViewModel : ViewModelBase
    {
        ClienteView pagina;

        public ClienteViewModel(ClienteView pagina)
        {
            this.pagina = pagina;
            ConfirmarCommand = new Command(Confirmar);
            ListarClientes();
            ListarEstados();
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        private string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set
            {
                cnpj = value;
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

        public CustomObservableCollection<Cliente> Clientes { get; set; } = new CustomObservableCollection<Cliente>();

        public Command ConfirmarCommand { get; set; }

        async void Confirmar()
        {
            try
            {
                ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
                chamadaWebApi.Post<Cliente>(new Cliente(Nome, Cnpj, EstadoSelecionado));

                await pagina.DisplayAlert("Cadastro", "Cliente cadastrado com sucesso.", "Ok");

                Nome = string.Empty;
                Cnpj = string.Empty;
                EstadoSelecionado = null;

                ListarClientes();
            }
            catch (Exception ex)
            {
                await pagina.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        void ListarClientes()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            Clientes.ApagarEnfileirar(chamadaWebApi.Get<Cliente>());
        }

        private void ListarEstados()
        {
            ChamadaWebApi chamadaWebApi = new ChamadaWebApi();
            Estados.ApagarEnfileirar(chamadaWebApi.Get<Estado>());
        }
    }
}
