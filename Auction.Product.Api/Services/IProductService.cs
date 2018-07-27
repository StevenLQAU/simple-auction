using Auction.Product.Api.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Product.Api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAll(int status = 0);
        Task<ProductModel> UpdateProduct(ProductModel model);
    }
}
