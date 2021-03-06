using MafiaAPI.Database;
using MafiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MafiaAPI.Repositories
{
    public abstract class CrudRepository<T> : ICrudRepository<T> where T : Model
    {
        protected readonly MafiaDBContext _context;
        protected DbSet<T> entities;
        public CrudRepository(MafiaDBContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public IList<T> GetAll()
        {
            return entities.ToList();
        }
        public T GetById(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public T GetRandom()
        {
            return entities.OrderBy(r => Guid.NewGuid()).FirstOrDefault();
        }

        public void Create(T model)
        {
            entities.Add(model);
            _context.SaveChanges();
        }
        public long CreateGetId(T model)
        {
            Create(model);
            return model.Id;
        }
        public void Update(T model)
        {
            entities.Update(model);
            _context.SaveChanges();
        }
        public void Delete(T model)
        {
            entities.Remove(model);
            _context.SaveChanges();
        }

        public void DeleteById(long id)
        {
            entities.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void DeleteByIds(long[] ids)
        {
            entities.RemoveRange(entities.Where(x => ids.Contains(x.Id)));
            _context.SaveChanges();
        }
    }
}