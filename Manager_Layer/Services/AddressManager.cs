using Common_Layer.RequestModel;
using Manager_Layer.Interface;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Services
{
    public class AddressManager : IAddressManager
    {
        private readonly IAddressRepository repository;

        public AddressManager(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public AddressEntity AddAddress(int userId, AddAddressModel model)
        {
            return repository.AddAddress(userId, model);
        }
        public AddressEntity UpdateAddress(int userId, AddAddressModel model, int AddressId)
        {
            return repository.UpdateAddress(userId, model, AddressId);  
        }
        public List<AddressEntity> GetAllAddresses(int userId)
        {
            return repository.GetAllAddresses(userId);
        }
        public bool DeleteAddress(int AddressId)
        {
            return repository.DeleteAddress(AddressId);
        }




    }
}
