using Application.Eshop.Dtos;
using Application.Eshop.Interfaces;
using Application.Products.Dto;
using AutoMapper;
using Infrastructure.Context;
using Infrastructure.Contracts;
using Infrastructure.Entities;
using Infrastructure.Entities.Eshop;
using Infrastructure.Repositorie;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services
{

    public class DiscountService : Repository<Discount>, IDiscountService
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Product> _Product;
        private readonly IRepository<ProductCategory> _Category;

        public DiscountService(DataContext dbContext, IMapper mapper, IRepository<Product> product, IRepository<ProductCategory> category) : base(dbContext)
        {
            _mapper = mapper;
            _Product = product;
            _Category = category;
        }
        public async Task AddDiscountAsync(AddDiscountDto discount)
        {
            var newDiscount = _mapper.Map<Discount>(discount);

            switch (discount.DiscountTypeId)
            {
                case 1://select product
                    if (discount.AppliedProducts != null)
                    {
                        var products1 = await _Product.Entities.Where(x => discount.AppliedProducts.Contains(x.Id)).ToListAsync();
                        newDiscount.Product = products1;
                    }
                    break;
                case 2://all product
                    var products2 = await _Product.Entities.ToListAsync();
                    newDiscount.Product = products2;
                    break;
                case 3:
                    if (discount.AppliedCategorys != null)
                    {
                        var products3 = await _Product.Entities.Where(x=> discount.AppliedCategorys.Contains(x.ParentCategoryId)).ToListAsync();
                        newDiscount.Product = products3;
                    }
                    break;
                case 4:

                    break;
                case 5:

                    break;
                default:
                    newDiscount.Product = null;
                    break;
            }
            await AddAsync(newDiscount);
        }

        public async Task DeleteAsync(int id)
        {
            var query = await base.GetByIdAsync(id);
            await base.DeleteAsync(query);
        }
        public async Task<List<ProductSelectListDto>> GetProductsAsync(string searchKey)
        {
            if (!String.IsNullOrEmpty(searchKey))
            {
                var data =
                    await _Product.TableNoTracking
                    .Where(x => x.Title.Contains(searchKey))
                    .Select(x => new ProductSelectListDto
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToListAsync();
                return data;
            }
            else
            {
                var data =
                    await _Product.TableNoTracking
                    .OrderByDescending(x=>x.Id)
                    .Take(10)
                    .Select(x => new ProductSelectListDto
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToListAsync();
                return data;
            }

        }
        public async Task<List<ProductSelectListDto>> GetCategorysAsync(string searchKey)
        {
            if (!String.IsNullOrEmpty(searchKey))
            {
                var data =
                    await _Category.TableNoTracking
                    .Where(x => x.Title.Contains(searchKey))
                    .Select(x => new ProductSelectListDto
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToListAsync();
                return data;
            }
            else
            {
                var data =
                    await _Category.TableNoTracking
                    .OrderByDescending(x => x.Id)
                    .Take(10)
                    .Select(x => new ProductSelectListDto
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToListAsync();
                return data;
            }

        }
    }
}
