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
        private RepositoryContext _repoContext;
        private IFarmRepository _farm;
        private IFarmTypeRepository _farmCategory;
        private IAddressRepository _address;
        private IScheduleRepository _schedule;

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

        public IFarmTypeRepository FarmCategory
        {
            get
            {
                if (_farmCategory == null)
                    _farmCategory = new FarmTypeRepository(_repoContext);
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
