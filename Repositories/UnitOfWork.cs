// CarsInventoryMvc/Repositories/UnitOfWork.cs
using CarsInventoryMvc.Models;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        CarRepository = new Repository<Car>(_context);
    }

    public IRepository<Car> CarRepository { get; }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
