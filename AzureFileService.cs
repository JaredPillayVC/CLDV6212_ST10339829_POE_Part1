using Azure.Storage.Files.Shares;
using Microsoft.AspNetCore.WebUtilities;

namespace CLDV6212_ST10339829_POE
{
    public class AzureFileService
    {
        private readonly ShareClient _share;

        public AzureFileService(string connectionString)
        {
            _share = new ShareClient(connectionString, "contracts");
            _share.CreateIfNotExists();
        }

        public async Task UploadAsync(IFormFile formFile)
        {
            var directory = _share.GetRootDirectoryClient();
            var file = directory.GetFileClient(formFile.FileName);
            using var readStream = formFile.OpenReadStream();
            await file.CreateAsync(readStream.Length);
            await file.UploadAsync(readStream);
        }

        public async Task<List<string>> FilesAsync()
        {
            var files = new List<string>();
            var directory = _share.GetRootDirectoryClient();
            await foreach (var item in directory.GetFilesAndDirectoriesAsync())
            {
                files.Add(item.Name);
            }
            return files;
        }
    }
}
