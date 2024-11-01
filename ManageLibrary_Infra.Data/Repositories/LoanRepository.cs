using ManageLibrary_Domain.Entities;
using ManageLibrary_Infra.Context;
using ManageLibrary_Infra.Interfaces;

namespace ManageLibrary_Infra.Repositories {
    public class LoanRepository : ILoanRepository {
        private readonly AppDbContext _appDbContext;
        public LoanRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddLoan(Loan loan) {
            await _appDbContext.Loan.AddAsync(loan);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteLoan(int id) {
            var loan = await GetLoanById(id);

            _appDbContext.Loan.Remove(loan);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Loan> GetLoanById(int id) {
            var loan = (from lo in _appDbContext.Loan
                        join cs in _appDbContext.Customer on lo.IdCustomer equals cs.Id
                        join bo in _appDbContext.Book on lo.IdBook equals bo.Id
                        where lo.Id == id
                        select new Loan(cs, bo)).FirstOrDefault();

            return loan ?? throw new Exception("Não foi encontrado nenhum empréstimo");
        }

        public async Task<ICollection<Loan>> GetLoansByIdCustomer(int idCustomer) {
            var query = from loans in _appDbContext.Loan
                        where loans.IdCustomer == idCustomer
                        select loans;

            return query.ToList();
        }

        public async Task UpdateLoan(Loan loan) {
            _appDbContext.Loan.Update(loan);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
