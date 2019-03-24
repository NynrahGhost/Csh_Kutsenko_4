using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Csh_Kutsenko_01.Annotations;
using Csh_Kutsenko_01.Models;
using Csh_Kutsenko_01.Tools;
using Csh_Kutsenko_01.Tools.Managers;
using Csh_Kutsenko_01.Views.UserControls;
using Test.Misc;

namespace Csh_Kutsenko_01.ViewModels
{
    class AllPersonsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> list = (Person.Generate());
        public ObservableCollection<Person> List //= new ObservableCollection<Person>((new PersonList()).Generate());
        {
            get
            {
                return Person.List;
            }
        }

        private Person _selection;
        public Person Selection
        {
            get { return _selection; }
            set { _selection = value; Person.Selected = value; OnPropertyChanged(); }
        }

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand<object>(o => Add()));

        private ICommand _editCommand;
        public ICommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand<object>(o => Edit(), o => Selection != null));

        private ICommand _removeCommand;
        public ICommand RemoveCommand => _removeCommand ?? (_removeCommand = new RelayCommand<object>(o => Remove(), o => Selection != null));

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<object>(o => Save()));

        private void Add()
        {
            Person.Selected = null;
            NavigateManager.Instance.Navigate(ViewType.Edit);
        }

        private void Edit()
        {
            ((BirthDateViewModel) ( (BirthDateUserControl) NavigateManager.Instance.Navigate(ViewType.Edit) ).DataContext ).FillFields();
        }
        
        private void Remove()
        {
            Person.List.RemoveAt( Person.List.IndexOf(Person.Selected) );
        }

        private async void Save()
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(500));
            LoaderManager.Instance.HideLoader();
            Person.Save();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
