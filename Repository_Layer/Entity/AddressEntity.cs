using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository_Layer.Entity
{
    public class AddressEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public string AddressLabel { get; set; }
        public string Address {  get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [ForeignKey("AddressBy")]
        public int UserId { get; set; }
        public virtual UserEntity AddressBy { get; set; }
    }
}
