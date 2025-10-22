using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.CargoDetailDtos.Requests
{
    public class UpdateCargoDetailDto
    {
        public string Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int Barcode { get; set; }
        public string CargoCompanyId { get; set; }
    }
}
