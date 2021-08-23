using Application.Products.Dto;
using Application.Products.Interfaces;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Setting;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class ProductCatController : Controller
    {
        private readonly IProductCategory _service;
        private readonly IRepository<ProductCategory> _repository;
        private readonly IMapper _mapper;

        public ProductCatController(
            IProductCategory service,
            IMapper mapper,
            IRepository<ProductCategory> repository)
        {
            _service = service;
            _mapper = mapper;
            _repository = repository;
        }

        public IActionResult List(int? id)
        {
            ViewBag.CatId = id;
            ViewBag.Level = 0;
            ViewBag.ParentId = null;
            var query = _repository.TableNoTracking.FirstOrDefault(x => x.ParentCategoryId == id);
            if (query != null)
            {
                ViewBag.ParentId = query.ParentCategoryId;
                if (query.Level > SiteSetting.CategoryLevel)
                    ViewBag.Level = 1;
            }
            return View();
        }

        public async Task<IActionResult> GetList(int? id)=>
            Ok(await _service.GetListDataTable(id));


        public IActionResult Add(int? id)
        {
            ViewBag.CatId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ProductCategoryDto model)
        {
            var map = _mapper.Map<ProductCategoryDto, ProductCategory>(model);
            if (model.ParentCategoryId != null)
            {
                var query = await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == model.ParentCategoryId);
                if (query.Level <= SiteSetting.CategoryLevel)
                    map.Level = query.Level + 1;
            }
            await _repository.AddAsync(map);
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int id) => 
            View(_mapper.Map<ProductCategory, ProductCategoryDto>
                (await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id)));

        [HttpPost]
        public async Task<IActionResult> Update(ProductCategoryDto model)
        {
            await _repository.UpdateAsync(_mapper.Map<ProductCategoryDto, ProductCategory>(model));
            return RedirectToAction("List");
        }
    }
}
