using FluentAssertions;
using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Test.Domain {
    public class CustomerTest {
        [Fact(DisplayName = "Testing if the name customer is null or longer than 100 caracteres")]
        public void Test_Validation_Customer_Name() {
            string? nameNull = null;
            string nameLongerThan100Caracteres = "Nome Maior do que 100 caracteres, Nome Maior do que 100 caracteres, Nome Maior do que 100 caracteres, Nome Maior do que 100 caracteres";
            ICollection<Loan> loans = null;

            Action actionNameNull = () => new Customer(nameNull, "03810935780", "61982879158", "teste@gmail.com", loans);

            Action actionNameIsLongerThan100Caracteres = () =>
                new Customer(nameLongerThan100Caracteres, "03810935780", "61982879158", "teste@gmail.com", loans);

            actionNameNull.Should()
                .Throw<Exception>()
                .WithMessage("O nome não pode ser vazio e nem ter mais do que 100 caracteres");

            nameNull.Should()
                .BeNull();

            actionNameIsLongerThan100Caracteres.Should()
                .Throw<Exception>()
                .WithMessage("O nome não pode ser vazio e nem ter mais do que 100 caracteres");

            nameLongerThan100Caracteres.Count()
                .Should()
                .BeGreaterThan(100);
        }

        [Fact(DisplayName = "Testing if the CPF customer is null or longer than 11 caracteres")]
        public void Test_Validation_Customer_CPF() {
            ICollection<Loan> loans = null;
            string? cpfNull = null;
            string cpfLongerThan11Caracteres = "03810935780111";
            Action actionCustomerCPFNull = () => new Customer("Nome teste", cpfNull, "61982879158", "teste@gmail.com", loans);

            Action actionCustomerCPFIsLongerThan11Caracteres = () =>
                new Customer("Nome teste",
                cpfLongerThan11Caracteres,
                "61982879158",
                "teste@gmail.com",
                loans);

            actionCustomerCPFNull.Should()
                .Throw<Exception>()
                .WithMessage("Digite um CPF válido");

            cpfNull.Should()
                .BeNull();

            actionCustomerCPFIsLongerThan11Caracteres.Should()
                .Throw<Exception>()
                .WithMessage("Digite um CPF válido");

            cpfLongerThan11Caracteres.Count()
                .Should()
                .BeGreaterThan(11);
        }

        [Fact(DisplayName = "Testing if the phone customer is longer than 11 caracteres")]
        public void Test_Validation_Customer_Phone() {
            ICollection<Loan> loans = null;
            string phoneIsLongerThan11Caracteres = "6198287915811111";
            Action actionCustomerPhoneIsLongerThan11Caracteres = () =>
                new Customer("Nome teste",
                "03810935780",
                phoneIsLongerThan11Caracteres,
                "teste@gmail.com",
                loans);


            actionCustomerPhoneIsLongerThan11Caracteres.Should()
                .Throw<Exception>()
                .WithMessage("Digite um telefone válido");

            phoneIsLongerThan11Caracteres.Count()
                .Should()
                .BeGreaterThan(11);
        }

        [Fact(DisplayName = "Testing if the email customer is longer than 100 caracteres")]
        public void Test_Validation_Customer_Email() {
            ICollection<Loan> loans = null;
            string emailLongerThan100Caracteres = "testeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee@gmail.com";
            Action actionCustomerEmailIsLongerThan100Caracteres = () =>
                new Customer("Nome teste",
                "03810935780",
                "61982879158",
                emailLongerThan100Caracteres,
                loans);


            actionCustomerEmailIsLongerThan100Caracteres.Should()
                .Throw<Exception>()
                .WithMessage("O email não pode ter mais do que 100 caracteres");

            emailLongerThan100Caracteres.Count()
                .Should()
                .BeGreaterThan(100);
        }
    }
}
