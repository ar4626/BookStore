using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository_Layer.Entity
{
    public class CartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public bool IsOrdered { get; set; } = false;
        [ForeignKey("CartBy")]
        public int UserId { get; set; }
        public virtual UserEntity CartBy { get; set; }
        [ForeignKey("CartFor")]
        public int BookId { get; set; }
        public virtual BookEntitiy CartFor { get; set; }

    }
}
