using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class CatalogHasProviders : BaseEntity, IAggregateRoot
    {
        public int DeliveryDelayDays { get; set; }
        public decimal Price { get; set; }
        public int catalogId { get; set; }
        public int providerId { get; private set; }
    }
}
