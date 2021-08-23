using Application.Base.Dtos;
using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class SiteInfoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SiteInfo> _repository;

        public SiteInfoController(IRepository<SiteInfo> repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult HomePageInfo() =>
            View(_mapper.Map<SiteInfoDto>((_repository.TableNoTracking.ToList()).FirstOrDefault()));

        public async Task<IActionResult> UpdateHomeInfo(SiteInfoDto siteInfo)
        {
            await  _repository.UpdateAsync(_mapper.Map<SiteInfo>(siteInfo));
           return RedirectToAction("HomePageInfo","SiteInfo");
        }
    }
}
