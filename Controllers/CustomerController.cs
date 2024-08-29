using Microsoft.AspNetCore.Mvc;
using CLDV6212_ST10339829_POE.Models;

namespace CLDV6212_ST10339829_POE.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TableService _tableService;
        public CustomerController()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=st10339829;AccountKey=cOF7hh8IkmDMvijlGOFBy0bchy4PgaO2Rvj4ebBJcCQ2wW2B/lUEgRigBoAn2E8kfyD6jiMsVnNr+AStlo/5LA==;EndpointSuffix=core.windows.net";
            _tableService = new TableService(connectionString);
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _tableService.GetCustomersAsync();
            return View(customers);
        }
        public IActionResult Create() => View();
        public async Task<IActionResult> Create(Customer customer) 
        {
           if (ModelState.IsValid) 
           { 
               await _tableService.AddCustomerTableAsync(customer);
               return RedirectToAction(nameof(Index));
           }
           return View(customer);
        }
    }
}
