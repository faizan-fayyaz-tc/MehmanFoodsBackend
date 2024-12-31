using AutoMapper;
using MehmanFoods.Core.DTOs.Customer;
using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using MehmanFoods.Core.IService;
using MehmanFoods.Repository;
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

        public async Task DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
        }

        public async Task<IEnumerable<CustomerFetchDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return _mapper.Map<IEnumerable<CustomerFetchDto>>(customers);
        }

        public async Task<CustomerFetchDto> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            return _mapper.Map<CustomerFetchDto>(customer);
        }

        public async Task UpdateCustomerAsync(CustomerUpdateDto customerUpdateDto)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customerUpdateDto.CustomerId);

            if(existingCustomer != null)
            {
                existingCustomer.FullName = customerUpdateDto.FullName;
                existingCustomer.PhoneNumber = customerUpdateDto.PhoneNumber;
                existingCustomer.Email = customerUpdateDto.Email;
                existingCustomer.Address = customerUpdateDto.Address;
                existingCustomer.PreferredContactMethod = customerUpdateDto.PreferredContactMethod;
                existingCustomer.IsActive = customerUpdateDto.IsActive;
                existingCustomer.Notes = customerUpdateDto.Notes;

                await _customerRepository.UpdateCustomerAsync(existingCustomer);
            }
            else
            {
                throw new KeyNotFoundException("Customer with the specified ID was not found.");
            }
        }
    }
}
