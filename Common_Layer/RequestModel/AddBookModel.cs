using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Layer.RequestModel
{
    public class AddBookModel
    {
        public string BookName { get; set; }
        public string BookDesc { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
