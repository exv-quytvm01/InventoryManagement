using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Entities
{
    public interface BaseEntity
    {
        public DateTime DateCreated { get; set; }
       
        public DateTime LastModified { get; set; }
    }
}
