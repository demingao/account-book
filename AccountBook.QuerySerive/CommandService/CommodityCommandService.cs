//*************************************
// All rights reserved
// filename:CommodityCommandService
// description:this is a class file
// created by kikao
// created at 2014/9/8 16:24:16
// version 1.0
//*************************************

using AccountBook.Commands.Commodity;
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

    public class CommodityCommandService
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

        public static bool Create(string name,float price,string describe,Guid creater)
        {
            try
            {
                var createCommand = new CommodityCreateCommand
                {
                    Id=Guid.NewGuid(),
                    Creater = creater,
                    Describe = describe,
                    Name=name,
                    Price = price,
                    RecordTime = DateTime.Now
                };
                CommitCommand(createCommand);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool Modify(Guid id,string name, float price, string describe, Guid creater)
        {
            try
            {
                var modifyCommand = new CommodityModifyCommand
                {
                    Id = id,
                    Creater = creater,
                    Describe = describe,
                    Name = name,
                    Price = price,
                    RecordTime = DateTime.Now
                };
                CommitCommand(modifyCommand);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool Delete(Guid id)
        {
            try
            {
                var deleteCommand = new CommodityDeleteCommand
                {
                    Id =id
                };
                CommitCommand(deleteCommand);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
