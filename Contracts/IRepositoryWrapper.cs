using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IFarmRepository Farm { get; }
        IFarmCategoryRepository FarmCategory { get; }
        IAddressRepository Address { get; }
        IScheduleRepository Schedule { get; }
        IIsARepository IsA { get; }

        Task SaveAsync();
    }
}
