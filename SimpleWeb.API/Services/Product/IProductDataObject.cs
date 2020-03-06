using SimpleWeb.API.Services.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWeb.API.Services.Product
{
    public interface IProductDataObject
    {
        Task<IEnumerable<ProductDto>> GetProductList();
        Task<ProductDto> GetProduct(Guid id);
        Task<Guid> SaveProduct(ProductDto dto);
        Task<bool> DeleteProduct(Guid id);
    }
}
