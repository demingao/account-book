//*************************************
// All rights reserved
// filename:CommodityDeleteCommandHandler
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:57:29
// version 1.0
//*************************************

using AccountBook.Commands.Commodity;
using Apworks.Commands;
using Apworks.Repositories;

namespace AccountBook.CommandHandlers.Commodity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AccountBook.Model;

    public class CommodityDeleteCommandHandler : CommandHandler<CommodityDeleteCommand>
    {
        public override void Handle(CommodityDeleteCommand command)
        {
            using (IDomainRepository repository = this.DomainRepository)
            {
                Commodity commdity = new Commodity
                   {
                       Id = command.Id
                   };
                commdity.DeleteCommodity();
                repository.Save(commdity);
                repository.Commit();
            }
        }
    }
}
