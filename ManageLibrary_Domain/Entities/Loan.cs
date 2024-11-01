using System.ComponentModel.DataAnnotations.Schema;
using ManageLibrary_Domain.Abstract;
using ManageLibrary_Domain.Validations;

namespace ManageLibrary_Domain.Entities {
    public class Loan : Base {
        public int IdCustomer { get; private set; }
        public Customer Customer { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime Date => DateTime.Now;

        public Loan(int idCustomer, int idBook)
        {
            DomainExceptionValidation.When(idCustomer < 0, "Informe um id de cliente válido");
            DomainExceptionValidation.When(idBook < 0, "Informe um id de livro válido");

            IdCustomer = idCustomer;
            IdBook = idBook;
        }

        public Loan(Customer customer, Book book)
        {
            Customer = customer;
            Book = book;
        }
    }
}
