using Common_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interface
{
    public interface IAddressRepository
    {
        public AddressEntity AddAddress(int userId, AddAddressModel model);
        public AddressEntity UpdateAddress(int userId, AddAddressModel model, int AddressId);
        public List<AddressEntity> GetAllAddresses(int userId);
        public bool DeleteAddress(int AddressId, int userId);




    }
}
