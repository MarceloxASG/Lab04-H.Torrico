using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ListarProductos_Click(object sender, RoutedEventArgs e)
        {
            // Llamar al método para cargar los datos
            LoadDataProductos();
        }

        private void ListarCategorias_Click(object sender, RoutedEventArgs e)
        {
            // Llamar al método para cargar los datos
            LoadDataCategorias();
        }

        private void ListarProveedores_Click(object sender, RoutedEventArgs e)
        {
            // Llamar al método para cargar los datos
            LoadDataProveedores();
        }

        private void LoadDataProductos()
        {
            try
            {
                // Cadena de conexión a la base de datos
                string cadena = "Server=LAB1507-01\\SQLEXPRESS02; Database=Neptuno; Integrated Security=True";

                // Crear y abrir la conexión a la base de datos
                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("USP_ListarProductos", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Crear una lista para almacenar los productos
                List<Producto> listaProductos = new List<Producto>();

                // Ejecutar el procedimiento almacenado y leer los datos
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.IdProducto = reader["idproducto"].ToString();
                    producto.NombreProducto = reader["nombreProducto"].ToString();
                    producto.IdProveedor = reader["idProveedor"].ToString();
                    producto.IdCategoria = reader["idCategoria"].ToString();
                    producto.CantidadPorUnidad = reader["cantidadPorUnidad"].ToString();
                    producto.PrecioUnidad = reader["precioUnidad"].ToString();
                    producto.UnidadesEnExistencia = reader["unidadesEnExistencia"].ToString();
                    producto.UnidadesEnPedido = reader["unidadesEnPedido"].ToString();
                    producto.NivelNuevoPedido = reader["nivelNuevoPedido"].ToString();
                    producto.Suspendido = reader["suspendido"].ToString();
                    producto.CategoriaProducto = reader["categoriaProducto"].ToString();

                    listaProductos.Add(producto);
                }
                connection.Close();


                // Asignar la lista de productos a un DataGridView u otro control
                dgv.ItemsSource = listaProductos;
            }


            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadDataCategorias()
        {
            try
            {
                // Cadena de conexión a la base de datos
                string cadena = "Server=LAB1507-01\\SQLEXPRESS02; Database=Neptuno; Integrated Security=True";

                // Crear y abrir la conexión a la base de datos
                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("USP_ListarCategorias", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Crear una lista para almacenar los productos
                List<Categoria> listaCategoria = new List<Categoria>();

                // Ejecutar el procedimiento almacenado y leer los datos
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = reader["idcategoria"].ToString();
                    categoria.NombreCategoria = reader["nombreCategoria"].ToString();
                    categoria.Descripcion = reader["descripcion"].ToString();
                    categoria.Activo = reader["activo"].ToString();
                    categoria.CodCategoria = reader["codCategoria"].ToString();
                    listaCategoria.Add(categoria);
                }
                connection.Close();


                // Asignar la lista de productos a un DataGridView u otro control
                dgv.ItemsSource = listaCategoria;
            }


            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void LoadDataProveedores()
        {
            try
            {
                // Cadena de conexión a la base de datos
                string cadena = "Server=LAB1507-01\\SQLEXPRESS02; Database=Neptuno; Integrated Security=True";

                // Crear y abrir la conexión a la base de datos
                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("USP_ListarProveedores", connection);
                command.CommandType = CommandType.StoredProcedure;

               

                // Crear una lista para almacenar los productos
                List<Proveedor> listaProveedores = new List<Proveedor>();

                // Ejecutar el procedimiento almacenado y leer los datos
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.IdProveedor = reader["idproveedor"].ToString();
                    proveedor.NombreCompañia = reader["nombreCompañia"].ToString();
                    proveedor.NombreContacto = reader["nombrecontacto"].ToString();
                    proveedor.CargoContacto = reader["cargocontacto"].ToString();
                    proveedor.Direccion = reader["direccion"].ToString();
                    proveedor.Ciudad = reader["ciudad"].ToString();
                    proveedor.Region = reader["region"].ToString();
                    proveedor.CodPostal = reader["codPostal"].ToString();
                    proveedor.Pais = reader["pais"].ToString();
                    proveedor.Telefono = reader["telefono"].ToString();
                    proveedor.Fax = reader["fax"].ToString();
                    proveedor.PaginaPrincipal = reader["paginaprincipal"].ToString();

                    listaProveedores.Add(proveedor);
                }
                connection.Close();


                // Asignar la lista de productos a un DataGridView u otro control
                dgv.ItemsSource = listaProveedores;
            }


            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
