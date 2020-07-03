using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class Stock : BaseEntity, IAggregateRoot
    {
        public CatalogItem item { get; set; }
        public int Quantity { get; set; }
        public int MaxQuantity { get; set; }
        public CatalogBrand Brand { get; set; }
    }
}
