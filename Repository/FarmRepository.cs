using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class FarmRepository : RepositoryBase<Farm>, IFarmRepository
    {

        public FarmRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<Farm>> GetAllFarmsAsync() => await FindAll().OrderBy(f => f.FarmName).ToListAsync();

        public async Task<Farm> GetDetailedFarmAsync(Guid id) => await FindByCondition(farm => farm.FarmId.Equals(id)).FirstOrDefaultAsync();

        public async Task<Farm> GetFarmByIdAsync(Guid id) => await FindByCondition(farm => farm.FarmId.Equals(id)).FirstOrDefaultAsync();

        public void CreateFarm(Farm farm)
        {
            Create(farm);
        }

        public void DeleteFarm(Farm farm)
        {
            Delete(farm);
        }

        public void UpdateFarm(Farm farm)
        {
            Update(farm);
        }
    }
}
