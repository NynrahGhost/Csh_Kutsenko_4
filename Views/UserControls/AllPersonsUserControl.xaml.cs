using Csh_Kutsenko_01.Tools.Managers;
using Csh_Kutsenko_01.ViewModels;
using System.Windows.Controls;

namespace Csh_Kutsenko_01.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AllPersonsUserControl.xaml
    /// </summary>
    public partial class AllPersonsUserControl : UserControl, INavigatable
    {
        public AllPersonsUserControl()
        {
            InitializeComponent();
            DataContext = new AllPersonsViewModel();
        }

        private void CheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
