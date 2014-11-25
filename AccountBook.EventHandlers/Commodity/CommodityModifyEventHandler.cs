//*************************************
// All rights reserved
// filename:CommodityModifyCommandHandler
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:55:38
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

    public class CommodityModifyEventHandler : IEventHandler<CommodityModifiedEvent>
    {
        private IRepository<Commodity> _commodityRepository;
        public CommodityModifyEventHandler()
        {
            _commodityRepository = AppRuntime.Instance.CurrentApplication.ObjectContainer.GetService<IRepository<AccountBook.Model.Commodity>>();
        }

        public void Handle(CommodityModifiedEvent message)
        {
            _commodityRepository.Update(new Commodity
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
    }}
