using Application.Products.Dto;
using Application.Products.Interfaces;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities.Eshop;
using Infrastructure.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProducts _service;
        private readonly IProductCategory _serviceCategory;
        private readonly IRepository<Product> _repository;

        public ProductsController(IMapper mapper,
                                  IProducts service,
                                  IRepository<Product> repository,
                                  IProductCategory serviceCategory)
        {
            _mapper = mapper;
            _service = service;
            _repository = repository;
            _serviceCategory = serviceCategory;
        }
        public IActionResult List() => View();

        public async Task<IActionResult> GetList() => Ok(await _service.GetListDataTable());

        public async Task<IActionResult> Add()
        {
            ViewBag.CategoryList = (await _serviceCategory.GetCategoryDropDown())
                .Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ProductDto product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var map = _mapper.Map<ProductDto, Product>(product);
                    await _repository.AddAsync(map);
                    return RedirectToAction("List");
                }
                return RedirectToAction("List");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var map = _mapper.Map<Product, ProductDto>(await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
            ViewBag.CategoryList = (await _serviceCategory.GetCategoryDropDown()).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value.ToString(),
                Selected = x.Value.ToString() == map.ParentCategoryId.ToString()
            });
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto model)
        {
            await _repository.UpdateAsync(_mapper.Map<ProductDto, Product>(model));
            return RedirectToAction($"List");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
            return Ok(true);
        }
    }
}
