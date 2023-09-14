using System;

namespace LibraryManagementSystem.Models
{
    public class IssueBook
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsDeactive { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
