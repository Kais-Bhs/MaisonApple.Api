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
using iTextSharp.text;
using Microsoft.AspNetCore.Identity;

namespace BL.Managers
{
    public class FavorisManager : IFavorisManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userStore;
        private readonly IMailService _mailService;
        public FavorisManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userStore = userManager;
            _mailService = mailService;
        }

        public async Task AddToFavorite(string userId, int productId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var favoris = new Favoris { ProductId = productId ,UserId = userId};
                await _unitOfWork.RepoFavoris.Add(favoris);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<List<ProductDto>> GetFavoriteByUser(string userId)
        {
            try
            {
                var products = await _unitOfWork.RepoFavoris.GetFavoriteByUser(userId);
                var productDtos =  _mapper.Map<List<ProductDto>>(products);
                foreach (var product in productDtos)
                {
                    var images = (await _unitOfWork.RepoProductImage.GetProductImagesByProductId(product.Id)).ToList();
                    product.Images = _mapper.Map<List<ProductImageDto>>(images);
                }

                return productDtos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task Delete(string userId , int productId)
        {
            try
            {
                var favorite = (await _unitOfWork.RepoFavoris.Query(f => f.UserId == userId && f.ProductId == productId)).FirstOrDefault();
                if (favorite != null)
                {
                    await _unitOfWork.BeginTransactionAsync();
                    await _unitOfWork.RepoFavoris.Delete(favorite);
                    await _unitOfWork.CommitTransactionAsync();
                    await _unitOfWork.SaveAsync();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
