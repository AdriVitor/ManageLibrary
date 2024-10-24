using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Infra.Interfaces {
    public interface IBookRepository {
        public Task<Book> GetBookById(int id);
        public Task<Book> GetBookByIdLoan(int idLoan);
        public Task AddBook(Book book);
        public Task UpdateBook(Book book);
        public Task UpdateBookWithCleanTracker(Book book);
        public Task DeleteBook(int id);
    }
}
