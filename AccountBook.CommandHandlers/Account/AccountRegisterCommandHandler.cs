//*************************************
// All rights reserved
// filename:AccountCommandHandlers
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:33:51
// version 1.0
//*************************************

using AccountBook.Commands.Account;
using Apworks.Commands;
using Apworks.Repositories;

namespace AccountBook.CommandHandlers.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AccountBook.Model;

    public class AccountRegisterCommandHandler: CommandHandler<AccountRegisterCommand>
    {
        public override void Handle(AccountRegisterCommand command)
        {
            using (IDomainRepository repository = this.DomainRepository)
            {
                Account account = new Account
                {
                    Id = command.Id,
                    LoginName = command.LoginName,
                    UserName = command.UserName,
                    Password = command.Password
                };
                account.AccountRegister();
                repository.Save(account);
                repository.Commit();
            }
        }
    }
}
