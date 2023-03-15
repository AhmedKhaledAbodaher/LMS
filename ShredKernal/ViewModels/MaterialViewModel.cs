using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShredKernal.ViewModels
{
    public class MaterialViewModel
    {

        public ICollection<Material> MAterilas { get; set; }
        public string CategoryName { get; set; }

    }
}
