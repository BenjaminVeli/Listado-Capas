using Business;
using Data;
using System.Windows;
using System.Xml.Linq;


namespace Proyecto
{
    
    public partial class MainWindow : Window
    {
        BusinessProduct businessProduct = new BusinessProduct();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgvProducts.ItemsSource = businessProduct.ListProducts();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Conexión");
                throw;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Crear un nuevo producto a insertar
                Product newProduct = new Product
                {
                    name = txtNombre.Text, 
                    price = Convert.ToDecimal(txtPrecio.Text), 
                    stock = Convert.ToInt32(txtStock.Text), 
                    active = chkActive.IsChecked == true 
                };

                // Insertar el producto en la base de datos
                businessProduct.InsertProduct(newProduct);

                // Refrescar la lista de productos después de la inserción
                dgvProducts.ItemsSource = businessProduct.ListProducts();

                MessageBox.Show("Producto insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el producto: {ex.Message}");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Product updatedProduct = new Product
                {
                    product_id = Convert.ToInt32(txtId.Text),
                    name = txtNombre.Text, 
                    price = Convert.ToDecimal(txtPrecio.Text), 
                    stock = Convert.ToInt32(txtStock.Text), 
                    active = chkActive.IsChecked == true 
                };

                // Actualizar el producto en la base de datos
                businessProduct.UpdateProduct(updatedProduct);

                // Refrescar la lista de productos después de la actualización
                dgvProducts.ItemsSource = businessProduct.ListProducts();

                MessageBox.Show("Producto actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}");
            }
        }
    }
}