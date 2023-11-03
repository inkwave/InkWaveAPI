using Inkwave.Domain.Common;

namespace Inkwave.Domain.Item
{
    public class ItemCategory : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid ItemId { get; set; }
        public Item? Item { get; set; }

    }
}
