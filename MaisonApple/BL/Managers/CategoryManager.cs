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
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Add(CategoryDto CategoryDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var Category = _mapper.Map<Category>(CategoryDto);
                await _unitOfWork.RepoCategory.Add(Category);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return Category.Id;
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
                var Category = await _unitOfWork.RepoCategory.Get(id);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoCategory.Delete(Category);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<CategoryDto>> Get()
        {
            try
            {
                var Categorys = await _unitOfWork.RepoCategory.Get();
                return _mapper.Map<IEnumerable<CategoryDto>>(Categorys);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<CategoryDto> Get(int id)
        {
            try
            {
                var Category = await _unitOfWork.RepoCategory.Get(id);
                var CategoryDto = _mapper.Map<CategoryDto>(Category);
                return CategoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<CategoryDto> Update(CategoryDto CategoryDto)
        {
            try
            {
                var Category = new Category();
                _mapper.Map(CategoryDto, Category);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.RepoCategory.Update(Category);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveAsync();
                return _mapper.Map<CategoryDto>(Category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
