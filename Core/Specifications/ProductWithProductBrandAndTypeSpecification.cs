using Core.Entities;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class ProductWithProductBrandAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithProductBrandAndTypeSpecification(ProductSpecParams productSpecParams) :
            base(x =>
               (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
            && (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
            && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
            )
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);

            switch (productSpecParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderDescBy(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;

            }

            ApplyPaging(productSpecParams.PageSize, productSpecParams.PageSize * (productSpecParams.PageIndex - 1));
            
        }
        public ProductWithProductBrandAndTypeSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}
