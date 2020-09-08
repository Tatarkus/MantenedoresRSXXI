using System.Windows.Controls;

using MantenedoresSigloXXI.ViewModels;

namespace MantenedoresSigloXXI.Views
{
    public partial class OtrosPage : Page
    {
        public OtrosPage(OtrosViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
