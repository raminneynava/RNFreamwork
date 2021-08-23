using Application.Eshop.Dtos;
using Application.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Interfaces
{
   public interface IDiscountService
    {
        Task AddDiscountAsync(AddDiscountDto discount);
        Task<List<ProductSelectListDto>> GetProductsAsync(string searchKey);
        Task<List<ProductSelectListDto>> GetCategorysAsync(string searchKey);
        Task DeleteAsync(int id);
    }
}
