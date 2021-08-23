using Application.Blog.Dtos;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class BlogCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BlogCategory> _repository;

        public BlogCategoryController(IRepository<BlogCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult List() => View();
        public IActionResult Add() => View();


        public async Task<IActionResult> GetList(int? id)
            => Ok(await _repository.TableNoTracking.OrderByDescending(x => x.Id)
                .Select(x => new BlogCategoryListDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Status = x.IsActive ? "فعال" : "غیر فعال",
                    Posts = x.Posts.Count().ToString()
                }).ToListAsync());
        [HttpPost]
        public async Task<IActionResult> Insert(BlogCategoryDto brand)
        {
            await _repository.AddAsync(_mapper.Map<BlogCategoryDto, BlogCategory>(brand));
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Edit(int id) =>View(_mapper.Map<BlogCategory, BlogCategoryDto>
            (await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id)));
        
        [HttpPost]
        public async Task<IActionResult> Update(BlogCategoryDto model)
        {
            await _repository.UpdateAsync(_mapper.Map<BlogCategoryDto, BlogCategory>(model));
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
            return Ok(true);
        }
    }
}
