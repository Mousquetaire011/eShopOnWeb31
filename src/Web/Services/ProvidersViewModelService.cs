using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Services
{
    /// <summary>
    /// This is a UI-specific service so belongs in UI project. It does not contain any business logic and works
    /// with UI-specific types (view models and SelectListItem types).
    /// </summary>
    public class ProvidersViewModelService : IProvidersViewModelService
    {
        private readonly IProvidersViewModelService _providersViewModelService;

        public ProvidersModel(IProvidersViewModelService providersViewModelService)
        {
            _providersViewModelService = providersViewModelService;
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetProvidersItem(CatalogItemViewModel viewModel)
        {
            //Get existing CatalogItem
            var existingProvidersItem = await _providersViewModelService.GetByIdAsync(viewModel.Id).ConfigureAwait(true);

            //Build updated CatalogItem
            var updatedCatalogItem = existingCatalogItem;
            updatedCatalogItem.Name = viewModel.Name;
            updatedCatalogItem.Price = viewModel.Price;

            await _providersViewModelService.UpdateAsync(updatedCatalogItem).ConfigureAwait(true);
        }

        public Task<CatalogIndexViewModel> GetProvidersItems(int pageIndex, int itemsPage, int? catalogId)
        {
            throw new NotImplementedException();
        }
    }
}
