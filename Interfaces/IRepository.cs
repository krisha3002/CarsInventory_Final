// CarsInventoryMvc/Interfaces/IRepository.cs
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Remove(T entity);
}
