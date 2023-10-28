using FluentAssertions;
using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Test.Domain {
    public class BookTest {
        [Fact(DisplayName = "Testing if the book name is null or longer than 100 caracteres")]
        public void Test_Validation_Book_Name() {

            Action actionNameNullValue = () => new  Book(null, "Autor teste", 19);

            Action actionNameLongerThan100CaracteresValue = () => 
                new Book("Nome Maior do que 100 caracteres, Nome Maior do que 100 caracteres, Nome Maior do que 100 caracteres, Nome Maior do que 100 caracteres",
                "Autor teste", 
                19);

            actionNameNullValue.Should()
                .Throw<Exception>()
                .WithMessage("O nome não pode ser vazio e nem ter mais do que 100 caracteres");

            actionNameLongerThan100CaracteresValue.Should()
                .Throw<Exception>()
                .WithMessage("O nome não pode ser vazio e nem ter mais do que 100 caracteres");
        }

        [Fact(DisplayName = "Testing if the author is longer than 100 characters")]
        public void Test_Validation_Book_Author() {

            Action actionNameLongerThan100CaracteresValue = () =>
                new Book("Nome teste",
                "Autor Maior do que 100 caracteres, Autor Maior do que 100 caracteres, Autor Maior do que 100 caracteres, Autor Maior do que 100 caracteres",
                15);

            actionNameLongerThan100CaracteresValue.Should()
                .Throw<Exception>()
                .WithMessage("O autor não pode ter mais do que 100 caracteres");
        }

        [Fact(DisplayName = "Testing if the available quantity is longer than 0")]
        public void Test_Validation_Book_AvailableQuantity() {
            Action actionAvailableQuantityBook = () => new Book("Nome teste", "Autor Teste", -1);

            actionAvailableQuantityBook.Should()
                .Throw<Exception>()
                .WithMessage("O livro está indisponível");
        }
    }
}
