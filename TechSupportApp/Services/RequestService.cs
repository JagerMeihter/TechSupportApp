using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TechSupportApp.DataAccess;
using TechSupportApp.Models;

namespace TechSupportApp.Services
{
    public class RequestService
    {
        public List<Request> GetRequests(int? assignedToUserId = null, string searchText = null, int? executorId = null)
        {
            using (var context = new AppDbContext())
            {
                var query = context.Requests
                    .Include(r => r.EquipmentType)
                    .Include(r => r.Priority)
                    .Include(r => r.Status)
                    .Include(r => r.AssignedToUser)
                    .AsQueryable();

                if (assignedToUserId.HasValue)
                    query = query.Where(r => r.AssignedToUserId == assignedToUserId.Value);

                if (!string.IsNullOrEmpty(searchText))
                {
                    searchText = searchText.ToLower();
                    query = query.Where(r => r.Id.ToString().Contains(searchText) ||
                                             r.ClientName.ToLower().Contains(searchText));
                }

                if (executorId.HasValue && executorId.Value > 0)
                    query = query.Where(r => r.AssignedToUserId == executorId.Value);

                return query.OrderByDescending(r => r.CreateDate).ToList();
            }
        }

        public Request GetRequestById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Requests
                    .Include(r => r.EquipmentType)
                    .Include(r => r.Priority)
                    .Include(r => r.Status)
                    .Include(r => r.AssignedToUser)
                    .FirstOrDefault(r => r.Id == id);
            }
        }

        public void AddRequest(Request request)
        {
            using (var context = new AppDbContext())
            {
                request.CreateDate = DateTime.Now;
                context.Requests.Add(request);
                context.SaveChanges();
            }
        }

        public void UpdateRequest(Request request)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Requests.Find(request.Id);
                if (existing != null)
                {
                    context.Entry(existing).CurrentValues.SetValues(request);
                    // Обновляем внешние ключи, так как навигационные свойства могут быть не загружены
                    existing.EquipmentTypeId = request.EquipmentTypeId;
                    existing.PriorityId = request.PriorityId;
                    existing.StatusId = request.StatusId;
                    existing.AssignedToUserId = request.AssignedToUserId;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteRequest(int id)
        {
            using (var context = new AppDbContext())
            {
                var request = context.Requests.Find(id);
                if (request != null)
                {
                    context.Requests.Remove(request);
                    context.SaveChanges();
                }
            }
        }

        public List<EquipmentType> GetEquipmentTypes()
        {
            using (var context = new AppDbContext())
            {
                return context.EquipmentTypes.ToList();
            }
        }

        public List<RequestStatus> GetRequestStatuses()
        {
            using (var context = new AppDbContext())
            {
                return context.RequestStatuses.ToList();
            }
        }

        public List<Priority> GetPriorities()
        {
            using (var context = new AppDbContext())
            {
                return context.Priorities.ToList();
            }
        }

        public List<User> GetExecutors()
        {
            using (var context = new AppDbContext())
            {
                return context.Users.Where(u => u.Role.Name == "Executor").ToList();
            }
        }
    }
}