using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDto>>? GetAllProductsAsync();
		Task<ProductDto>? GetProductById(int productId);
		Task<bool> AddProduct(ProductDto productDto);
		Task<bool> UpdateProduct(int ProductId,ProductDto productDto);
	}
}
