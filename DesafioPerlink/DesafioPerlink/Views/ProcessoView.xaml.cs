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
	public partial class ProcessoView : ContentPage
	{
		public ProcessoView ()
		{
			InitializeComponent ();
            BindingContext = new ProcessoViewModel(this);
		}
	}
}