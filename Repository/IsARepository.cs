using Entities;
using Entities.Models;
using Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class IsARepository : RepositoryBase<IsA>, IIsARepository
    {
        public IsARepository(RepositoryContext context) : base(context) { }

        public void DeleteIsA(IsA entity)
        {
            Delete(entity);
        }

        public IEnumerable<IsA> GetByFarmId(Guid id)
        {
            return FindAll().Where(isA => isA.FarmId.Equals(id)).ToList();
        }
    }
}
