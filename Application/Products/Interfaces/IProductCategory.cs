using Application.Products.Dto;
using Infrastructure.Entities;
using SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Interfaces
{
   public interface IProductCategory
    {
        Task<IEnumerable<ProductCategoryListDto>> GetListDataTable(int? id);
        Task<IEnumerable<SelectListDto>> GetCategoryDropDown();
        Task<IEnumerable<int>> GetCategoryWithParent(int id);
        List<MenuItemDto> GetMenuAsync();
    }
}
