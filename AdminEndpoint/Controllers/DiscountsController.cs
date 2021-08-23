using Application.Eshop.Dtos;
using Application.Eshop.Interfaces;
using Infrastructure.Contracts;
using Infrastructure.Entities.Eshop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class DiscountsController : Controller
    {
        private readonly IDiscountService _service;
        private readonly IRepository<Discount> _repository;
        public DiscountsController(IDiscountService service, IRepository<Discount> repository)
        {
            _service = service;
            _repository = repository;
        }
        public IActionResult List() => View();
        public IActionResult Add() => View();

        [Route("api/Getproduct")]
        [HttpGet]
        public async Task<IActionResult> GetProducts(string term) =>
             Ok(await _service.GetProductsAsync(term));

        [Route("api/GetCategory")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(string term) =>
            Ok(await _service.GetCategorysAsync(term));

        public async Task<IActionResult> GetList(int? id) =>
             Ok(await _repository.TableNoTracking.OrderByDescending(x => x.Id).Select(x => new
             {
                 x.Id,
                 x.Title,
                 StartDate = x.StartDate.ToString("yyyy/MM/dd"),
                 EndDate = x.EndDate.ToString("yyyy/MM/dd"),
                 DiscountType = x.DiscountType.ToString()
             }).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Insert(AddDiscountDto model)
        {
            await _service.AddDiscountAsync(model);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("List");
        }
    }
}
