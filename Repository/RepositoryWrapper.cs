using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IFarmRepository _farm;
        private IFarmCategoryRepository _farmCategory;
        private IAddressRepository _address;
        private IScheduleRepository _schedule;
        private IIsARepository _isA;

        public IFarmRepository Farm
        {
            get
            {
                if(_farm == null)
                {
                    _farm = new FarmRepository(_repoContext);
                }
                return _farm;
            }
        }

        public IFarmCategoryRepository FarmCategory
        {
            get
            {
                if (_farmCategory == null)
                    _farmCategory = new FarmCategoryRepository(_repoContext);
                return _farmCategory;
            }
        }


        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                    _address = new AddressRepository(_repoContext);
                return _address;
            }
        }


        public IScheduleRepository Schedule
        {
            get
            {
                if (_schedule == null)
                    _schedule = new ScheduleRepository(_repoContext);
                return _schedule;
            }
        }

        public IIsARepository IsA
        {
            get
            {
                if(_isA == null)
                {
                    _isA = new IsARepository(_repoContext);
                }
                return _isA;
            }
        }

        public RepositoryWrapper(RepositoryContext context)
        {
            _repoContext = context;
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }

    }
}
