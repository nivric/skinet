﻿using Core.Entities;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class ProductWithProductBrandAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithProductBrandAndTypeSpecification(string sort, int? brandId, int? typeId) :
            base(x =>

              (!brandId.HasValue || x.ProductBrandId == brandId) && (!typeId.HasValue || x.ProductTypeId == typeId)
            )
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);

            switch (sort)
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

        }
        public ProductWithProductBrandAndTypeSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}
