using BooksApi.Entities.Entities;

namespace BooksApi.Entities.Repositories.Interface
{
    public interface IBookRepository
    {
        Task InsertBook(BookDetails bookDetails);
        BookDetails GetById(int id);
        Task<List<BookDetails>> GetAllAsync();
        Task UpdateBook(BookDetails bookDetails);
        Task DeleteBook(int id);
    }
}
