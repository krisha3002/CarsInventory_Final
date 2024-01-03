// CarsInventoryMvc/Interfaces/IUnitOfWork.cs
using CarsInventoryMvc.Models;

public interface IUnitOfWork : IDisposable
{
    void SaveChanges();
    IRepository<Car> CarRepository { get; }
}
