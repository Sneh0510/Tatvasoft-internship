using BooksApi.Entities.Entities;
using BooksApi.Entities.Repositories.Interface;
using BooksApi.Models;
using BooksApi.Services.Services.Interface;

namespace BooksApi.Services
{
    // For CRUD on books
    public class BookService : IBookService
    {
        private List<Book> _books;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _books = new List<Book>();
        }

        // To Add Book
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        // To Get All Books
        public List<Book> GetAll()
        {
            return _books;
        }

        // To Get Single Book
        public Book? GetBookById(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        public async Task InsertBook(BookDetails bookDetails)
        {
            await _bookRepository.InsertBook(bookDetails);
        }


        public BookDetails GetBookDetailsById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public async Task<List<BookDetails>> GetAllFromDBAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task updateBook(BookDetails bookDetails)
        {
            await _bookRepository.UpdateBook(bookDetails);
        }

        public async Task DeleteBook(int id)
        {
            await _bookRepository.DeleteBook(id);
        }
    }
}
