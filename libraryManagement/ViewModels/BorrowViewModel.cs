using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using libraryManagement.Models;

namespace libraryManagement.ViewModels
{
    public class BorrowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BorrowTicket> Tickets { get; set; }
        public ObservableCollection<Book> AvailableBooks { get; set; } // Lấy danh sách sách để chọn

        private BorrowTicket _selectedTicket;
        public BorrowTicket SelectedTicket
        {
            get => _selectedTicket;
            set { _selectedTicket = value; OnPropertyChanged(); }
        }

        // Form Input Properties
        private string _readerId;
        public string ReaderId { get => _readerId; set { _readerId = value; OnPropertyChanged(); } }

        private string _readerName;
        public string ReaderName { get => _readerName; set { _readerName = value; OnPropertyChanged(); } }

        private Book _selectedFormBook;
        public Book SelectedFormBook { get => _selectedFormBook; set { _selectedFormBook = value; OnPropertyChanged(); } }

        public ICommand BorrowBookCommand { get; }
        public ICommand ReturnBookCommand { get; }

        public BorrowViewModel()
        {
            // Dữ liệu giả lập
            AvailableBooks = new ObservableCollection<Book>
            {
                new Book { BookId = "B001", Title = "Lập trình C# nâng cao", AvailableQuantity = 2, TotalQuantity = 5 },
                new Book { BookId = "B002", Title = "Cấu trúc dữ liệu và Giải thuật", AvailableQuantity = 0, TotalQuantity = 3 }
            };

            Tickets = new ObservableCollection<BorrowTicket>
            {
                new BorrowTicket { TicketId = "PT001", ReaderId = "DG01", ReaderName = "Trần Văn Hùng", BookId = "B001", BookTitle = "Lập trình C# nâng cao", BorrowDate = DateTime.Now.AddDays(-5), DueDate = DateTime.Now.AddDays(5), Status = "Đang mượn" }
            };

            BorrowBookCommand = new RelayCommand(ExecuteBorrow);
            ReturnBookCommand = new RelayCommand(ExecuteReturn);
        }

        // Logic Cho Mượn Sách
        private void ExecuteBorrow(object obj)
        {
            if (string.IsNullOrEmpty(ReaderId) || string.IsNullOrEmpty(ReaderName) || SelectedFormBook == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mượn sách!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra xem sách còn trong kho không
            if (SelectedFormBook.AvailableQuantity <= 0)
            {
                MessageBox.Show("Sách này hiện tại đã hết trong kho!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Trừ số lượng sách còn lại đi 1
            SelectedFormBook.AvailableQuantity--;

            // Tạo phiếu mượn mới (mặc định hạn 14 ngày)
            var newTicket = new BorrowTicket
            {
                TicketId = "PT" + (Tickets.Count + 1).ToString("D3"),
                ReaderId = ReaderId,
                ReaderName = ReaderName,
                BookId = SelectedFormBook.BookId,
                BookTitle = SelectedFormBook.Title,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                Status = "Đang mượn"
            };

            Tickets.Add(newTicket);
            MessageBox.Show("Cho mượn sách thành công!", "Thành công");
            ClearForm();
        }

        // Logic Trả Sách
        private void ExecuteReturn(object obj)
        {
            if (SelectedTicket == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần trả từ bảng!", "Thông báo");
                return;
            }

            if (SelectedTicket.Status == "Đã trả")
            {
                MessageBox.Show("Phiếu này đã được trả trước đó rồi!", "Thông báo");
                return;
            }

            // Cập nhật trạng thái phiếu
            SelectedTicket.ReturnDate = DateTime.Now;
            SelectedTicket.Status = "Đã trả";

            // Cộng lại số lượng sách vào kho
            foreach (var book in AvailableBooks)
            {
                if (book.BookId == SelectedTicket.BookId)
                {
                    book.AvailableQuantity++;
                    break;
                }
            }

            MessageBox.Show("Đã xử lý trả sách thành công!", "Thành công");

            // Refresh DataGrid
            var temp = SelectedTicket;
            SelectedTicket = null;
            SelectedTicket = temp;
        }

        private void ClearForm()
        {
            ReaderId = string.Empty;
            ReaderName = string.Empty;
            SelectedFormBook = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}