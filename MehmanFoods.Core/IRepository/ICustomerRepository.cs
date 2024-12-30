using MehmanFoods.Core.DTOs.Customer;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface ICustomerRepository 
    {
        Task AddCustomerAsync(Customer customerCreateDto);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(Customer customerCreateDto);
        Task DeleteCustomerAsync(int customerId);
    }
}
