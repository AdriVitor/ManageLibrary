using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ManageLibrary_Domain.Abstract;
using ManageLibrary_Domain.Validations;

namespace ManageLibrary_Domain.Entities {
    public class Book : Base {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int AvailableQuantity { get; private set; }
        public Loan? Loan { get; set; }

        public Book()
        {
            
        }

        public Book(string name, string author, int availableQuantity, Loan? loan = null)
        {
            DomainExceptionValidation.When(name == null || name.Length > 100, "O nome não pode ser vazio e nem ter mais do que 100 caracteres");
            DomainExceptionValidation.When(author.Length > 100, "O autor não pode ter mais do que 100 caracteres");
            DomainExceptionValidation.When(availableQuantity < 0, "O livro está indisponível");

            Name = name;
            Author = author;
            AvailableQuantity = availableQuantity;
            Loan = loan;
        }
    }
}
