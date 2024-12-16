using AutoMapper;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddProductAsync(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            await _productRepository.AddProductAsync(product);
        }

        public Task DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(updateProductDto.ProductId);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {updateProductDto.ProductId} not found.");
            }

            if (updateProductDto.ExpiryDate < updateProductDto.ProductionDate)
            {
                throw new ArgumentException("Expiry date cannot be earlier than the production date.");
            }

            var updateProduct = _mapper.Map<Product>(updateProductDto);

            existingProduct.ProductQuantity = updateProduct.ProductQuantity;
            existingProduct.ProductPrice = updateProduct.ProductPrice;
            existingProduct.ProductionDate = updateProduct.ProductionDate;
            existingProduct.ExpiryDate = updateProduct.ExpiryDate;
            existingProduct.ProductName = updateProduct.ProductName;
            existingProduct.ProductWholeSalePrice = updateProduct.ProductWholeSalePrice;

            await _productRepository.UpdateProductAsync(existingProduct);
        }
    }
}
