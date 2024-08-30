using Microsoft.AspNetCore.Mvc;

namespace CLDV6212_ST10339829_POE.Controllers
{
    public class OrderController : Controller
    {
        private readonly AzureQueueService _azureQueueService;

        public OrderController()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=st10339829;AccountKey=cOF7hh8IkmDMvijlGOFBy0bchy4PgaO2Rvj4ebBJcCQ2wW2B/lUEgRigBoAn2E8kfyD6jiMsVnNr+AStlo/5LA==;EndpointSuffix=core.windows.net";

        }
        public async Task<IActionResult> Index()
        {
            var queuedMessages = await _azureQueueService.RetriveMessagesAsync();
            return View(queuedMessages);
        }
        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string order) 
        {
            if (!string.IsNullOrEmpty(order)) 
            { 
            await _azureQueueService.CreateMessageAsync(order);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
