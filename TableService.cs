using CLDV6212_ST10339829_POE.Models;
using Microsoft.Azure.Cosmos.Table;

namespace CLDV6212_ST10339829_POE
{
    public class TableService
    {
        private readonly CloudTableClient _cloudTableClient;
        private readonly CloudTable _customerCloudTable;
        private readonly CloudTable _productCloudTable;

        public TableService(string connectionString)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            _cloudTableClient = cloudStorageAccount.CreateCloudTableClient(new TableClientConfiguration());
            _customerCloudTable = _cloudTableClient.GetTableReference("Customers");
            _productCloudTable = _cloudTableClient.GetTableReference("Products");

            _customerCloudTable.CreateIfNotExists();
            _productCloudTable.CreateIfNotExists();
        }

        public async Task AddCustomerTableAsync(Customer customer) 
        { 
            var insertCustomer = TableOperation.Insert(customer);
            await _customerCloudTable.ExecuteAsync(insertCustomer);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        { 
            var query = new TableQuery<Customer>();
            var customers = await _customerCloudTable.ExecuteQuerySegmentedAsync(query, null);
            return customers.Results;
        }

        public async Task AddProductTableAsync(Product product)
        {
            var insertProduct = TableOperation.Insert(product);
            await _productCloudTable.ExecuteAsync(insertProduct);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var query = new TableQuery<Product>();
            var products = await _productCloudTable.ExecuteQuerySegmentedAsync(query, null);
            return products.Results;
        }
    }
}
