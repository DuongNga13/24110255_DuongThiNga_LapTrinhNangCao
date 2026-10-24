using System.Collections.Generic;

namespace librarymanagementDAO.Entities
{
    public class Category
    {
        public string CategoryId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation property: 1 Category có nhiều Book (1 - n)
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
