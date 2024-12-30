using MehmanFoods.Core.DTOs.Customer;
using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CustomerCreateDto customerCreateDto);
        Task<CustomerFetchDto> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<CustomerFetchDto>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(CustomerCreateDto customerCreateDto);
        Task DeleteCustomerAsync(int customerId);
    }
}
