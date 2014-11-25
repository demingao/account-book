//*************************************
// All rights reserved
// filename:AccountCommandService
// description:this is a class file
// created by kikao
// created at 2014/9/8 10:16:20
// version 1.0
//*************************************

using AccountBook.Commands.Account;
using Apworks.Application;
using Apworks.Bus;
using Apworks.Commands;

namespace AccountBook.Service.CommandService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountCommandService
    {
        private static void CommitCommand(ICommand command)
        {
            try
            {
                using (ICommandBus commandBus = AppRuntime
                    .Instance
                    .CurrentApplication
                    .ObjectContainer
                    .GetService<ICommandBus>())
                {
                    commandBus.Publish(command);
                    commandBus.Commit();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool Register(string loginName, string password)
        {
            try
            {
                AccountRegisterCommand command = new AccountRegisterCommand
                {
                    Id = Guid.NewGuid(),
                    LoginName = loginName,
                    Password = password
                };
                CommitCommand(command);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
