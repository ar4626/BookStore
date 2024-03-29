using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Layer.RequestModel
{
    public class AddAddressModel
    {
        public string AddressLabel { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
