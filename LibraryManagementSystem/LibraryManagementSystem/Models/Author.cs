using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string BookName { get; set; }
        public bool IsDeactive { get; set; }
        public Publiser Publiser { get; set; }
        public int PubliserId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int RackId { get; set; }
        public Rack Rack { get; set; }
        public List<IssueBook> IssueBooks { get; set; }
    }
}
