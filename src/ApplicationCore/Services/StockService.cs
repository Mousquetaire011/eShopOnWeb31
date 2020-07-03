using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class StockService : iStockService
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<CatalogItem> _itemRepository;
        private readonly IAsyncRepository<Stock> _stockRepository;
        public async Task AddItemToStockAsync(int itemID, int Quantity, int Max, CatalogBrand Brand)
        {
            CatalogItem item = await _itemRepository.GetByIdAsync(itemID);
            Stock stock = new Stock();
            stock.item = item;
            stock.Quantity = Quantity;
            stock.MaxQuantity = Max;
            stock.Brand = Brand;
            await _stockRepository.AddAsync(stock);

        }

        public async Task DeleteStockAsync(int StockID)
        {
            var stock = await _stockRepository.GetByIdAsync(StockID);
            await _stockRepository.DeleteAsync(stock);
        }

        public async Task<Stock> GetStockByID(int StockID)
        {
            var stock = await _stockRepository.GetByIdAsync(StockID);
            return stock;
        }

        public Task GetStockByID<Stock>(int StockID)
        {
            throw new System.NotImplementedException();
        }

        Stock iStockService.GetStockByID(int StockID)
        {
            throw new System.NotImplementedException();
        }
    }
}
