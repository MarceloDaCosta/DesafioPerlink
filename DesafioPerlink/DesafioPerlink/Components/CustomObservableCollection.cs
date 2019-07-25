using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPerlink.Components
{
    public class CustomObservableCollection<T> : ObservableCollection<T> where T : class
    {
        public CustomObservableCollection() { }
        public CustomObservableCollection(IList<T> list) : base(list)
        {
        }

        public void Adicionar(T Modelo)
        {
            if (Modelo == null) return;
            Add(Modelo);
        }
        public void Adicionar(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public void Remover(T modelo)
        {
            if (modelo == null) return;
            Remove(modelo);
        }

        /// <summary>
        /// Apaga toda a coleção e insere uma nova coleção
        /// </summary>
        /// <param name="collection">coleção que será enfileirada</param>
        public void ApagarEnfileirar(IEnumerable<T> collection)
        {
            this.Clear();
            if (collection != null)
                Adicionar(collection);
        }

        /// <summary>
        /// filtra a coleção baseado em uma outra coleção
        /// </summary>
        /// <param name="collection">coleção de objetos filtrados</param>
        public void Filtrar(IEnumerable<T> collection)
        {
            List<T> listaFiltrada = new List<T>();
            foreach (var item in collection)
                listaFiltrada.Add(item);
            ApagarEnfileirar(listaFiltrada);
        }
    }
}

