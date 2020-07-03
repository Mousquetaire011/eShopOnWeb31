using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    interface IStockServices
    {
        Task SetStocksAfterOrder(int stockId, int orderId);
    }
}
