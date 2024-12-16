using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class BatchNo
    {
        public int BatchNoId { get; set; }
        public string BatchNumber { get; set; }  // e.g., "BP-2024-1-002" products must have symbols
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedAt { get; set; }  // Timestamp of the batch creation
    }
}
