using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    class StockServices : IStockServices
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<Stock> _stockRepository;
        private readonly IAsyncRepository<CatalogItem> _itemRepository;
        public async Task SetStocksAfterOrder(int stockId, int orderId, int quantity)
        {
         /*   var order = await _orderRepository.GetByIdAsync(orderId);
            var stocks = await _stockRepository.ListAllAsync();
            var items = new List<CatalogItem>();
            foreach (var item in order.OrderItems)
            {
                
            }
       
            await _orderRepository.AddAsync(order);*/
        }
    }
}
