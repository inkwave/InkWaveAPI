using Inkwave.Domain.Common;

namespace Inkwave.Domain.Entities
{
    public class Category : BaseAuditableEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
        public string CategoryImage { get; set; } = string.Empty;
 
    }
}

