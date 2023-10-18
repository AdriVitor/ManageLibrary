using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ManageLibrary_Domain.Abstract;

namespace ManageLibrary_Application.DTOs;

public class ReadCustomerDTO : Base {
        [Column("NAME")]
        [StringLength(100, ErrorMessage = "O nome não pode ser vazio e nem ter mais do que 100 caracteres")]
        public string Name { get; set; }
        [Column("CPF")]
        [StringLength(100, ErrorMessage = "Digite um CPF válido")]
        public string CPF { get; set; }
        [Column("PHONE")]
        [StringLength(100, ErrorMessage = "Digite um telefone válido")]
        public string Phone { get; set; }
        [Column("EMAIL")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais do que 100 caracteres")]
        public string Email { get; set; }
        public ICollection<ReadLoanDTO> Loans { get; set; }
    }