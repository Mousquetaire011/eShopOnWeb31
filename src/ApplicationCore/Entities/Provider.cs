using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class Provider : BaseEntity, IAggregateRoot
    {
        public decimal Name { get; set; }
        public int AddressNumber { get; set; }
        public int AddressStreet { get; set; }
        public int AddressPostcode { get; private set; }
        public int AddressCity { get; private set; }
        public int Siren { get; private set; }
    }
}
