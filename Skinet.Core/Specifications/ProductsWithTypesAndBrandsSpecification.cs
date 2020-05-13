using System;
using System.Collections.Generic;
using System.Text;
using Skinet.Core.Entities;

namespace Skinet.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification: BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
        public ProductsWithTypesAndBrandsSpecification(ProductSpecificationParams productParameters) 
            : base (x => 
                (string.IsNullOrEmpty(productParameters.Search) || x.Name.ToLower().Contains(productParameters.Search)) &&
                (!productParameters.BrandId.HasValue || x.ProductBrandId == productParameters.BrandId) &&
                (!productParameters.TypeId.HasValue || x.ProductTypeId == productParameters.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParameters.PageSize * (productParameters.PageIndex -1), productParameters.PageSize);

            if (string.IsNullOrEmpty(productParameters.Sort)) return;

            switch (productParameters.Sort)
            {
                case "priceAsc":
                    AddOrderBy(o => o.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(o => o.Price);
                    break;
                default:
                    AddOrderBy(o => o.Name);
                    break;
            }
        }
    }
}
