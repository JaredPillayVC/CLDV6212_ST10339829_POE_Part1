using Microsoft.Azure.Cosmos.Table;
using System;
using System.ComponentModel.DataAnnotations;

namespace CLDV6212_ST10339829_POE.Models
{
    public class Customer : TableEntity
    {
        [Required]
        public int? CID { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Customer()
        {
            PartitionKey = "Customer"; // Ensure non-null, valid PartitionKey
        }

        public void SetRowKey()
        {
            if (!CID.HasValue)
            {
                // Generate a new unique RowKey if CID is null
                RowKey = Guid.NewGuid().ToString();
            }
            else
            {
                // Ensure CID is non-null and use it as RowKey
                RowKey = CID.ToString();
            }
        }
    }
}
