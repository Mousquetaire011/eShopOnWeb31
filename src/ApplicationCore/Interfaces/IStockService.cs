using Microsoft.eShopWeb.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface iStockService
    {
        Task<Stock> GetStockByID(int StockID);
    }
}
