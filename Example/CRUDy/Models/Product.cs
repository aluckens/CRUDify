using CRUDy.Models;

namespace CRUDyExample.Models
{
    public class Product  : AuditableEntity<long>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public string SKU { get; set; }
    }
}
