using Business;
using System.Windows;


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
    }
}