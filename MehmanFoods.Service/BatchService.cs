using AutoMapper;
using MehmanFoods.Core.DTOs.Batch;
using MehmanFoods.Core.DTOs.BatchIngredient;
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
    public class BatchService : IBatchService
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IBatchNoRepository _batchNoRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBatchIngredientRepository _batchIngredientRepository;
        private readonly IMapper _mapper;

        public BatchService(IBatchRepository batchRepository, IBatchNoRepository batchNoRepository, IProductRepository productRepository, IMapper mapper, IBatchIngredientRepository batchIngredientRepository)
        {
            _batchRepository = batchRepository;
            _batchNoRepository = batchNoRepository;
            _productRepository = productRepository;
            _batchIngredientRepository = batchIngredientRepository;
            _mapper = mapper;
        }

        public async Task AddBatchAsync(BatchCreateDto batchCreateDto)
        {
            var product = await _productRepository.GetProductByIdAsync(batchCreateDto.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            var productSymbol = product.Symbol;
            var currentYear = DateTime.Now.Year.ToString();
            var currentMonth = DateTime.Now.Month.ToString("D2");

            var lastBatchNo = await _batchNoRepository.GetLastBatchNoByProductIdAsync(batchCreateDto.ProductId);

            int nextBatchNumber;
            if (lastBatchNo != null)
            {
                var lastBatchNumber = int.Parse(lastBatchNo.BatchNumber.Split('-').Last());
                nextBatchNumber = lastBatchNumber + 1;
            }
            else
            {
                nextBatchNumber = 1;
            }

            var newBatchCode = $"{productSymbol}-{currentYear}-{currentMonth}-{nextBatchNumber}";

            using(var transaction = await _batchRepository.BeginTransactionAsync())
            {
                try
                {
                    var batch = _mapper.Map<Batch>(batchCreateDto);

                    batch.BatchCode = newBatchCode;
                    batch.ExpectedSales = batch.Quantity * product.ProductPrice;
                    await _batchRepository.AddBatchAsync(batch);

                    foreach (var batchIngredientDto in batchCreateDto.BatchIngredientsCreateDto)
                    {
                        var batchIngredient = _mapper.Map<BatchIngredient>(batchIngredientDto);
                        batchIngredient.BatchId = batch.BatchId;
                        await _batchIngredientRepository.AddBatchIngredientAsync(batchIngredient);
                    }

                    var batchNo = new BatchNo()
                    {
                        BatchNumber = newBatchCode,
                        CreatedAt = DateTime.Now,
                        ProductId = product.ProductId
                    };

                    await _batchNoRepository.AddBatchNoAsync(batchNo);
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public Task DeleteBatchAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Batch>> GetAllBatchsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Batch> GetBatchByIdAsync(int id)
        {
            return _batchRepository.GetBatchByIdAsync(id);
        }

        public Task UpdateBatchAsync(Batch unit)
        {
            throw new NotImplementedException();
        }
    }
}
