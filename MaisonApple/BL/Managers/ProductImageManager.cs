// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Interfaces;
using DAL;
using DTO;
using Entities;

namespace BL.Managers
{
    public class ProductImageManager : IProductImageManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductImageManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Add(ProductImageDto ProductImageDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var ProductImage = _mapper.Map<ProductImage>(ProductImageDto);
                await _unitOfWork.RepoProductImage.Add(ProductImage);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return ProductImage.Id;
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
                var ProductImage = await _unitOfWork.RepoProductImage.Get(id);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoProductImage.Delete(ProductImage);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ProductImageDto>> Get()
        {
            try
            {
                var ProductImages = await _unitOfWork.RepoProductImage.Get();
                return _mapper.Map<IEnumerable<ProductImageDto>>(ProductImages);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ProductImageDto> Get(int id)
        {
            try
            {
                var ProductImage = await _unitOfWork.RepoProductImage.Get(id);
                var ProductImageDto = _mapper.Map<ProductImageDto>(ProductImage);
                return ProductImageDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ProductImageDto> Update(ProductImageDto ProductImageDto)
        {
            try
            {
                var ProductImage = new ProductImage();
                _mapper.Map(ProductImageDto, ProductImage);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoProductImage.Update(ProductImage);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return _mapper.Map<ProductImageDto>(ProductImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
