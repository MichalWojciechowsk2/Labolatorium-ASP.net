using Data;
using ModelsLibrary;

namespace Labolatorium3.Models
{
    public class BookMapper
    {
        public static Book FromEntity(Entities entity)
        {
            return new Book()
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                NumberOfPages = entity.NumberOfPages,
                ISBN = entity.ISBN,
                PublicationDate = entity.PublicationDate,
                PublishingHouse = entity.PublishingHouse,
                Created = entity.Created,
            };
        }

        public static Entities ToEntity(Book model)
        {
            return new Entities()
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                NumberOfPages = model.NumberOfPages,
                ISBN = model.ISBN,
                PublicationDate = model.PublicationDate,
                PublishingHouse = model.PublishingHouse,
                Created = model.Created,
            };
        }
    }
}
