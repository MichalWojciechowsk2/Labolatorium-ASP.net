using Data.Entities;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;

namespace Labolatorium3.Models
{
    public class MemoryBookService : IBookService
    {
        private Dictionary<int, Book> _items = new Dictionary<int, Book>();
        
        private readonly IDateTimeProvider _timeProvider;

        public MemoryBookService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;  
        }

        public int Add(Book item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            item.Created = _timeProvider.GetDateTime();
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public void Edit(Book item)
        {
            _items[item.Id] = item;
        }

        public List<Book> FindAll()
        {
            return _items.Values.ToList();
        }

        public Book? FindById(int id)
        {
            return _items[id];
        }

        public List<OrganizationEntity> FindAllOrganizationsForVieModel()
        {
            return _items.Values
        .Select(book => new OrganizationEntity
        {
            Id = book.OrganizationId ?? 0,
        })
        .ToList();
        }

        public PagingList<Book> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }
    }
}
