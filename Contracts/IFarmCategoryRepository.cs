using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFarmCategoryRepository : IRepositoryBase<FarmCategory>
    {
        Task<IEnumerable<FarmCategory>> GetAllFarmTypesAsync();
    }
}
