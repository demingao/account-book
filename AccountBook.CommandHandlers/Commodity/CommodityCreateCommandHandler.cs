//*************************************
// All rights reserved
// filename:CommdityCommandHandlers
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:44:05
// version 1.0
//*************************************

using Apworks.Commands;
using Apworks.Repositories;

namespace AccountBook.CommandHandlers.Commodity
{
    using AccountBook.Commands.Commodity;
    using AccountBook.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityCreateCommandHandler : CommandHandler<CommodityCreateCommand>
    {
        public override void Handle(CommodityCreateCommand command)
        {
            using (IDomainRepository repository = this.DomainRepository)
            {
                Commodity commdity = new Commodity
                {
                    Id = command.Id,
                    Name = command.Name,
                    Price = command.Price,
                    Describe = command.Describe,
                    RecordTime = command.RecordTime
                };
                commdity.CreateCommodity(command.Creater);
                repository.Save(commdity);
                repository.Commit();
            }
        }
    }
}
