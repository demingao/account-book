//*************************************
// All rights reserved
// filename:CommodityQueryService
// description:this is a class file
// created by kikao
// created at 2014/9/8 16:23:50
// version 1.0
//*************************************

using AccountBook.Model;
using Apworks;
using Apworks.Application;
using Apworks.Repositories;
using Apworks.Specifications;
using Apworks.Storage;

namespace AccountBook.Service.QueryService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityQueryService
    {
        private static readonly IRepository<Commodity> _CommodityRepository;

        static CommodityQueryService()
        {
            _CommodityRepository = AppRuntime.Instance.CurrentApplication.ObjectContainer.GetService<IRepository<AccountBook.Model.Commodity>>();
        }

        private CommodityQueryService()
        {
        }

        public static IEnumerable<Commodity> Pages(int pageIndex, int pageSize)
        {
            return _CommodityRepository.FindAll(x => x.RecordTime, SortOrder.Descending, pageIndex, pageSize);
            //return _CommodityRepository.FindAll(x => x.RecordTime, SortOrder.Descending);
        }

    }
}
