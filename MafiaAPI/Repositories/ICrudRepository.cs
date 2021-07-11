using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories {

    public interface ICrudRepository<T> where T: Model{
    
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Create(T model);
        long CreateGetId(T model);
        void Update(T model);
        void Delete(T model);

        void DeleteById(long id);
    }

}