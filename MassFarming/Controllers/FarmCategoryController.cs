using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassFarming.Controllers
{
    [Route("api/type")]
    public class FarmCategoryController : Controller
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public FarmCategoryController(IRepositoryWrapper repo, IMapper map)
        {
            repository = repo;
            mapper = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await repository.FarmCategory.GetAllFarmTypesAsync();
            return Ok(categories);
        }
    }
}
