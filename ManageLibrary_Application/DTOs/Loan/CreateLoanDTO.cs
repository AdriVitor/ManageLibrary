using ManageLibrary_Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageLibrary_Application.DTOs.Loan {
    public class CreateLoanDTO : Base {
        [ForeignKey("Customer")]
        [Column("IDCUSTOMER")]
        public int IdCustomer { get; set; }
        [ForeignKey("Book")]
        [Column("IDBOOK")]
        public int IdBook { get; set; }
        public DateTime Date => DateTime.Now;
    }
}
