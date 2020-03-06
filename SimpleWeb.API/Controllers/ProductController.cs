using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWeb.API.Services.Product;
using SimpleWeb.API.Services.Product.Dto;

namespace SimpleWeb.API.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDataObject _productDataObject;

        public ProductController(IProductDataObject productDataObject)
        {
            _productDataObject = productDataObject;
        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var list = await _productDataObject.GetProductList();
            return Ok(list);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productDataObject.GetProduct(id);
            if (product.Id == null)
            {
                return NotFound("There is no product with this id");
            }
            else return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto dto)
        {
            try
            {
                var newId = await _productDataObject.SaveProduct(dto);
                return Ok(newId);
            }
            catch (Exception)
            {
                return BadRequest("There was problem with create new product. Check data and try again.");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto dto)
        {
            try
            {
                var id = await _productDataObject.SaveProduct(dto);
                return Ok("Product was successfully updated");
            }
            catch (Exception)
            {
                return BadRequest("There was problem with update the product. Check data and try again.");
            }
            
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            bool result = await _productDataObject.DeleteProduct(id);
            if (result)
                return Ok("Product was sucessfully removed");
            else return BadRequest("Can't find product for current Id");
        }
    }
}
