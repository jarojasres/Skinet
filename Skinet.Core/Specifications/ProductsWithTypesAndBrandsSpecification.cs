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
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
