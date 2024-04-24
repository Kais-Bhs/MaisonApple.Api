// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using AutoMapper;
using BL.Interfaces;
using DAL;
using DTO;
using Entities;

namespace BL.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Add(ProductDto productDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var product = _mapper.Map<Product>(productDto);
                await _unitOfWork.RepoProduct.Add(product);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return product.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var product = await _unitOfWork.RepoProduct.Get(id);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoProduct.Delete(product);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            try
            {
                var products = await _unitOfWork.RepoProduct.Get();
                return _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ProductDto> Get(int id)
        {
            try
            {
                var product = await _unitOfWork.RepoProduct.Get(id);
                var productDto = _mapper.Map<ProductDto>(product);
                return productDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ProductDto> Update(ProductDto productDto)
        {
            try
            {
                var product = new Product();
                _mapper.Map(productDto, product);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoProduct.Update(product);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryId(int categoryId)
        {
            try
            {
                var products = await _unitOfWork.RepoProduct.GetProductsByCategoryId(categoryId);

                return _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
