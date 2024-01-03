// CarsInventoryMvc/Repositories/Repository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    private readonly DbSet<T> _entities;

    public Repository(AppDbContext context)
    {
        Context = context;
        _entities = context.Set<T>();
    }

    public T GetById(int id)
    {
        return _entities.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.ToList();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _entities.Where(predicate);
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public void Remove(T entity)
    {
        _entities.Remove(entity);
    }
}
