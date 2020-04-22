using System.ComponentModel.DataAnnotations;

namespace CGIBack.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
