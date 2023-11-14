using ModelsLibrary;

namespace Labolatorium3.Models
{
    public interface IBookService
    {
        int Add(Book book);
        void Delete(int id);
        void Edit(Book book);
        List<Book> FindAll();
        Book? FindById(int id);
    }
}
