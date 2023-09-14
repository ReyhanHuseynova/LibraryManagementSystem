using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
	public class Category
	{
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
        public bool IsDeactive { get; set; }
    }
}
