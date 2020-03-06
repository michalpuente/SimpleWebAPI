using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleWeb.API.Data;
using SimpleWeb.API.Services.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWeb.API.Services.Product.Impl
{
    public class ProductDataObject : IProductDataObject
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductDataObject(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> DeleteProduct(Guid id)
        {
            var entity = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
               
            else return false;
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            var dto = new ProductDto();
            _mapper.Map(entity, dto);
            return dto;

        }

        public async Task<IEnumerable<ProductDto>> GetProductList()
        {
            var entity = await _context.Products.ToListAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(entity);
            return productDtos;
        }

        public async Task<Guid> SaveProduct(ProductDto dto)
        {
            Model.Product product;

            if (dto.Id.HasValue) //edit
            {
                product = await _context.Products.FirstOrDefaultAsync(x => x.Id == dto.Id.Value);
            }
            else //new object
            {
                dto.Id = Guid.NewGuid();
                product = new Model.Product();
                _context.Products.Add(product);
                
            }

            _mapper.Map(dto, product);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
