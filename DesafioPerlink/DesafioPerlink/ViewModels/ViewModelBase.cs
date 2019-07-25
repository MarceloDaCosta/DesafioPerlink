using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPerlink.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifica que houve alteração no campo informado
        /// </summary>
        /// <param name=”campo”>Campo aonde houve alteração</param>
        protected void OnPropertyChanged([CallerMemberName]string campo = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(campo));
            }
        }
    }
}
