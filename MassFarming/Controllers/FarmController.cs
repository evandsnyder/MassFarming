using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassFarming.Controllers
{
    [Route("api/farm")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public FarmController(IRepositoryWrapper repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFarms()
        {
            var farms = await _repository.Farm.GetAllFarmsAsync();

            var farmResults = _mapper.Map<IEnumerable<FarmDto>>(farms);
            return Ok(farmResults);
        }

        /// <summary>
        /// Get a specific farm using the associated id
        /// </summary>
        /// <param name="id">Id of the farm to get</param>
        /// <returns>Ok status code if the farm is found</returns>
        [HttpGet("{id}", Name = "FarmById")]
        public async Task<IActionResult> GetFarmById(Guid id)
        {
            var farm = await _repository.Farm.GetDetailedFarmAsync(id);

            return Ok(farm);
        }

        /// <summary>
        /// Takes data from the body of the request and attempts to create a new Farm in the database
        /// </summary>
        /// <param name="farm">The new farm to create</param>
        /// <returns>Bad request if invalid data or redirects to the new farm</returns>
        [HttpPost]
        public async Task<IActionResult> CreateFarm([FromBody] FarmForCreationDto farm)
        {
            if (farm == null)
                return BadRequest("Farm object is null");

            if (!ModelState.IsValid)
                return BadRequest("Farm object is malformed");

            // Time to manually map this now...
            Farm newFarm = new Farm();
            newFarm.FarmId = Guid.NewGuid();
            newFarm.FarmName = farm.FarmName;
            newFarm.OwnerName = farm.OwnerName;
            newFarm.Description = farm.Description;
            newFarm.WebsiteUrl = farm.WebsiteUrl;
            newFarm.ContactEmail = farm.ContactEmail;
            newFarm.IsActive = 1;
            newFarm.DoesDelivery = Convert.ToInt32(farm.DoesDelivery);
            newFarm.IsContactable = Convert.ToInt32(farm.IsContactable);
            newFarm.Schedules = new List<Schedule>();
            newFarm.Categories = new List<IsA>();

            // Schedules
            foreach (SchedulesForCreationDto schedule in farm.Schedules) {
                Schedule sched = new Schedule();
                sched.Id = Guid.NewGuid();
                sched.StartTime = schedule.StartTime;
                sched.EndTime = schedule.EndTime;
                sched.DayOfWeek = schedule.DayOfWeek;
                sched.FarmId = newFarm.FarmId;
                newFarm.Schedules.Add(sched);
            }

            // Categories
            foreach (FarmTypeForCreationDto farmType in farm.categories)
            {
                IsA isA = new IsA();
                isA.Id = Guid.NewGuid();
                isA.FarmId = newFarm.FarmId;
                isA.FarmTypeId = farmType.FarmTypeId;
                newFarm.Categories.Add(isA);
            }

            // Address
            Address address = _mapper.Map<Address>(farm.Address);
            address.FarmId = newFarm.FarmId;
            address.AddressId = Guid.NewGuid();
            newFarm.Address = address;


            _repository.Farm.CreateFarm(newFarm);
            await _repository.SaveAsync();

            var createdFarm = _mapper.Map<FarmDto>(newFarm);

            return CreatedAtRoute("FarmById", new { id = createdFarm.FarmId }, createdFarm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFarm(Guid id, [FromBody]FarmForUpdateDto farm)
        {
            if(farm == null)
            {
                return BadRequest("Farm object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Farm object is invalid");
            }

            // Perhaps cleaning up the relationships will work here..
            await RemoveOldRelationships(id);

            // Time to start mapping...
            var currentFarm = await _repository.Farm.GetDetailedFarmAsync(id);
            if(currentFarm == null)
            {
                return NotFound();
            }
            _mapper.Map(farm, currentFarm);


            _repository.Farm.UpdateFarm(currentFarm);
            await _repository.SaveAsync();
            
            return NoContent();
        }


        private async Task RemoveOldRelationships(Guid id)
        {
            // Get old IsA and remove them...
            foreach(var entity in _repository.IsA.GetByFarmId(id))
            {
                _repository.IsA.Delete(entity);
            }

            foreach(var entity in _repository.Schedule.GetByFarmId(id))
            {
                _repository.Schedule.Delete(entity);
            }

            var addr = await _repository.Address.GetByFarmId(id);
            if (addr != null)
            {
                _repository.Address.Delete(addr);
            }
            

            await _repository.SaveAsync();
        }
    }
}
