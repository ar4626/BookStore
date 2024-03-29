using Common_Layer.RequestModel;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository_Layer.Services
{
    public class AddressRepository
    {
        private readonly BookStoreContext context;

        public AddressRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public AddressEntity AddAddress (int userId, AddAddressModel model)
        {
            var user = context.UserTable.FirstOrDefault(a=>a.UserId == userId); 
            if(user !=null)
            {
                AddressEntity address = new AddressEntity();
                address.UserId = userId;
                address.AddressLabel = model.AddressLabel;
                address.Address = model.Address;
                address.City = model.City;
                address.State = model.State;
                context.AddressTable.Add(address);
                context.SaveChanges();
                return address;
            }
            else
            {
                throw new Exception("User Doesnot Exist");
            }
        }

        public AddressEntity UpdateAddress(int userId, AddAddressModel model, int AddressId)
        {
            var address = context.AddressTable.FirstOrDefault(a=>a.AddressId == AddressId && a.UserId==userId);
            if (address != null)
            {
                address.AddressLabel = model.AddressLabel;
                address.Address = model.Address;
                address.City = model.City;
                address.State = model.State;
                context.SaveChanges();
                return address;
            }
            else
            {
                throw new Exception("User Doesnot Exist");
            }
        }

        public List<AddressEntity> GetAllAddresses(int userId)
        {
            return context.AddressTable.Where(a=>a.UserId == userId).ToList();  
        }

        public bool DeleteAddress(int AddressId)
        {
            var address = context.AddressTable.FirstOrDefault(a=>a.AddressId==AddressId);
            if(address != null)
            {
                context.AddressTable.Remove(address);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Address not Found");
            }
        }
    }
}
