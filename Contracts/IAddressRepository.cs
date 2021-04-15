using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {

        Task<Address> GetByFarmId(Guid id);
    }
}
