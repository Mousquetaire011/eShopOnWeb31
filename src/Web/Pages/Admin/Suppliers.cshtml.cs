using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Constants;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;
using System;
using System.Threading.Tasks;
using Microsoft.eShopWeb.Web.Services;

namespace Microsoft.eShopWeb.Web.Pages.Admin
{
    [Authorize(Roles = AuthorizationConstants.Roles.ADMINISTRATORS)]
    public class SuppliersModel : PageModel
    {

        private readonly ICatalogViewModelService _catalogViewModelService;

        public SuppliersModel(ICatalogViewModelService catalogViewModelService)
        {
            _catalogViewModelService = catalogViewModelService;
        }

       public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied).ConfigureAwait(true);
        }
    }
}