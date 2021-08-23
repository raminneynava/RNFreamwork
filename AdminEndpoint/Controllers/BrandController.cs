using Application.Products.Dto;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class BrandController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Brand> _repository;
        public BrandController(IMapper mapper, IRepository<Brand> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IActionResult List() => View();
        public IActionResult Add() => View();
        public async Task<IActionResult> GetList() =>
                Ok(await _repository.TableNoTracking.OrderByDescending(x => x.Id).Select(x => new BrandListDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Status = x.IsActive ? "فعال" : "غیر فعال",
                }).ToListAsync());
        [HttpPost]
        public async Task<IActionResult> Insert(BrandDto brand)
        {
            await _repository.AddAsync(_mapper.Map<BrandDto, Brand>(brand));
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int id)=> View(_mapper.Map<Brand, BrandDto>
            (await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id)));

        [HttpPost]
        public async Task<IActionResult> Update(BrandDto model)
        {
            await _repository.UpdateAsync(_mapper.Map<BrandDto, Brand>(model));
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
            return Ok(true);
        }
    }
}
