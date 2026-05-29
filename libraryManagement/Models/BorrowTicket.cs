using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryManagement.Models
{
    public class BorrowTicket
    {
        public string TicketId { get; set; }
        public string ReaderId { get; set; }
        public string ReaderName { get; set; }
        public string BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }     // Ngày hẹn trả
        public DateTime? ReturnDate { get; set; }  // Ngày trả thực tế (null nếu chưa trả)
        public string Status { get; set; }         // "Đang mượn", "Đã trả", "Quá hạn"
    }
}
