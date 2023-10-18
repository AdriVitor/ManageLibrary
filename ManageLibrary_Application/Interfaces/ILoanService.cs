using ManageLibrary_Application.DTOs.Loan;

namespace ManageLibrary_Application.Interfaces {
    public interface ILoanService {
        public Task<ReadLoanDTO> GetLoanById(int id);
        public Task AddLoan(CreateLoanDTO createLoanDTO);
        public Task UpdateLoan(CreateLoanDTO createLoanDTO);
        public Task DeleteLoan(int id);
    }
}
