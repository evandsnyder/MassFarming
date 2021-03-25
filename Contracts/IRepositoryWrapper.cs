using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IFarmRepository Farm { get; }
        IFarmTypeRepository FarmCategory { get; }
        IAddressRepository Address { get; }
        IScheduleRepository Schedule { get; }

        Task SaveAsync();
    }
}
