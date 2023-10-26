using ManageLibrary_Application.DTOs;
using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Application.Interfaces
{
    public interface IBookService {
        public Task<Book> GetBookById(int id);
        public Task<BookDTO> GetBookByIdLoan(int idLoan);
        public Task AddBook(BookDTO book);
        public Task UpdateBook(BookDTO book);
        public Task DeleteBook(int id);
        public Task UpdateAvailableQuantityBook(int id);
    }
}
