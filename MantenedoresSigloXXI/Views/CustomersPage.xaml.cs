using System.Collections.ObjectModel;
using System.Windows.Controls;
using MantenedoresSigloXXI.Controllers;
using MantenedoresSigloXXI.Models;
using MantenedoresSigloXXI.ViewModels;

namespace MantenedoresSigloXXI.Views
{
    public partial class CustomersPage : Page
    {
        public CustomersPage(CustomersViewMode viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

           // CustomersDG.ItemsSource = viewModel.Customers;
            

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
