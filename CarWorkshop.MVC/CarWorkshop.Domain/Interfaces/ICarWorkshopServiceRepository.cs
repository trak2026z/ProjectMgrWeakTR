using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopServiceRepository
    {
        Task Create(CarWorkshopService service);
        Task<CarWorkshopService?> GetById(int id);
        Task<IEnumerable<CarWorkshopService>> GetByWorkshopId(int workshopId);
        Task<IEnumerable<CarWorkshopService>> GetAll();
        Task Update(CarWorkshopService service);
        Task Delete(CarWorkshopService service);
        Task Commit();
    }
}
