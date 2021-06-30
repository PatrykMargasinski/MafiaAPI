using MafiaAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;  
using System;   
using System.Linq; 

namespace MafiaAPI.Repositories {

    public abstract class CrudRepository<T>: ICrudRepository<T> where T: Model{
        
        
        protected readonly MafiaDBContext _context;
        protected DbSet<T> entities; 
        public CrudRepository(MafiaDBContext context){
            _context = context;
            entities = _context.Set<T>(); 
        }

        public  IEnumerable<T> getAll(){
            return entities.AsEnumerable();
        }
        public T getById(long id) {
            return entities.SingleOrDefault(s => s.id == id); 
        }
        public void create(T model){
            entities.Add(model);
            _context.SaveChanges();
        }
        public void update(T model){
            entities.Update(model);
            _context.SaveChanges();
        }
        public void delete(T model){
            entities.Remove(model);
            _context.SaveChanges();
        }

        public void deleteById(long id){
            entities.Remove(getById(id));
            _context.SaveChanges();
        }
    }
}