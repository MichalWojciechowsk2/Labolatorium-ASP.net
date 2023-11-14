
using System.ComponentModel.DataAnnotations;

namespace ModelsLibrary
{
    public class Book
    {
        //[HiddenInput]
        public int Id { get; set; }
        //[Display(Name = "Priority")]
        public Priority Priority { get; set; }

        [Required(ErrorMessage = "enter the book title")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "To much characters")]
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Display(Name = "NumberOfPages")]
        public int NumberOfPages { get; set; }
        [Display(Name = "ISBN")]
        public int ISBN { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "PublicationDate")]
        public DateTime PublicationDate { get; set; }
        [Display(Name = "PublishingHouse")]
        public string PublishingHouse { get; set; }
        //[HiddenInput]
        public DateTime Created { get; set; }

    }
}
