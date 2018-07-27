using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Product.Api.Controllers.ViewModels;
using Auction.Product.Api.Repositories;

namespace Auction.Product.Api.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductModel>> GetAll(int status = 0)
        {
            List<ProductStatus> productStatuses = new List<ProductStatus>();

            var values = Enum.GetValues(typeof(ProductStatus));

            foreach(var value in values)
            {
                if(status == 0 || ((status & (int)value) == (int)value))
                {
                    productStatuses.Add((ProductStatus)value);
                }
            }

            //if((status & (int)ProductStatus.End) == (int)ProductStatus.End)
            //{
            //    productStatuses.Add(ProductStatus.End);
            //}

            //if ((status & (int)ProductStatus.InBid) == (int)ProductStatus.InBid)
            //{
            //    productStatuses.Add(ProductStatus.InBid);
            //}

            //if ((status & (int)ProductStatus.NotStart) == (int)ProductStatus.NotStart)
            //{
            //    productStatuses.Add(ProductStatus.NotStart);
            //}

            return (await _productRepository.GetAll(productStatuses)).Select(p => new ProductModel(p));
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var product = await _productRepository.GetById(model.Id);

            product.Status = model.Status;
            await _productRepository.Update(product);
            return new ProductModel(product);
        }
    }
}
