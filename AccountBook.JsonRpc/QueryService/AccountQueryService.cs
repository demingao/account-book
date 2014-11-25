//*************************************
// All rights reserved
// filename:AccountQuerySevice
// description:this is a class file
// created by kikao
// created at 2014/9/7 21:47:38
// version 1.0
//*************************************

using System.Net;
using AustinHarris.JsonRpc;
using System.Web;

namespace AccountBook.JsonRpc.QueryService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountQueryService : JsonRpcService
    {
        [JsonRpcMethod]
        private bool Login(string loginName, string password)
        {
            try
            {
                var account = AccountBook.Service.QueryService.AccountQueryService.FindBy(loginName);
                JsonRpcHelper.Cache["loginuser"]=account;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
    }
}
