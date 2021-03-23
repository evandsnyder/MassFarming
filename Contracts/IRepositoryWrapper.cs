using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IFarmRepository Farm { get; }
        IFarmTypeRepository FarmCategory { get; }
        IAddressRepository Address { get; }
        IScheduleRepository Schedule { get; }
    }
}
