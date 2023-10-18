using ManageLibrary_Application.Interfaces;
using ManageLibrary_Application.Mappings;
using ManageLibrary_Application.Services;
using ManageLibrary_Infra.Context;
using ManageLibrary_Infra.Interfaces;
using ManageLibrary_Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManageLibrary_Infra.Ioc {
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });
            //Dependency Injection

            //Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();

            //Repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            //Mappings
            services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

            return services;
        }
    }
    
}