using System.ComponentModel.DataAnnotations;

namespace BlazorMap.Shared.Entities
{
    public class Category
    {

        [Key]        
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage="Title must be 50 characters or less"),MinLength(3)]
        public string Title { get; set; }

        public ICollection<Marker> Marker { get; set; }

    }
}
