using Application.Products.Dto;
using Application.Products.Interfaces;
using AutoMapper;
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Repositorie;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Services
{
   public class ProductCategoryService: Repository<ProductCategory>,IProductCategory
    {
        private readonly IMapper _mapper;
        public ProductCategoryService(DataContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<SelectListDto>> GetCategoryDropDown()
        {
            try
            {
                var list = await base.TableNoTracking.Where(x => x.Level == 2).Include(p => p.ParentCategory).ThenInclude(q => q.ParentCategory).Select(x => new SelectListDto
                {
                    Value = x.Id,
                    Text = $"{x.ParentCategory.ParentCategory.Title} - {x.ParentCategory.Title} - {x.Title}"
                }).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<int>> GetCategoryWithParent(int id)
        {
            var listcat = new List<int>();
            var Getcat = await base.TableNoTracking.Where(x => x.Id == id).Include(x=>x.ParentCategory).ThenInclude(x => x.ParentCategory).FirstOrDefaultAsync();
            if (Getcat != null)
            {
                listcat.Add(Getcat.Id);
                listcat.Add(Getcat.ParentCategory.Id);
                listcat.Add(Getcat.ParentCategory.ParentCategory.Id);
            }
            return listcat;
        }

        public async Task<IEnumerable<ProductCategoryListDto>> GetListDataTable(int? id)
        {
            try
            {
                var list = await base.TableNoTracking.Where(x => x.ParentCategoryId == id).OrderByDescending(x => x.Id).Select(x => new ProductCategoryListDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ParentTitle = x.ParentCategory.Title,
                    Status=x.IsActive?"فعال": "غیر فعال",
                    Level=x.Level
                    
                }).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MenuItemDto> GetMenuAsync()
        {
            var productcat = base.TableNoTracking.Where(x=>x.IsActive)
                .Select(x=>new MenuItemDto
                {
                    Id=x.Id,
                    Title=x.Title,
                    ParentCategoryId=x.ParentCategoryId
                }
            ).ToList();
            var data = _mapper.Map<List<MenuItemDto>>(productcat);
            return data;
        }
    }
}
