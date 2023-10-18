using AutoMapper;
using ManageLibrary_Application.DTOs;
using ManageLibrary_Application.DTOs.Loan;
using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Application.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile {

        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, ReadCustomerDTO>();
            CreateMap<Loan, ReadLoanDTO>();
            CreateMap<Loan, CreateLoanDTO>().ReverseMap();
        }
    }
}
