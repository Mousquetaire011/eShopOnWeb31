using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Constants;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;
using System;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Pages.Admin
{
    [Authorize(Roles = AuthorizationConstants.Roles.ADMINISTRATORS)]
    public class ProvidersModel : PageModel
    {
        private readonly IProvidersViewModelService _providersViewModelService;

        public ProvidersModel(IProvidersViewModelService providersViewModelService)
        {
            _providersViewModelService = providersViewModelService;
        }

        [BindProperty]
        public ProvidersViewModel ProvidersModel { get; set; } = new ProvidersViewModel();

        public async Task OnGet(ProvidersViewModel providersModel)
        {
            await Task.Run(() =>
            {
                ProvidersModel = providersModel;
            }).ConfigureAwait(true);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _providersViewModelService.UpdateProvidersItem(ProvidersModel).ConfigureAwait(true);
            }

            return RedirectToPage("/Admin/Index");
        }
    }
}
