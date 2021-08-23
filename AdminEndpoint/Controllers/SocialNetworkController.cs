using Application.Communication.Dtos;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities.Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class SocialNetworkController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SocialNetwork> _repository;
        public SocialNetworkController(IMapper mapper, IRepository<SocialNetwork> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IActionResult List() => View();

        public async Task<IActionResult> GetList(int? id) =>
            Ok(await _repository.TableNoTracking.OrderByDescending(x => x.Id)
                .Select(x => new SocialNetworkListDto
                {
                    Id = x.Id,
                    SocialProfile = x.SocialProfile,
                    Status = x.IsActive ? "فعال" : "غیر فعال",
                    Order = x.Order.ToString(),
                    SocialType = x.SocialType.ToString()
                }).ToListAsync());
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Insert(SocialNetworkDto social)
        {
            await _repository.AddAsync(_mapper.Map<SocialNetworkDto, SocialNetwork>(social));
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Edit(int id) =>
            View(_mapper.Map<SocialNetwork, SocialNetworkDto>
                (await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id)));
        [HttpPost]
        public async Task<IActionResult> Update(SocialNetworkDto social)
        {
            await _repository.UpdateAsync(_mapper.Map<SocialNetworkDto, SocialNetwork>(social));
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
            return Ok(true);
        }
    }
}
