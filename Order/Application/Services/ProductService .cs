using Core.DTOs;
using Core.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>>? GetAllProductsAsync()
        {
            var products = await (_productRepository.GetAllAsync());
            var productDtos = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();
            return productDtos;
        }

        public async Task<ProductDto>? GetProductById(int productId)
        {
            var product = await _productRepository.GetById(productId);
            if (product == null)
            {
                return null;
            }
            var productDto = new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
            return productDto;
        }

        public async Task<bool> AddProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock
            };
            return await _productRepository.AddAsync(product);
        }

        public async Task<bool> UpdateProduct(int ProductId, ProductDto productDto)
        {
            var ProductByName = await _productRepository.GetByName(productDto.Name);
            var ProductById = await _productRepository.GetById(ProductId);
            if (ProductByName == null || ProductById == null || ProductByName.Id != ProductById.Id)
            {
                return false;
            }
            ProductByName.Name = productDto.Name;
            ProductByName.Price = productDto.Price;
            ProductByName.Stock = productDto.Stock;
            return await _productRepository.Update(ProductByName);

        }
    }
}
