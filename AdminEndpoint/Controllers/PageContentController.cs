using Application.Content.Dtos;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class PageContentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PageContent> _repository;

        public PageContentController(IRepository<PageContent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult List() => View();

        public async Task<IActionResult> GetList(int? id) =>
         Ok(await _repository.TableNoTracking.Select(x => new { x.Id, x.Title }).ToListAsync());

        public async Task<IActionResult> Edit(int id) =>
            View(_mapper.Map<PageContent, PageContentDto>
                (await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id)));

        [HttpPost]
        public async Task<IActionResult> Update(PageContentDto model)
        {
            await _repository.UpdateAsync(_mapper.Map<PageContentDto, PageContent>(model));
            return RedirectToAction("List");
        }
    }
}
