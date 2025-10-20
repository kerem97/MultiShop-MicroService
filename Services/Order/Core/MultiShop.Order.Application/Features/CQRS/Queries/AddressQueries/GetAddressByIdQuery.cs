using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public string Id { get; set; }

        public GetAddressByIdQuery(string id)
        {
            Id = id;
        }
    }
}
