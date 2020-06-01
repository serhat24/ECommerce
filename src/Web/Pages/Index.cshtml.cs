using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.eShopWeb.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogViewModelService _catalogViewModelService;
        private readonly ICatalogSearchService _catalogSearchService;
        [BindProperty(SupportsGet = true)]
        public string searchText { get; set; }
        public IndexModel(ICatalogViewModelService catalogViewModelService,ICatalogSearchService catalogSearchService)
        {
            _catalogViewModelService = catalogViewModelService;
            _catalogSearchService = catalogSearchService;
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
                await OnGet(catalogModel,pageId);
            }
            else
            {
                CatalogModel =
                                await _catalogSearchService.GetCatalogItemsSearch(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied, searchText);
                searchText = null;
            }
            


        }
    }
}
