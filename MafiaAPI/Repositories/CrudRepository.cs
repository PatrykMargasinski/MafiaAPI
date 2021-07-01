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

        public  IEnumerable<T> GetAll(){
            return entities.AsEnumerable();
        }
        public T GetById(long id) {
            return entities.SingleOrDefault(s => s.id == id); 
        }
        public void Create(T model){
            entities.Add(model);
            _context.SaveChanges();
        }
        public void Update(T model){
            entities.Update(model);
            _context.SaveChanges();
        }
        public void Delete(T model){
            entities.Remove(model);
            _context.SaveChanges();
        }

        public void DeleteById(long id){
            entities.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}