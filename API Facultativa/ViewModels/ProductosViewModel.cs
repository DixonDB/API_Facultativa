using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace API_Facultativa.ViewModels
{
    public class ProductosViewModel : INotifyPropertyChanged
    {
        private string _filtro;
        public string Filtro
        {
            get { return _filtro; }
            set
            {
                if (_filtro != value)
                {
                    _filtro = value;
                    OnPropertyChanged();
                    ActualizarListaProductos();
                }
            }
        }

        private ObservableCollection<Producto> _productos;
        public ObservableCollection<Producto> Productos
        {
            get { return _productos; }
            set
            {
                if (_productos != value)
                {
                    _productos = value;
                    OnPropertyChanged();
                }
            }
        }

        public ProductosViewModel()
        {
            // Inicializar la lista de productos
            Productos = new ObservableCollection<Producto>
            {
                new Producto { Nombre = "Producto 1", Precio = 10.99, ImagenUrl = "icono.png" },
                new Producto { Nombre = "Producto 2", Precio = 15.99, ImagenUrl = "imagen2.png" },
                new Producto { Nombre = "Producto 3", Precio = 20.49, ImagenUrl = "imagen3.png" },
                new Producto { Nombre = "Producto 4", Precio = 8.79, ImagenUrl = "imagen4.png" }
            };

            // Inicializar filtro
            Filtro = "";
        }

        private void ActualizarListaProductos()
        {
            if (string.IsNullOrWhiteSpace(Filtro))
            {
                // Si el filtro está vacío, mostrar todos los productos
                return;
            }

            // Filtrar productos por el texto de búsqueda
            var productosFiltrados = Productos.Where(p => p.Nombre.ToLower().Contains(Filtro.ToLower())).ToList();
            Productos.Clear();
            foreach (var producto in productosFiltrados)
            {
                Productos.Add(producto);
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string ImagenUrl { get; set; }
    }
}
