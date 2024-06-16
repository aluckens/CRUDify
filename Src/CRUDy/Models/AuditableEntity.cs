using System.ComponentModel.DataAnnotations;

namespace CRUDy.Models
{
    public class AuditableEntity<TEntityId>  
    {
        [Key]
        public TEntityId Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
