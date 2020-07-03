using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class ProvidersViewModel
    {
        private const string DEFAULT_STATUS = "Pending";
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressNumber { get; set; }
        public string AddressStreet { get; set; }
        public string AddressPostcode { get; set; }
        public decimal AddressCity { get; set; }
        public decimal Siren { get; set; }
    }
}
