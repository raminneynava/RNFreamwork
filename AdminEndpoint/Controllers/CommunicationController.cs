using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities.Communication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class CommunicationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<NewsLetter> _nlrepository;

        public CommunicationController(IRepository<NewsLetter> repository, IMapper mapper)
        {
            _nlrepository = repository;
            _mapper = mapper;
        }

        public IActionResult NewsLetter()
        {
            return View();
        }
    }
}
