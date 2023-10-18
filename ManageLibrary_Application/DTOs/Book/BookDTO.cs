using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ManageLibrary_Domain.Abstract;

namespace ManageLibrary_Application.DTOs {
    public class BookDTO : Base{
        [Column("NAME")]
        [StringLength(100, ErrorMessage = "O nome não pode ser vazio e nem ter mais do que 100 caracteres")]
        public string Name { get; set; }
        [Column("AUTHOR")]
        [StringLength(100, ErrorMessage = "O autor não pode ter mais do que 100 caracteres")]
        public string Author { get; set; }
        [Column("AVAILABLEQUANTITY")]
        public int AvailableQuantity { get; set; }
    }
}
