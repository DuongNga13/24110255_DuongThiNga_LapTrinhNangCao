using System.Collections.Generic;

namespace librarymanagementDAO.Entities
{
    public class Book
    {
        public string BookId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int NumberOfCopies { get; set; }
        public string Author { get; set; } = string.Empty;
        public int PublicationYear { get; set; }

        // Khóa ngoại liên kết tới Category
        public string CategoryId { get; set; } = string.Empty;
        public virtual Category? Category { get; set; }

        // Navigation property: 1 Book có nhiều BookCopy (1 - n)
        public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
