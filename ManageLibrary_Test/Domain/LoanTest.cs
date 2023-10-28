using FluentAssertions;
using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Test.Domain {
    public class LoanTest {
        [Fact(DisplayName = "Testing if the idCustomer longer than 0")]
        public void Test_Validate_Loan_IdCustomer() {
            int idCustomer = -1;
            int idBook = 5;
            Action actionLoanIdCustomerLessThan0 = () => new Loan(idCustomer, idBook);

            actionLoanIdCustomerLessThan0.Should()
                .Throw<Exception>()
                .WithMessage("Informe um id de cliente válido");

            idCustomer.Should()
                .BeLessThan(0);
        }

        [Fact(DisplayName = "Testing if the idBook longer than 0")]
        public void Test_Validate_Loan_IdBook() {
            int idCustomer = 5;
            int idBook = -1;
            Action actionLoanIdBookLessThan0 = () => new Loan(idCustomer, idBook);

            actionLoanIdBookLessThan0.Should()
                .Throw<Exception>()
                .WithMessage("Informe um id de livro válido");

            idBook.Should()
                .BeLessThan(0);
        }
    }
}
