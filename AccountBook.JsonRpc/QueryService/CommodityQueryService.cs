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
using Apworks.Storage;
using AustinHarris.JsonRpc;

namespace AccountBook.JsonRpc.QueryService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityQueryService : JsonRpcService
    {
        [JsonRpcMethod]
        private IEnumerable<Commodity> Pages(int pageIndex, int pageSize)
        {
            var result = AccountBook.Service.QueryService.CommodityQueryService.Pages(pageIndex, pageSize);
            return result;
        }
    }
}
