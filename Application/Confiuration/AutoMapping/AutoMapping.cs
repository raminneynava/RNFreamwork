using Application.Attribute.Dtos;
using Application.Base.Dtos;
using Application.Blog.Dtos;
using Application.Communication.Dtos;
using Application.Content.Dtos;
using Application.Eshop.Dtos;
using Application.Products.Dto;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entities.Attribute;
using Infrastructure.Entities.Communication;
using Infrastructure.Entities.Content;
using Infrastructure.Entities.Eshop;
using Infrastructure.Entities.Products;
using MD.PersianDateTime;
using System;

namespace Application.Confiuration.AutoMapping
{
  public  class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategory, MenuItemDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<BlogCategory, BlogCategoryDto>().ReverseMap();
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<NewsLetter, NewsLetterDto>().ReverseMap();
            CreateMap<SocialNetworkDto, SocialNetwork>().ReverseMap();
            CreateMap<SiteInfoDto, SiteInfo>().ReverseMap();
            CreateMap<PageContentDto, PageContent>().ReverseMap();
            CreateMap<CategoryAttributeSpeciDto, CategoryAttributeSpeci>().ReverseMap();

            CreateMap<SpecificationAttributeDto, SpecificationAttribute>().ReverseMap();

            
            CreateMap<AddDiscountDto, Discount>()
                .ForMember(d => d.StartDate, opt => opt.MapFrom(s => Convert.ToDateTime(s.StartDate)))
                .ForMember(d => d.EndDate, opt => opt.MapFrom(s => Convert.ToDateTime(s.EndDate)));
            CreateMap<Discount, AddDiscountDto>()
                .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.StartDate.ToString()))
                .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.EndDate.ToString()));
        }
    }
}
