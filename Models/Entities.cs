
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Entities
    {
        public int Id { get; set; }
        //[Display(Name = "Priority")]
        //public priority priority { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [MaxLength(100)]
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
