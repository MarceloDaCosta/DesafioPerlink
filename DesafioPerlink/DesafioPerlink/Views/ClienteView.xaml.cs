using DesafioPerlink.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesafioPerlink.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClienteView : ContentPage
	{
		public ClienteView ()
		{
			InitializeComponent();
            BindingContext = new ClienteViewModel(this);
		}
	}
}