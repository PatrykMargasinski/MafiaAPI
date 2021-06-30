using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories {

    public interface ICrudRepository<T> where T: Model{
    
        public IEnumerable<T> getAll();
        public T getById(long id);
        public void create(T model);
        public void update(T model);
        public void delete(T model);

        public void deleteById(long id);
    }

}