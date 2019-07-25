using DesafioPerlink.Components;
using DesafioPerlink.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPerlink
{
    public class MainPageMasterViewModel : ViewModelBase
    {
        public CustomObservableCollection<MainPageMenuItem> MenuItems { get; set; } = new CustomObservableCollection<MainPageMenuItem>();

        public MainPageMasterViewModel(List<MainPageMenuItem> menu)
        {
            MenuItems.ApagarEnfileirar(menu);
        }
    }
}
