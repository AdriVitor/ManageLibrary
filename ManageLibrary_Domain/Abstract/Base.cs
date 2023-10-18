using System.ComponentModel.DataAnnotations;

namespace ManageLibrary_Domain.Abstract {
    public class Base {
        [Key()]
        public int Id { get; set; }
    }
}
