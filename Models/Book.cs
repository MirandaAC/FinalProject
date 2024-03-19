using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FinalProject.Models
{
    public class Book
    {
        //id, author, title, dateAdded, genre?, cover image?
        public int BookId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
         
    }
}
