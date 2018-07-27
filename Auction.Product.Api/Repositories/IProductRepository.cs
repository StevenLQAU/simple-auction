using Auction.Common.Data.MongoDB;
using Auction.Product.Api.Controllers.ViewModels;
using Auction.Product.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Product.Api.Repositories
{
    public interface IProductRepository: IRepositoryBase<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAll(IEnumerable<ProductStatus> status);
        Task CreateSample();
    }
}
