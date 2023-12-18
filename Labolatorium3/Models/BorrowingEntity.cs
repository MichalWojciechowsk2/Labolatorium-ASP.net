using Data.Entities;
using ModelsLibrary;

namespace Labolatorium3.Models
{
    public class BorrowingEntity
    {
        public int Id { get; set; }
        public string BorrowingName { get; set; }
        public string Description { get; set; }

        public BorrowingPerson BorrowingPerson { get; set; }
        public ISet<BookEntity> Books { get; set; }
    }
}
