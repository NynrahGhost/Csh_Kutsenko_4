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
using Test.Misc;

namespace Csh_Kutsenko_01.ViewModels
{
    class AllPersonsViewModel : INotifyPropertyChanged
    {
        private List<Person> list = (new PersonList()).Generate();
        public ObservableCollection<Person> List = Person.Generate(); //= new ObservableCollection<Person>((new PersonList()).Generate());
        //{
        //    get
        //    {
        //        OnPropertyChanged();
        //        return list;
        //    }
        //}

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand<object>(o => Add()));

        private ICommand _editCommand;
        public ICommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand<object>(o => Edit()));

        private void Add()
        {
            MessageBox.Show(List[0].Surname);
            NavigateManager.Instance.Navigate(ViewType.Edit);
        }

        private void Edit()
        {
            NavigateManager.Instance.Navigate(ViewType.Edit);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
