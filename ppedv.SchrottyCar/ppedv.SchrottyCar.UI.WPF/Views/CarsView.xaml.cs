using Microsoft.Extensions.DependencyInjection;
using ppedv.SchrottyCar.UI.WPF.ViewModels;
using System.Windows.Controls;

namespace ppedv.SchrottyCar.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for CarsView.xaml
    /// </summary>
    public partial class CarsView : UserControl
    {
        public CarsView()
        {
            InitializeComponent();

            DataContext = App.Current.Services.GetService<CarsViewModel>();
        }
    }
}
