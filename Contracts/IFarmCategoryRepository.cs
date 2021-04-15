using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFarmCategoryRepository : IRepositoryBase<FarmType>
    {
        Task<IEnumerable<FarmType>> GetAllFarmTypesAsync();
    }
}
