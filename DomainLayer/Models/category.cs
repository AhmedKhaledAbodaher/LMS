﻿using DomainLayer.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Category: BaseModel
    {

        public string CategoryName { get; set; }

        public ICollection<Material>  Material { get; set; }
    }
}
