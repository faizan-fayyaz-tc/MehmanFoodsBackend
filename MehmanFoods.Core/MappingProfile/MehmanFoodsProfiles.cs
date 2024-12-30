using AutoMapper;
using MehmanFoods.Core.DTOs.Batch;
using MehmanFoods.Core.DTOs.BatchIngredient;
using MehmanFoods.Core.DTOs.Customer;
using MehmanFoods.Core.DTOs.Invoice;
using MehmanFoods.Core.DTOs.Order;
using MehmanFoods.Core.DTOs.OrderDetail;
using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.MappingProfile
{
    public class MehmanFoodsProfiles : Profile
    {
        public MehmanFoodsProfiles()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductCreateDto>();
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<Order, OrderCreateDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<Product, ProductFetchDto>();
            CreateMap<ProductFetchDto, Product>();
            CreateMap<Product, UpdateProductDto>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Customer, CustomerCreateDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<Customer, CustomerFetchDto>();
            CreateMap<CustomerFetchDto, Customer>();
            CreateMap<Batch, BatchCreateDto>();
            CreateMap<BatchCreateDto, Batch>();
            CreateMap<BatchIngredient, BatchIngredientCreateDto>();
            CreateMap<BatchIngredientCreateDto, BatchIngredient>();
        }
    }
}
