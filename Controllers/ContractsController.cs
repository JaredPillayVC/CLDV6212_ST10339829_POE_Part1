using Microsoft.AspNetCore.Mvc;

namespace CLDV6212_ST10339829_POE.Controllers
{
    public class ContractsController : Controller
    {
        private readonly AzureFileService _azureFileService;

        public ContractsController()
        {
            string connectionString = "";
            _azureFileService = new AzureFileService(connectionString);
        }
        public async Task<IActionResult> Index()
        {
            var files = await _azureFileService.FilesAsync();
            return View(files);
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile formFile)
        {
            if (formFile != null)
            {
                await _azureFileService.UploadAsync(formFile);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
