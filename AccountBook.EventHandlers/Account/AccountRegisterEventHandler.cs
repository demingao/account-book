//*************************************
// All rights reserved
// filename:AccountRegisterEventHandler
// description:this is a class file
// created by kikao
// created at 2014/9/7 10:39:48
// version 1.0
//*************************************

using AccountBook.Events.Account;
using AccountBook.Model;
using Apworks.Application;
using Apworks.Repositories;
using Apworks.Repositories.NHibernate;

namespace AccountBook.EventHandlers.Account
{
    using Apworks.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountRegisterEventHandler:IEventHandler<AccountRegisteredEvent>
    {
        private IRepository<AccountBook.Model.Account> _accountRepository;
        public AccountRegisterEventHandler()
        {
            _accountRepository = AppRuntime.Instance.CurrentApplication.ObjectContainer.GetService<IRepository<AccountBook.Model.Account>>();
        }
       
        public void Handle(AccountRegisteredEvent message)
        {
            _accountRepository.Add(new AccountBook.Model.Account
            {
                Id = message.Id,
                LoginName = message.LoginName,
                UserName = message.UserName,
                Password = message.Password
            });
            _accountRepository.Context.Commit();
        }
    }
}
