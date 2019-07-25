using DesafioPerlink.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesafioPerlink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView;

        public MainPageMaster()
        {
            InitializeComponent();

            MainPageMasterViewModel vm = new MainPageMasterViewModel(RetornaListaMenu());
            BindingContext = vm;
            ListView = MenuItemsListView;
        }

        public List<MainPageMenuItem> RetornaListaMenu()
        {
            return new List<MainPageMenuItem>()
            {
                new MainPageMenuItem { Menu = "Início", Title = "Perlink", Icon = "Home.png", TargetType = typeof(MainPageDetail) },
                new MainPageMenuItem { Menu = "Cliente", Title = "Cliente", Icon = "Client.png", TargetType = typeof(ClienteView) },
                new MainPageMenuItem { Menu = "Processo", Title = "Processo", Icon = "Register.png", TargetType = typeof(ProcessoView) },
                new MainPageMenuItem { Menu = "Resultado", Title = "Resultado", Icon = "Result.png", TargetType = typeof(ResultadoView) },
            };
        }
    }
}