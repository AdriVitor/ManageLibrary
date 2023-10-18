using ManageLibrary_Domain.Entities;
using ManageLibrary_Infra.Context;
using ManageLibrary_Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManageLibrary_Infra.Repositories {
    public class BookRepository : IBookRepository {
        private readonly AppDbContext _appDbContext;
        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddBook(Book book) {
            await _appDbContext.Book.AddAsync(book);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int id) {
            var book = await GetBookById(id);

            _appDbContext.Book.Remove(book);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Book> GetBookById(int id) {
            var book = await _appDbContext.Book.FirstOrDefaultAsync(b=>b.Id == id);
            if(book == null) {
                throw new Exception("Não foi encontrado nenhum livro com esse Id");
            }

            return book;
        }

        public async Task UpdateBook(Book book) {
            _appDbContext.Book.Update(book);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
