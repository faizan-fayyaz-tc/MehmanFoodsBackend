using AutoMapper;
using MehmanFoods.Core.DTOs.Customer;
using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task AddCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            var customer = _mapper.Map<Customer>(customerCreateDto);
            await _customerRepository.AddCustomerAsync(customer);
        }

        public Task DeleteCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}
