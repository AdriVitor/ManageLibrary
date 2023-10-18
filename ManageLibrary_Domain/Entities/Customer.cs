using ManageLibrary_Domain.Abstract;
using ManageLibrary_Domain.Validations;

namespace ManageLibrary_Domain.Entities {
    public class Customer : Base {
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public ICollection<Loan> Loans { get; private set; }

        public Customer()
        {
            
        }

        public Customer(string name, string cpf, string phone, string email, ICollection<Loan> loans)
        {
            DomainExceptionValidation.When(name == null || name.Length > 100, "O nome não pode ser vazio e nem ter mais do que 100 caracteres");
            DomainExceptionValidation.When(cpf == null || cpf.Length > 11, "Digite um CPF válido");
            DomainExceptionValidation.When(phone.Length > 11, "Digite um telefone válido");
            DomainExceptionValidation.When(email.Length > 100, "O email não pode ser vazio e nem ter mais do que 100 caracteres");
            DomainExceptionValidation.When(email == null && phone == null, "Por favor informe o Email ou o Telefone para contato");  

            Name = name;
            CPF = cpf;
            Phone = phone;
            Email = email;
            Loans = loans;           
        }
    }
}
