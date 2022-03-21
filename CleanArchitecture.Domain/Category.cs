using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Category : BaseDomainModel
    {        
        public string Description { get; set; } = string.Empty;
    }
}