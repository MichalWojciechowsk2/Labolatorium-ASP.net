using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("books")]
    public class BookEntity
    {
        public int Id { get; set; }
        public Priority Priority { get; set; }

        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
        public int ISBN { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        public string PublishingHouse { get; set; }
    }
}
