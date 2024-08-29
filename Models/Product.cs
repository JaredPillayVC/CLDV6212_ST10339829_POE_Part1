using Microsoft.Azure.Cosmos.Table;

namespace CLDV6212_ST10339829_POE.Models
{
    public class Product : TableEntity
    {
        public string PID { get; set; }
        public Product() 
        {
            PartitionKey = "Product";
            RowKey = PID ?? Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
