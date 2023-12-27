using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;

namespace Labolatorium3.Models
{
    public class EFBookService : IBookService
    {
        private AppDbContext _context;
        public EFBookService(AppDbContext context)
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
            LibraryEntities? find = _context.Books.Find(id);
            if (find != null)
            {
                _context.Books.Remove(find);
                _context.SaveChanges();
            }
        }

        public void Edit(Book book)
        {
            _context.Books.Update(BookMapper.ToEntity(book));
            _context.SaveChanges();
        }

        public List<Book> FindAll()
        {
            return _context.Books.Select(e => BookMapper.FromEntity(e)).ToList();
        }

        public List<OrganizationEntity> FindAllOrganizationsForVieModel()
        {
            return _context.Organizations.ToList();
        }


        public Book? FindById(int id)
        {
            return BookMapper.FromEntity(_context.Books.Find(id));
        }

        public PagingList<Book> FindPage(int page, int size)
        {
            return PagingList<Book>.Create(
               (p, s) => _context.Books
               .OrderBy(c => c.Title)
               .Skip((p - 1) * s)
                .Take(s)
               .Select(BookMapper.FromEntity)
               .ToList()
               ,
               page,
               size,
               _context.Books.Count()
               );
        }
    }
}
