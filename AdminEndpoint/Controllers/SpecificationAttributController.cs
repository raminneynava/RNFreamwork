using Application.Attribute.Dtos;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities.Attribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class SpecificationAttributController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IRepository<SpecificationAttribute> _repository;
        public SpecificationAttributController(IMapper mapper, IRepository<SpecificationAttribute> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        #region SpecificationAttribut
        public IActionResult List()
        {
            return View();
        }
        public async Task<IActionResult> GetList(int id) =>
            Ok(await _repository.TableNoTracking.OrderByDescending(x => x.Id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                order = x.DisplayOrder
            }).ToListAsync());
        public IActionResult Add()=>View();
        public async Task<IActionResult> Insert(SpecificationAttributeDto model)
        {
            await _repository.AddAsync(_mapper.Map<SpecificationAttributeDto, SpecificationAttribute>(model));
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Edit(int id) =>
         View(_mapper.Map<SpecificationAttribute, SpecificationAttributeDto>
        (await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id)));
        #endregion
    }
}
