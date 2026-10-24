namespace librarymanagementDAO.Entities
{
    public class BookCopy
    {
        public string BookCopyId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;       // Trạng thái (vd: Có sẵn, Đang mượn, Đã đặt trước)
        public string Condition { get; set; } = string.Empty;    // Tình trạng (vd: Mới, Cũ, Hỏng, Rách)

        // Khóa ngoại liên kết tới Book
        public string BookId { get; set; } = string.Empty;
        public virtual Book? Book { get; set; }
    }
}
