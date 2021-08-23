using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities.Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<NewsLetter> _repository;

        public NewsLetterController(IRepository<NewsLetter> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult List()=>View();

        public async Task<IActionResult> GetList()=> 
            Ok(await _repository.TableNoTracking.OrderByDescending(x => x.Id)
                .Select(x => new { x.Contact }).ToListAsync());


    }
}
