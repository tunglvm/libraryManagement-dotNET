using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using libraryManagement.Models;

namespace libraryManagement.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        // Danh sách sách hiển thị trên DataGrid
        public ObservableCollection<Book> Books { get; set; }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set { _selectedBook = value; OnPropertyChanged(); }
        }

        // Các thuộc tính binding tới Form nhập liệu
        private string _bookId;
        public string BookId { get => _bookId; set { _bookId = value; OnPropertyChanged(); } }

        private string _title;
        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }

        private string _author;
        public string Author { get => _author; set { _author = value; OnPropertyChanged(); } }

        private string _category;
        public string Category { get => _category; set { _category = value; OnPropertyChanged(); } }

        private int _publishingYear;
        public int PublishingYear { get => _publishingYear; set { _publishingYear = value; OnPropertyChanged(); } }

        private int _quantity;
        public int Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(); } }

        // Khai báo các lệnh (Commands) cho Button
        public ICommand AddBookCommand { get; }
        public ICommand DeleteBookCommand { get; }

        public BookViewModel()
        {
            // Khởi tạo dữ liệu mẫu ban đầu
            Books = new ObservableCollection<Book>
            {
                new Book { BookId = "B001", Title = "Lập trình C# nâng cao", Author = "Nguyễn Văn A", Category = "Công nghệ", PublishingYear = 2024, TotalQuantity = 10, AvailableQuantity = 10 },
                new Book { BookId = "B002", Title = "Cấu trúc dữ liệu và Giải thuật", Author = "Trần Thị B", Category = "Công nghệ", PublishingYear = 2023, TotalQuantity = 5, AvailableQuantity = 5 }
            };

            // Gán hành động cho các Command
            AddBookCommand = new RelayCommand(ExecuteAddBook);
            DeleteBookCommand = new RelayCommand(ExecuteDeleteBook);
        }

        private void ExecuteAddBook(object obj)
        {
            if (string.IsNullOrEmpty(BookId) || string.IsNullOrEmpty(Title)) return;

            Books.Add(new Book
            {
                BookId = BookId,
                Title = Title,
                Author = Author,
                Category = Category,
                PublishingYear = PublishingYear,
                TotalQuantity = Quantity,
                AvailableQuantity = Quantity
            });

            ClearForm();
        }

        private void ExecuteDeleteBook(object obj)
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook);
            }
        }

        private void ClearForm()
        {
            BookId = string.Empty;
            Title = string.Empty;
            Author = string.Empty;
            Category = string.Empty;
            PublishingYear = 0;
            Quantity = 0;
        }

        // Cơ chế thông báo cập nhật giao diện tự động khi thay đổi giá trị trong code
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}