using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        
        [Required]
        public string Category { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")] // This makes it so they have to enter a valid year
        public int Year { get; set; }
        
        [Required]
        public string Director { get; set; }
        
        [Required]
        public string Rating { get; set; }
        
        public bool? Edited { get; set; }
        
        public string? LentTo { get; set; }
        
        [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters")] // The string can't be longer than 25 characters
        public string? Notes {get; set;}
    }
}