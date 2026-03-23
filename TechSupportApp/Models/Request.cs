using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupportApp.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public string Description { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public int StatusId { get; set; }
        public RequestStatus Status { get; set; }
        public int? AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string RepairComment { get; set; }
    }
}
