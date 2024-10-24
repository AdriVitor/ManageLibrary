using ManageLibrary_Domain.Abstract;

namespace ManageLibrary_Application.DTOs {
    public class CustomerDTO : Base {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
