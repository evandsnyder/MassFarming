using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class FarmRepository : RepositoryBase<Farm>, IFarmRepository
    {

        public FarmRepository(RepositoryContext context) : base(context) { }
    }
}
