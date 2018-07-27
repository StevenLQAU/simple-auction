using Auction.Common.Models.Bids;
using Auction.Common.Models.Products;
using Auction.Common.Models.Users;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Auction.Api.ExternalServices.Impl
{
    public class ExternalService : IExternalService
    {
        private readonly IOptions<ExternalEndpointOptions> _externalEndpointOptions;

        public ExternalService(IOptions<ExternalEndpointOptions> externalEndpointOptions)
        {
            _externalEndpointOptions = externalEndpointOptions;
        }

        public async Task<BidModel> CreateBid(BidModel bid)
        {
            string url = Path.Combine(_externalEndpointOptions.Value.BidApiUrl, "Bid");
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsJsonAsync(url, bid);
                return await response.Content.ReadAsAsync<BidModel>();
            }
        }

        public async Task<BidModel> GetBids(string userId)
        {
            string url = $"{_externalEndpointOptions.Value.BidApiUrl}/Bid?userId={userId}";
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsAsync<BidModel>();
            }
        }

        public async Task<BidModel> GetHighestBidOfProduct(SimpleProductModel product)
        {
            string url = Path.Combine(_externalEndpointOptions.Value.BidApiUrl, "Bid", "Product");
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsJsonAsync(url, product);
                return await response.Content.ReadAsAsync<BidModel>();
            }
        }

        public async Task<IEnumerable<BidModel>> GetHighestBids(IEnumerable<SimpleProductModel> products)
        {
            string url = Path.Combine(_externalEndpointOptions.Value.BidApiUrl, "Bid", "Products");
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsJsonAsync(url, products);
                return await response.Content.ReadAsAsync<IEnumerable<BidModel>>();
            }
        }

        public async Task<IEnumerable<ProductModel>> GetProducts(int status = 0)
        {
            string url = $"{_externalEndpointOptions.Value.ProductApiUrl}/Products?status={status}";
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsAsync<IEnumerable<ProductModel>>();
            }
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            string url = $"{_externalEndpointOptions.Value.ProductApiUrl}/Products/{model.Id}";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsJsonAsync(url, model);
                return await response.Content.ReadAsAsync<ProductModel>();
            }
        }

            public async Task<string> ValidateUser(LoginModel model)
        {
            string url = Path.Combine(_externalEndpointOptions.Value.UserApiUrl, "User", "Login");
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsJsonAsync(url, model);
                return await response.Content.ReadAsAsync<string>();
            }
        }
    }
}
