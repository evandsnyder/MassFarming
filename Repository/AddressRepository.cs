using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<Address> GetByFarmId(Guid id)
        {
            return await FindByCondition(address => address.FarmId.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
