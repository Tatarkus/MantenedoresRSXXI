using System.Windows.Controls;

using MantenedoresSigloXXI.ViewModels;

namespace MantenedoresSigloXXI.Views
{
    public partial class ProductsPage : Page
    {
        public ProductsPage(ProductsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
