using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class Stock : BaseEntity, IAggregateRoot
    {
        public CatalogItem CatalogItem { get; set; }
        [NotMapped]
        public int SelectedCatalogItemId { get; set; }
        [NotMapped]
        public int SelectedSupplierId { get; set; }
        public int Quantity { get; set; }
        public Supplier Supplier { get; set; }
        public double Buyprice { get; set; }
        public bool IsFull { get; set; } 
    }

    
}
