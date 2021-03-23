using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class FarmTypeRepository : RepositoryBase<FarmType>, IFarmTypeRepository
    {
        public FarmTypeRepository(RepositoryContext context) : base(context) { }
    }
}
