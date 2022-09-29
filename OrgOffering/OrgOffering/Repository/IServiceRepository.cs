using OrgOffering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IServiceRepository : IGenericRepository<Service>
{
    Service GetMostRecentService();

    Service GetService(Guid id);

    void CreateService(Service service);

    void EditService(Service service);

    void DeleteService(Service service);

    void ExistService(Service service);


}
