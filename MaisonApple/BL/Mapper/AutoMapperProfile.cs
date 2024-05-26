// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace BL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<ProductImageDto, ProductImage>();
            CreateMap<ProductImage, ProductImageDto>();

            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<RegisterUserDto, User>();
            CreateMap<User, RegisterUserDto>();

            CreateMap<PaymentDto, Payment>();
            CreateMap<Payment, PaymentDto>();
        }
    }
}