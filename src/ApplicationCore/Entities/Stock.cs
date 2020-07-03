using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class Stock : BaseEntity, IAggregateRoot
    {
        public int CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int Quantity { get; set; }
    }
}
