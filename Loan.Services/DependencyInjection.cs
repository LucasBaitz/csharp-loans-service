using Loan.Services.Interfaces;
using Loan.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Loan.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoanService, LoanService>();

            return services;
        }
    }
}
