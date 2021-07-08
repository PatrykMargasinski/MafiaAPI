using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories {

    public interface ICrudRepository<T> where T: Model{
    
        public IList<T> GetAll();
        public T GetById(long id);
        public void Create(T model);
        public void Update(T model);
        public void Delete(T model);
        public void DeleteById(long id);
    }

}