using OrgOffering.Data;
using OrgOffering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ServiceRepository : GenericRepository<Service>, IServiceRepository
{
    public ServiceRepository(CMPG323Context context) : base(context)
    {
    }

    public void CreateService(Service service)
    {
        Create(service);
    }

    public void EditService(Service service)
    {
        Update(service);
    }

    public void DeleteService(Service service)
    {
        Remove(service);
    }

    public void ExistService(Service service)
    {
        //   return Task.FromResult(GenericRepository<Service>.GetService(Find()).Orderby);
        //ditnotcomplete
    }

    public Service GetMostRecentService()
    {
        return _context.Service.OrderByDescending(service => service.CreatedDate).FirstOrDefault();
    }

    public Service GetService(Guid id)
    {
        return Find(s => s.ServiceId == id).FirstOrDefault();
    }
}

