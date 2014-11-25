//*************************************
// All rights reserved
// filename:AccountCommandService
// description:this is a class file
// created by kikao
// created at 2014/9/8 10:16:20
// version 1.0
//*************************************

using AustinHarris.JsonRpc;

namespace AccountBook.JsonRpc.QueryService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountCommandService:JsonRpcService
    {
        [JsonRpcMethod]
        private bool Register(string loginName,string password)
        {
            return AccountBook.Service.CommandService.AccountCommandService.Register(loginName, password);
        }
    }
}
