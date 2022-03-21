using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Product : BaseDomainModel
    {
        public string Name { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
