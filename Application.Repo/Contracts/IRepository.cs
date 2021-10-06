using System;
using System.Collections.Generic;
using System.Text;
/**
 * 
 * name         :   IRepository.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Repo.Contracts
{
    public interface IRepository<T> where T : class

    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
