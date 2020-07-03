using Microsoft.eShopWeb.Web.ViewModels;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Interfaces
{
    public interface IProvidersViewModelService
    {
        Task<CatalogIndexViewModel> GetProvidersItems(int pageIndex, int itemsPage, int? catalogId);
        Task GetByIdAsync(int id);
    }
}
