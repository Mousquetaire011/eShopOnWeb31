using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class StockViewModel
    {
        public Stock stock;

        public List<SelectListItem> selectListItems;

        public List<SelectListItem> selectListSuppliers;
    }
}
