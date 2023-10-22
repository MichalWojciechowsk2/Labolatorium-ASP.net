using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Labolatorium3.Models
{
    public class Book
    {
        [HiddenInput]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Enter the book title")]
        public string Title { get; set; }
        //[StringLength(maximumLength: 100, ErrorMessage = "To much characters")]
        public string Author { get; set; }
        //[MaxLength(10000)]
        public int NumberOfPages { get; set; }
        //[MaxLength(13)]
        public int ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public string PublishingHouse { get; set; }

    }
}
