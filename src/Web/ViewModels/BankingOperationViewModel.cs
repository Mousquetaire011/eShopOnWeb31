using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class BankingOperationViewModel
    {
        public BankingOperations banking;
        public List<SelectListItem> orders;
        
    }
}
