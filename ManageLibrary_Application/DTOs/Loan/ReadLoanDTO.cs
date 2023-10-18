using ManageLibrary_Application.DTOs;
using ManageLibrary_Domain.Abstract;
using ManageLibrary_Domain.Entities;
public class ReadLoanDTO : Base {
    public CustomerDTO Customer { get; set; }
    public BookDTO Book { get; set; }
    public DateTime Date => DateTime.Now;
}

