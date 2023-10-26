using AutoMapper;
using ManageLibrary_Application.DTOs;
using ManageLibrary_Application.Interfaces;
using ManageLibrary_Domain.Entities;
using ManageLibrary_Infra.Interfaces;

namespace ManageLibrary_Application.Services
{
    public class CustomerService : ICustomerService {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, ILoanRepository loanRepository, IBookService bookService, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _loanRepository = loanRepository;
            _bookService = bookService;
            _mapper = mapper;
        }
        public async Task AddCustomer(CustomerDTO customerDTO) {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.AddCustomer(customer); 
        }

        public async Task DeleteCustomer(int id) {
            await _customerRepository.DeleteCustomer(id);
        }

        public async Task<ReadCustomerDTO> GetCustomerById(int id) {
            var customer = await _customerRepository.GetCustomerById(id); 
            var loans = await _loanRepository.GetLoansByIdCustomer(id);
            
            var readCustomerDTO = _mapper.Map<ReadCustomerDTO>(customer);
            List<ReadLoanDTO> loansDTO = _mapper.Map<List<ReadLoanDTO>>(loans);
            
            foreach (var loanDTO in loansDTO)
            {
                loanDTO.Book = await _bookService.GetBookByIdLoan(loanDTO.Id);
            }

            readCustomerDTO.Loans = loansDTO;
            return readCustomerDTO;
        }

        public async Task UpdateCustomer(CustomerDTO customerDTO) {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.UpdateCustomer(customer);
        }
    }
}
