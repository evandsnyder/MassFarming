using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IFarmRepository : IRepositoryBase<Farm>
    {
        Task<IEnumerable<Farm>> GetAllFarmsAsync();
        Task<Farm> GetFarmByIdAsync(Guid id);
        Task<Farm> GetDetailedFarmAsync(Guid id);
        void CreateFarm(Farm farm);
        void UpdateFarm(Farm farm);
        void DeleteFarm(Farm farm);
    }
}
