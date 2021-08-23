using Application.Products.Dto;
using Application.Products.Interfaces;
using Infrastructure.Entities.Eshop;
using Infrastructure.Context;
using Infrastructure.Repositorie;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Services
{
    public class ProductsService : Repository<Product>, IProducts
    {
        public ProductsService(DataContext dbContext) : base(dbContext)
        { 
        }
        public async Task<IEnumerable<ProductListDto>> GetListDataTable()
        {
            try
            {
                var list =(await base.TableNoTracking.Include(x=>x.Category).Include(x => x.Discount).OrderByDescending(x => x.Id).ToListAsync())
                .Select(x => new ProductListDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryTitle = x.Category.Title,
                    Status = x.IsActive ? "فعال" : "غیر فعال",
                }).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
