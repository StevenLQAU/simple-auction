using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Product.Api.Controllers.ViewModels;
using Auction.Product.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductModel>> GetProducts(int status = 0)
        {
            return await _productService.GetAll(status);
        }

        [HttpPost()]
        [Route("{productId}")]
        public async Task<ProductModel> Update(string productId, ProductModel model)
        {
            if(productId != model.Id)
            {
                throw new Exception("Invalid product model");
            }
            return await _productService.UpdateProduct(model);
        }
    }
}