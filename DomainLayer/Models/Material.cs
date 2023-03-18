using DomainLayer.Models.BaseEntity;
using DomainLayer.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Material : BaseModel
    {

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public Category Category { get; set; }
        public long CategoryId { get; set; }
    }
}
