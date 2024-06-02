// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.Collections.Generic;
using System.Drawing;
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
                if (productDto.Color != null && productDto.Color.Any())
                {

                    var productColorRelations = new List<ProductColorRelation>();
                    foreach (var color in productDto.Color)
                    {
                        var productColorRelation = new ProductColorRelation { ProductId = product.Id, ColorId = color.Id };
                        productColorRelations.Add(productColorRelation);
                    }
                    await _unitOfWork.BeginTransactionAsync();
                    await _unitOfWork.RepoProductColorRelation.Add(productColorRelations);
                    await _unitOfWork.CommitTransactionAsync();
                    await _unitOfWork.SaveAsync();
                }

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
                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
                foreach (var product in productDtos)
                {
                    var colors = (await _unitOfWork.RepoProduct.GetColorsOfAProduct(product.Id)).ToList();
                    product.Color = _mapper.Map<List<ProductColorDto>>(colors);
                }
                return productDtos;
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

                var colors = (await _unitOfWork.RepoProduct.GetColorsOfAProduct(product.Id)).ToList();
                productDto.Color = _mapper.Map<List<ProductColorDto>>(colors);

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
                var oldProdcut = await Get(productDto.Id);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoProduct.Update(product);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                //var images = await _unitOfWork.RepoProductImage.GetProductImagesByProductId(productDto.Id);

                //foreach (var image in _mapper.Map<IEnumerable<ProductImageDto>>(images))
                //{
                //    if (!productDto.Images.Contains(image)) { 

                        
                //        await _unitOfWork.BeginTransactionAsync();
                //        await _unitOfWork.RepoProductImage.Delete(_mapper.Map <ProductImage> (image));
                //        await _unitOfWork.CommitTransactionAsync();
                //        await _unitOfWork.SaveAsync();
                //    }
                //}
                //foreach(var image in productDto.Images)
                //{
                //    if(image.Id == 0)
                //    {
                //        await _unitOfWork.BeginTransactionAsync();
                //        await _unitOfWork.RepoProductImage.Add(_mapper.Map<ProductImage>(image));
                //        await _unitOfWork.CommitTransactionAsync();
                //        await _unitOfWork.SaveAsync();
                //    }
                //}
                foreach (var color in oldProdcut.Color)
                {
                    if (!productDto.Color.Contains(color))
                    {
                        var colorRelationToDelete = (await _unitOfWork.RepoProductColorRelation.Query(r => r.ProductId == productDto.Id && r.ColorId == color.Id)).FirstOrDefault();
                        await _unitOfWork.BeginTransactionAsync();
                        await _unitOfWork.RepoProductColorRelation.Delete(colorRelationToDelete);
                        await _unitOfWork.CommitTransactionAsync();
                        await _unitOfWork.SaveAsync();
                    }

                }

                var productColorRelations = new List<ProductColorRelation>();
                foreach (var color in productDto.Color)
                {
                    if (!oldProdcut.Color.Contains(color))
                    {
                        var productColorRelation = new ProductColorRelation { ProductId = product.Id, ColorId = color.Id };
                        productColorRelations.Add(productColorRelation);
                    }

                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoProductColorRelation.Add(productColorRelations);
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
                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
                foreach (var product in productDtos)
                {
                    var colors = (await _unitOfWork.RepoProduct.GetColorsOfAProduct(product.Id)).ToList();
                    product.Color = _mapper.Map<List<ProductColorDto>>(colors);
                }
                return productDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<ProductColorDto>> GetALlColors()
        {
            try
            {
                var colors = await _unitOfWork.RepoProductColor.Get();

                return _mapper.Map<IEnumerable<ProductColorDto>>(colors);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
