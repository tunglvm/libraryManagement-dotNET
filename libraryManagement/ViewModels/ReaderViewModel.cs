using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using libraryManagement.Models;

namespace libraryManagement.ViewModels
{
    public class ReaderViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Reader> Readers { get; set; }

        private Reader _selectedReader;
        public Reader SelectedReader
        {
            get => _selectedReader;
            set { _selectedReader = value; OnPropertyChanged(); }
        }

        private string _readerId;
        public string ReaderId { get => _readerId; set { _readerId = value; OnPropertyChanged(); } }

        private string _fullName;
        public string FullName { get => _fullName; set { _fullName = value; OnPropertyChanged(); } }

        private string _phoneNumber;
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(); } }

        public ICommand AddReaderCommand { get; }
        public ICommand DeleteReaderCommand { get; }

        public ReaderViewModel()
        {
            Readers = new ObservableCollection<Reader>
            {
                new Reader { ReaderId = "DG01", FullName = "Trần Văn Hùng", PhoneNumber = "0901234567" },
                new Reader { ReaderId = "DG02", FullName = "Lê Thị Mai", PhoneNumber = "0918888888" }
            };

            AddReaderCommand = new RelayCommand(obj => {
                if (string.IsNullOrEmpty(ReaderId) || string.IsNullOrEmpty(FullName)) return;
                Readers.Add(new Reader { ReaderId = ReaderId, FullName = FullName, PhoneNumber = PhoneNumber });
                ReaderId = FullName = PhoneNumber = string.Empty;
            });

            DeleteReaderCommand = new RelayCommand(obj => {
                if (SelectedReader != null) Readers.Remove(SelectedReader);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}