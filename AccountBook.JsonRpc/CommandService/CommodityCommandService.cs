//*************************************
// All rights reserved
// filename:CommodityCommandService
// description:this is a class file
// created by kikao
// created at 2014/9/8 16:24:16
// version 1.0
//*************************************

using System.Web;
using AccountBook.Model;
using Apworks.Application;
using Apworks.Bus;
using Apworks.Commands;
using AustinHarris.JsonRpc;

namespace AccountBook.JsonRpc.QueryService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityCommandService : JsonRpcService
    {
        [JsonRpcMethod]
        private bool Create(string name, float price, string describe)
        {
            var account = (Account)JsonRpcHelper.Cache["loginuser"];
            if (null!=account)
            {
                var creater = account.Id;
                return AccountBook.Service.CommandService.CommodityCommandService.Create(name, price, describe, creater);
            }
            else
                return false;

        }
        [JsonRpcMethod]
        private bool Modify(Guid id, string name, float price, string describe)
        {
            var account = (Account)JsonRpcHelper.Cache["loginuser"];
            if (null != account)
            {
                var creater = account.Id;
                return AccountBook.Service.CommandService.CommodityCommandService.Modify(id, name, price, describe, creater);
            }
            else
                return false;

        }
        [JsonRpcMethod]
        private bool Delete(Guid id)
        {
            return AccountBook.Service.CommandService.CommodityCommandService.Delete(id);
        }
    }
}
