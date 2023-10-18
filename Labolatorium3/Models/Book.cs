using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Labolatorium3.Models
{
    public class Book
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the book title")]
        public string title { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage ="To much characters")]
        public string author { get; set; }
        [MaxLength(10000)]
        public int numberOfPages { get; set; }
        [MaxLength(13)]
        public int ISBN { get; set; }
        public DateTime publicationDate { get; set; }
        public string publishingHouse { get; set; }

    }
}
