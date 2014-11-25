//*************************************
// All rights reserved
// filename:CommodityDeleteCommandHandler
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:57:29
// version 1.0
//*************************************

using AccountBook.Events.Commodity;
using Apworks.Application;
using Apworks.Commands;
using Apworks.Events;
using Apworks.Repositories;
using Apworks.Repositories.NHibernate;

namespace AccountBook.EventHandlers.Commodity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AccountBook.Model;

    public class CommodityDeleteEventHandler : IEventHandler<CommodityDeletedEvent>
    {
        private IRepository<Commodity> _commodityRepository;
        public CommodityDeleteEventHandler()
        {
            _commodityRepository = AppRuntime.Instance.CurrentApplication.ObjectContainer.GetService<IRepository<AccountBook.Model.Commodity>>();
        }

        public void Handle(CommodityDeletedEvent message)
        {
            var commodity = _commodityRepository.GetByKey(message.Id);
            _commodityRepository.Remove(commodity);
            _commodityRepository.Context.Commit();
        }
    }
}
