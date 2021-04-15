using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IIsARepository : IRepositoryBase<IsA>
    {
        void DeleteIsA(IsA entity);
        IEnumerable<IsA> GetByFarmId(Guid id);
    }
}
