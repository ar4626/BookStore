using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository_Layer.Entity
{
    public class BookEntitiy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookDesc { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Image {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("BookBy")]
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual UserEntity BookBy { get; set; }

    }
}
