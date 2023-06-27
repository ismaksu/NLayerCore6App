using AutoMapper;
using Microsoft.AspNetCore.Http;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductServiceWithDto : ServiceWithDto<Product, ProductDto>, IProductServiceWithDto
    {
        private readonly IProductRepository _repository;
        public ProductServiceWithDto(IUnitOfWork uow, IMapper mapper, IProductRepository repository) : base(repository, uow, mapper)
        {
            _repository = repository;
        }

        public async Task<CustomResponseDto<ProductDto>> AddAsync(ProductCreateDto productCreateDto)
        {
            var newEntity = _mapper.Map<Product>(productCreateDto);
            await _repository.AddAsync(newEntity);
            await _uow.CommitAsync();
            var newDto = _mapper.Map<ProductDto>(newEntity);
            return CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _repository.GetProductsWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            _repository.Update(product);
            await _uow.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
