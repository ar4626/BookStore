﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Layer.ResponseModel
{
    public class ResModel<T>
    {
        public bool Success { get; set; }
        public T Data {  get; set; }
        public string Message { get; set; }


    }
}
