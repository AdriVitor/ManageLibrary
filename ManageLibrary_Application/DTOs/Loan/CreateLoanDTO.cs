using ManageLibrary_Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageLibrary_Application.DTOs.Loan {
    public class CreateLoanDTO : Base {
        public int IdCustomer { get; set; }
        public int IdBook { get; set; }
        public DateTime Date => DateTime.Now;
    }
}
