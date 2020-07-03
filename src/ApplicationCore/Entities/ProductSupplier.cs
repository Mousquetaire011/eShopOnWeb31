﻿using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class ProductSupplier : BaseEntity, IAggregateRoot
    {
        public int CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
