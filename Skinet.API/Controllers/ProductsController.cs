using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.API.Dtos;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Core.Specifications;
using Skinet.Infrastructure.Data;

namespace Skinet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productsRepo, 
            IGenericRepository<ProductType> productTypesRepo, 
            IGenericRepository<ProductBrand> productBrandsRepo, 
            IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productTypesRepo = productTypesRepo;
            _productBrandsRepo = productBrandsRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var specification = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsync(specification);
            var result = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var specification = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(specification);
            var result = _mapper.Map<Product, ProductDto>(product);
            return Ok(result);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            var productBrands = await _productBrandsRepo.ListAllAsync();

            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            var productTypes = await _productTypesRepo.ListAllAsync();

            return Ok(productTypes);
        }
    }
}