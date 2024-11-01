using AutoMapper;
using ManageLibrary_Application.DTOs;
using ManageLibrary_Domain.Abstract;
using ManageLibrary_Domain.Entities;

public class ReadLoanDTO : Base {
    public CustomerDTO Customer { get; set; }
    public BookDTO Book { get; set; }
    public DateTime Date { get; set; }

    public ReadLoanDTO(Customer customer, Book book, IMapper _mapper)
    {
        Customer = _mapper.Map<CustomerDTO>(customer);
        Book = _mapper.Map<BookDTO>(book);
        Date = DateTime.Now;
    }
}

