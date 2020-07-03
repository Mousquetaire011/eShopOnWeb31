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
        public async Task SetStocksAfterOrder(int stockId, int orderId)
        {
            
        }
    }
}
