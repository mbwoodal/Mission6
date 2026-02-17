using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        
        [Required(ErrorMessage = "Please enter a movie title")]
        public string Title { get; set; }
        
        [Required]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")] // This makes it so they have to enter a valid year
        public int Year { get; set; }
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; }
        
        [Required]
        public bool Edited { get; set; }
        
        public string? LentTo { get; set; }
        
        [Required]
        public int CopiedToPlex { get; set; }
        
        [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters")] // The string can't be longer than 25 characters
        public string? Notes {get; set;}
    }
}