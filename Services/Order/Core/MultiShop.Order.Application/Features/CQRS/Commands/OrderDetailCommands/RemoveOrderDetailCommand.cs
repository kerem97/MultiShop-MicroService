using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand
    {
        public string Id { get; set; }

        public RemoveOrderDetailCommand(string id)
        {
            Id = id;
        }
    }
}
