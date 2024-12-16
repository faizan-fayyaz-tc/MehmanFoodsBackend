using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MehmanFoodsDbContext _context;

        public CustomerRepository(MehmanFoodsDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public Task DeleteCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetCustomerByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
