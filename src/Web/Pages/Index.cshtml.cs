using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.eShopWeb.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogViewModelService _catalogViewModelService;
        private readonly ICatalogSearchService _catalogSearchService;
        private readonly IAsyncRepository<CatalogItem> _itemRepository;
        [BindProperty(SupportsGet = true)]
        public string searchText { get; set; }
        public IndexModel(ICatalogViewModelService catalogViewModelService, ICatalogSearchService catalogSearchService, IAsyncRepository<CatalogItem> itemRepository)
        {
            _catalogViewModelService = catalogViewModelService;
            _catalogSearchService = catalogSearchService;
            _itemRepository = itemRepository;
        }

        public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);
        }
        public async Task OnPostSearch(CatalogIndexViewModel catalogModel, int? pageId)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                await OnGet(catalogModel, pageId);
            }
            else
            {
                CatalogModel =
                                await _catalogSearchService.GetCatalogItemsSearch(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied, searchText);
                searchText = null;
            }
        }

        public async Task<JsonResult> OnGetNameSearchAsync(string term)
        {
            List<string> items = new List<string>();

            if (!string.IsNullOrEmpty(term))
            {
                var itemsName = await _itemRepository.ListAllAsync();
                items = itemsName.Where(p => p.Name.ToLower().Contains(term.ToLower()))
                    .OrderBy(p => p.Name)
                    .Select(p => p.Name)
                    .ToList();
            }


            return new JsonResult(items);
        }
    }
}
