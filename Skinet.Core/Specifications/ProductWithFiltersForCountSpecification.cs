using System;
using System.Collections.Generic;
using System.Text;
using Skinet.Core.Entities;

namespace Skinet.Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationParams productParameters)
            : base(x =>
                (string.IsNullOrEmpty(productParameters.Search) || x.Name.ToLower().Contains(productParameters.Search)) &&
                (!productParameters.BrandId.HasValue || x.ProductBrandId == productParameters.BrandId) &&
                (!productParameters.TypeId.HasValue || x.ProductTypeId == productParameters.TypeId)
            )
        {
            
        }
    }
}
