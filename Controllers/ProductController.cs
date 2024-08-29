using Microsoft.AspNetCore.Mvc;
using CLDV6212_ST10339829_POE.Models;

namespace CLDV6212_ST10339829_POE.Controllers
{
    public class ProductController : Controller
    {
        private readonly TableService _tableService;
        public ProductController() 
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=st10339829;AccountKey=cOF7hh8IkmDMvijlGOFBy0bchy4PgaO2Rvj4ebBJcCQ2wW2B/lUEgRigBoAn2E8kfyD6jiMsVnNr+AStlo/5LA==;EndpointSuffix=core.windows.net";
            _tableService = new TableService(connectionString);
        }
        public async Task<IActionResult> Index() 
        { 
            var products = await _tableService.GetProductsAsync();
            return View(products);
        }
        public IActionResult Create() => View();
        public async Task<IActionResult> Create(Product product) 
        {
           if(ModelState.IsValid)
           {
               await _tableService.AddProductTableAsync(product);
               return RedirectToAction(nameof(Index));
           }
           return View(product);
        }
    }
}
