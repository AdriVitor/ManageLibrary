using AutoMapper;
using ManageLibrary_Application.DTOs.Loan;
using ManageLibrary_Application.Interfaces;
using ManageLibrary_Domain.Entities;
using ManageLibrary_Infra.Interfaces;

namespace ManageLibrary_Application.Services {
    public class LoanService : ILoanService {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public LoanService(ILoanRepository loanRepository, IBookService bookService,IMapper mapper)
        {
            _loanRepository = loanRepository;
            _bookService = bookService;
            _mapper = mapper;
        }
        public async Task AddLoan(CreateLoanDTO createLoan) {      
            var loan = _mapper.Map<Loan>(createLoan);

            await _loanRepository.AddLoan(loan);
            await _bookService.UpdateAvailableQuantityBook(loan.IdBook);
        }

        public async Task DeleteLoan(int id) {
            await _loanRepository.DeleteLoan(id);
        }

        public async Task<ReadLoanDTO> GetLoanById(int id) {
            var loan = await _loanRepository.GetLoanById(id);
            var readLoan = _mapper.Map<ReadLoanDTO>(loan);

            return readLoan;
        }

        public async Task UpdateLoan(CreateLoanDTO createLoan) {
            var loan = _mapper.Map<Loan>(createLoan);
            await _loanRepository.UpdateLoan(loan);
        }
    }
}
