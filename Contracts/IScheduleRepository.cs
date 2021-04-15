using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IScheduleRepository : IRepositoryBase<Schedule>
    {
        IEnumerable<Schedule> GetByFarmId(Guid id);
    }
}
