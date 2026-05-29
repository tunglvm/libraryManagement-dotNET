using System.Collections.ObjectModel;
using System.Linq;
using libraryManagement.Models;

namespace libraryManagement.ViewModels
{
    public class DashboardViewModel
    {
        // Các số liệu thống kê
        public int TotalBooksCount { get; set; }
        public int TotalReadersCount { get; set; }
        public int ActiveBorrowsCount { get; set; }

        // Danh sách cảnh báo sách sắp hết kho
        public ObservableCollection<Book> LowStockBooks { get; set; }

        public DashboardViewModel()
        {
            // Giả lập tính toán số liệu từ hệ thống
            TotalBooksCount = 1540;
            TotalReadersCount = 320;
            ActiveBorrowsCount = 45;

            // Lọc ra các sách có số lượng còn lại < 3 để cảnh báo thủ thư
            LowStockBooks = new ObservableCollection<Book>
            {
                new Book { BookId = "B002", Title = "Cấu trúc dữ liệu và Giải thuật", Author = "Trần Thị B", AvailableQuantity = 0, TotalQuantity = 5 },
                new Book { BookId = "B009", Title = "Thiết kế giao diện WPF UI", Author = "Phạm Văn C", AvailableQuantity = 2, TotalQuantity = 10 }
            };
        }
    }
}