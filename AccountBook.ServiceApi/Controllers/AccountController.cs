using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccountBook.ServiceApi.Models.Account;

namespace AccountBook.ServiceApi.Controllers
{
    public class AccountController : ApiController
    {
        public bool Post([FromBody]AccountLogin value)
        {
            
            return false;
        }
    }
}
