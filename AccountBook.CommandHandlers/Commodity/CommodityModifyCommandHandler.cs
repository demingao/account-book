//*************************************
// All rights reserved
// filename:CommodityModifyCommandHandler
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:55:38
// version 1.0
//*************************************

using Apworks.Commands;
using Apworks.Repositories;

namespace AccountBook.CommandHandlers.Commodity
{
    using AccountBook.Commands.Commodity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AccountBook.Model;

    public class CommodityModifyCommandHandler:CommandHandler<CommodityModifyCommand>
    {
        public override void Handle(CommodityModifyCommand command)
        {
            using (IDomainRepository repository = this.DomainRepository)
            {
                Commodity commdity = new Commodity
                {
                    Id = command.Id,
                    Name = command.Name,
                    Price = command.Price,
                    Describe = command.Describe,
                    RecordTime = command.RecordTime,
                };
                commdity.ModifiyCommodity(command.Creater);
                repository.Save(commdity);
                repository.Commit();
            }
        }
    }
}
