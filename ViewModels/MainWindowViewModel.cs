using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Csh_Kutsenko_01.Tools;

namespace Csh_Kutsenko_01.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isEnabled = true;

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set { _loaderVisibility = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            LoaderManager.Instance.Innitialize(this);
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; OnPropertyChanged(); }
        }
    }
}