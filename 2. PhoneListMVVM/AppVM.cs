
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PhoneListMVVM
{
    // view model class
    public class AppVM : INotifyPropertyChanged
    {
        private Phone? selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        public Phone? SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Phone phone = new Phone { Title = "iPhone 14", Company = "Apple", Price = 41499 };
                      Phones.Insert(0, phone);
                      SelectedPhone = phone;
                  }));
            }
        }

        RelayCommand? removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Phone? phone = obj as Phone;
                      if (phone != null)
                      {
                          Phones.Remove(phone);
                      }
                  },
                 (obj) => Phones.Count > 0));
            }
        }

        public AppVM()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone { Title="iPhone 14", Company = "Apple", Price = 41499 },
                new Phone { Title="Samsung Galaxy S22", Company = "Samsung", Price = 50299 },
                new Phone { Title="Xiaomi 12", Company = "Xiaomi", Price = 25999 },
                new Phone { Title="Samsung Galaxy Fold 4", Company = "Samsung", Price = 79999 }
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
