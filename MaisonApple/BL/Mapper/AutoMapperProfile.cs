// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using AutoMapper;
using DTO;
using Entities;

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

            CreateMap<ProductColorDto, ProductColor>();
            CreateMap<ProductColor, ProductColorDto>();

            CreateMap<RegisterUserDto, User>();
            CreateMap<User, RegisterUserDto>();

            CreateMap<CommandDto, Command>().ForMember(dest => dest.Orders, opt => opt.Ignore());
            CreateMap<Command, CommandDto>().ForMember(dest => dest.Orders, opt => opt.Ignore());

            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();

            CreateMap<NotificationDto, Notification>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}