using Csh_Kutsenko_01.Models;
using Csh_Kutsenko_01.Tools.Managers;
using Csh_Kutsenko_01.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Csh_Kutsenko_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            NavigateManager.Instance.Innitialize(new BaseNavigationModel(this));
            NavigateManager.Instance.Navigate(ViewType.List);
            Person.Generate();
        }

        public ContentControl ContentControl
        {
            get
            {
                return _contentControl;
            }
        }
    }
}
