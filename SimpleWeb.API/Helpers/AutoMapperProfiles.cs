using AutoMapper;
using SimpleWeb.API.Services.Product.Dto;
using SimpleWeb.API.Services.Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWeb.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product >();
        }
    }
}
