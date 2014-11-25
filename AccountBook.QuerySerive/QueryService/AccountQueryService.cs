//*************************************
// All rights reserved
// filename:AccountQueryService
// description:this is a class file
// created by kikao
// created at 2014/9/7 21:58:18
// version 1.0
//*************************************

using Apworks.Application;
using Apworks.Repositories;
using Apworks.Specifications;

namespace AccountBook.Service.QueryService
{
    using AccountBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class AccountQueryService
    {
        private static readonly IRepository<Account> _AccountRepository;

        static AccountQueryService()
        {
            _AccountRepository  = AppRuntime.Instance.CurrentApplication.ObjectContainer.GetService<IRepository<AccountBook.Model.Account>>();
        }

        private AccountQueryService()
        {
        }

        public static Account FindBy(string loginName)
        {
           return _AccountRepository.Find(Specification<Account>.Eval(x => x.LoginName == loginName));
        }
    }
}
