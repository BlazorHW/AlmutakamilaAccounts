﻿using Accounts.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Accounts.Data.Repositories;

public class GRepository<T> : IGRepository<T> where T : class
{
    private readonly AccountingDbContext _context;
    private DbSet<T> table = null;
    public GRepository(AccountingDbContext context)
    {
        _context = context;
        table = _context.Set<T>();
    }
    public async Task<T> GetByIdAsync(Object id)
    {
        return await table.FindAsync(id);
    }
    public void Delete(Object id)
    {
        T existing = table.Find(id);
        table.Remove(existing);
    }
    public IQueryable<T> GetAll(bool Tracking = false)
    {
        if (Tracking) return table.AsQueryable();
        return table.AsQueryable().AsNoTracking();
    }
    public void Insert(T entity)
    {
        table.Add(entity);
    }
    public void Update(T entity)
    {
        table.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool Tracking = true)
    {
        if (Tracking) return table.Where(predicate).AsQueryable();
        return table.Where(predicate).AsQueryable().AsNoTracking();
    }
    public void RemoveRange(ICollection<T> entity)
    {
        table.RemoveRange(entity);
    }
}
