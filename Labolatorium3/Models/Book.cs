using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Labolatorium3.Models
{
    public class Book
    {
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "Priority")]
        public Priority Priority { get; set; }

        [Required(ErrorMessage = "enter the book title")]
        public string Title { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "To much characters")]
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
        public int ISBN { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        public string PublishingHouse { get; set; }

    }
}
