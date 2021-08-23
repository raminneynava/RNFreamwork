using Application.Attribute.Dtos;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities.Attribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class CategoryAttributeController : Controller
    {
        private readonly IRepository<CategoryAttributeSpeci> _repository;
        private readonly IRepository<SpecificationAttribute> _attrrepository;
        private readonly IMapper _mapper;

        public CategoryAttributeController(IRepository<CategoryAttributeSpeci> repository, IRepository<SpecificationAttribute> attrrepository, IMapper mapper)
        {
            _repository = repository;
            _attrrepository = attrrepository;
            _mapper = mapper;
        }

        public IActionResult List(int id)
        {
            return View(id);
        }
        public async Task<IActionResult> GetList(int? id)
            => Ok(await _repository.TableNoTracking.Where(x => x.CategoryId == id).Select(x => new
            {
                id=x.Id,
                name=x.Attributes.Name,
                fieldType = x.IsSelectList ? "چند انتخابی" : "متنی",
                isFilter = x.isFilter ? "بله" : "خیر",
                isselect=x.IsSelectList
            }).ToListAsync());

        public IActionResult Add(int id)
        {
            ViewBag.attrlist = _attrrepository.TableNoTracking.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.catid = id;
            return View();
        }

        public async Task<IActionResult> Insert(CategoryAttributeSpeciDto model)
        {
         var mp = _mapper.Map<CategoryAttributeSpeci>(model);
         await _repository.AddAsync(mp);
         return RedirectToAction("List",new {id=model.CategoryId});
        }


    }
}
