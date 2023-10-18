using ManageLibrary_Domain.Entities;
using ManageLibrary_Infra.Context;
using ManageLibrary_Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var loan = await _appDbContext.Loan.FirstOrDefaultAsync(l=>l.Id == id);
            if(loan == null) {
                throw new Exception("Não foi localizado nenhum empréstimo");
            }

            return loan;
        }

        public async Task<ICollection<Loan>> GetLoansByIdCustomer(int idCustomer) {
            var loansCustomer = await _appDbContext.Loan.Where(l => l.IdCustomer == idCustomer).ToListAsync();
            return loansCustomer;
        }

        public async Task UpdateLoan(Loan loan) {
            _appDbContext.Loan.Update(loan);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
