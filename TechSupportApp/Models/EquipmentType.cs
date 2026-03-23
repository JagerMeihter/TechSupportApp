using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupportApp.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
