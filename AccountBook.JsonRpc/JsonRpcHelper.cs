//*************************************
// All rights reserved
// filename:JsonRpcHelper
// description:this is a class file
// created by kikao
// created at 2014/9/8 18:22:42
// version 1.0
//*************************************

using System.Web;
using System.Web.Caching;
using AustinHarris.JsonRpc;

namespace AccountBook.JsonRpc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JsonRpcHelper
    {
        public static HttpContextBase Context
        {
            get { return ((HttpRequest)JsonRpcContext.Current().Value).RequestContext.HttpContext; }
        }

        public static Cache Cache
        {
            get { return Context.Cache; }
        }
    }
}
