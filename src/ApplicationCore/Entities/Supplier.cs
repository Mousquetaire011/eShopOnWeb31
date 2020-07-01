using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class Supplier : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
