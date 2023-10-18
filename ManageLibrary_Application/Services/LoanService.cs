using System.Text.Json;
using AutoMapper;
using ManageLibrary_Application.DTOs;
using ManageLibrary_Application.DTOs.Loan;
using ManageLibrary_Application.Interfaces;
using ManageLibrary_Domain.Entities;
using ManageLibrary_Infra.Interfaces;

namespace ManageLibrary_Application.Services {
    public class LoanService : ILoanService {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public LoanService(ILoanRepository loanRepository, IBookRepository bookRepository, ICustomerRepository customerRepository,IMapper mapper)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task AddLoan(CreateLoanDTO createLoan) {
            var loan = _mapper.Map<Loan>(createLoan);
            await _loanRepository.AddLoan(loan);
        }

        public async Task DeleteLoan(int id) {
            await _loanRepository.DeleteLoan(id);
        }

        public async Task<ReadLoanDTO> GetLoanById(int id) {
            var loan = await _loanRepository.GetLoanById(id);
            var idCustomer = loan.IdCustomer;
            var idBook = loan.IdBook;
            var readLoan = _mapper.Map<ReadLoanDTO>(loan);

            var book = await _bookRepository.GetBookById(idBook);
            var bookDTO = _mapper.Map<BookDTO>(book);

            var customer = await _customerRepository.GetCustomerById(idCustomer);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            readLoan.Book = bookDTO;
            readLoan.Customer = customerDTO;
            return readLoan;
        }

        public async Task UpdateLoan(CreateLoanDTO createLoan) {
            var loan = _mapper.Map<Loan>(createLoan);
            await _loanRepository.UpdateLoan(loan);
        }
    }
}
