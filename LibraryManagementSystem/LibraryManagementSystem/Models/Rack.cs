using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Rack
    {
        public int Id { get; set; }
        [Required]
        public string RackNumber { get; set; }
        public bool IsDecative { get; set; }
        public List<Author> Authors { get; set; }
    }
}
