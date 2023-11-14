using Data;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;

namespace Labolatorium3.Models
{
    public class BookService : IBookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public int Add(Book book)
        {
            var e = _context.Books.Add(BookMapper.ToEntity(book));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            Entities? find = _context.Books.Find(id);
            if (find != null)
            {
                _context.Books.Remove(find);
            }
        }

        public void Edit(Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> FindAll()
        {
            return _context.Books.Select(e => BookMapper.FromEntity(e)).ToList();
        }

        public Book? FindById(int id)
        {
            return BookMapper.FromEntity(_context.Books.Find(id));
        }
    }
}
