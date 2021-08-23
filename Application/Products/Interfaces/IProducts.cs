using Application.Products.Dto;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Interfaces
{
   public interface IProducts
    {
        Task<IEnumerable<ProductListDto>> GetListDataTable();
    }
}
