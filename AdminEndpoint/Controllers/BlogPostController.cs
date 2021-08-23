using Application.Blog.Dtos;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BlogPost> _repository;
        private readonly IRepository<BlogCategory> _catrepository;
        public BlogPostController(IMapper mapper, IRepository<BlogPost> repository,
            IRepository<BlogCategory> catrepository)
        {
            _mapper = mapper;
            _repository = repository;
            _catrepository = catrepository;
        }

        public IActionResult List() => View();

        public async Task<IActionResult> GetList()
                => Ok(await _repository.TableNoTracking.OrderByDescending(x => x.Id)
                    .Select(x => new BlogPostListDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Status = x.IsActive ? "فعال" : "غیر فعال",
                        Category = x.Category.Title,
                        Rate = "0",
                        AuthorId = x.AuthorId
                    }).ToListAsync());
        public IActionResult Add()
        {
            ViewBag.CategoryList = _catrepository.TableNoTracking.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(BlogPostDto post)
        {
            post.AuthorId = User.Identity.Name;
            await _repository.AddAsync(_mapper.Map<BlogPostDto, BlogPost>(post));
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var map = _mapper.Map<BlogPost, BlogPostDto>
                (await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
            ViewBag.CategoryList = _catrepository.TableNoTracking.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString(),
                Selected = x.Id.ToString() == map.CategoryId.ToString() ? true : false
            });
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BlogPostDto post)
        {
            await _repository.UpdateAsync(_mapper.Map<BlogPostDto, BlogPost>(post));
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
            return Ok(true);
        }
    }
}
