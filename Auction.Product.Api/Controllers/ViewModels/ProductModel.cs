using Auction.Product.Api.Models;
using System;

namespace Auction.Product.Api.Controllers.ViewModels
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset CloseTime { get; set; }
        public ProductStatus Status { get; set; }

        public ProductModel() { }

        public ProductModel(ProductEntity entity)
        {
            Id = entity.Id.ToString();
            Name = entity.Name;
            CloseTime = entity.CloseTime;
            StartTime = entity.StartTime;
            Status = entity.Status;
        }
    }
}
