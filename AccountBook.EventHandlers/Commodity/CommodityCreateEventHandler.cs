//*************************************
// All rights reserved
// filename:CommdityCommandHandlers
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:44:05
// version 1.0
//*************************************

using AccountBook.Events.Account;
using AccountBook.Events.Commodity;
using Apworks.Application;
using Apworks.Commands;
using Apworks.Events;
using Apworks.Repositories;
using Apworks.Repositories.NHibernate;

namespace AccountBook.EventHandlers.Commodity
{
    using AccountBook.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityCreateEventHandler : IEventHandler<CommodityCreatedEvent>
    {
        private IRepository<Commodity> _commodityRepository;
        public CommodityCreateEventHandler()
        {
            _commodityRepository = AppRuntime.Instance.CurrentApplication.ObjectContainer.GetService<IRepository<AccountBook.Model.Commodity>>();
        }

        public void Handle(CommodityCreatedEvent message)
        {
            _commodityRepository.Add(new Commodity
            {
                Id = message.Id,
                Name = message.Name,
                Describe = message.Describe,
                RecordTime = message.RecordTime,
                Creater = message.Creater,
                Price = message.Price
            });
            _commodityRepository.Context.Commit();
        }
    }
}
