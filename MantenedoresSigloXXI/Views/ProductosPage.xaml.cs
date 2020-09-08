using System.Windows.Controls;

using MantenedoresSigloXXI.ViewModels;

namespace MantenedoresSigloXXI.Views
{
    public partial class ProductosPage : Page
    {
        public ProductosPage(ProductosViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
