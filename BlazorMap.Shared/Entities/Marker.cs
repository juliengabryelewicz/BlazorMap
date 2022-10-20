using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorMap.Shared.Entities
{
    public class Marker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage="Title must be 150 characters or less"),MinLength(3)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,9)")]
        public decimal Lat { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,9)")]
        public decimal Lon { get; set; }
        public bool IsVisible { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
    }
}