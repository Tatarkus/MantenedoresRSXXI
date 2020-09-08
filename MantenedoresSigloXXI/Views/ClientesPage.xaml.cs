using System.Windows.Controls;
using MantenedoresSigloXXI.Controllers;
using MantenedoresSigloXXI.ViewModels;

namespace MantenedoresSigloXXI.Views
{
    public partial class ClientesPage : Page
    {
        public ClientesPage(ClientesViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            JsonResult jsonresult = new JsonResult();
            
            //Gets the list of clients from an example json
            ClientsDG.ItemsSource = jsonresult.DeserializeClients();


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
