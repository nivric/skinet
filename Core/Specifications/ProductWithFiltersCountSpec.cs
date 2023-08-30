using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersCountSpec :BaseSpecification<Product>
    {
        public ProductWithFiltersCountSpec(ProductSpecParams productSpecParams) :
            base(x =>
               (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) 
            && (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
            && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
            )
        {
            
        }
    }
}
