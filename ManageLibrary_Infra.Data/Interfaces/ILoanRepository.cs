using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Infra.Interfaces {
    public interface ILoanRepository {
        public Task<Loan> GetLoanById(int id);
        public Task<ICollection<Loan>> GetLoansByIdCustomer(int idCustomer);
        public Task AddLoan(Loan loan);
        public Task UpdateLoan(Loan loan);
        public Task DeleteLoan(int id);
    }
}
