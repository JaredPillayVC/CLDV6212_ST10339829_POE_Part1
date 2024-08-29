using Microsoft.Azure.Cosmos.Table;

namespace CLDV6212_ST10339829_POE.Models
{
    public class Customer : TableEntity
    {
        public string CID { get; set; }
        public Customer()
        {
            PartitionKey = "Customer";
            RowKey = CID ?? Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
