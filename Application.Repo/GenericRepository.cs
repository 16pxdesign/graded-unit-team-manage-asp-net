using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Data.Models;
using Application.Repo.Contracts;
using Microsoft.EntityFrameworkCore;
/**
 * 
 * name         :   GenericRepository.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Repo
{
    /// <summary>
    /// This class is generic repository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : class

    {
        private readonly DatabaseModel _DBContext;
        private readonly DbSet<T> _DBSet;

        public GenericRepository(DatabaseModel context)
        {
            
            this._DBContext = context;
            this._DBSet = this._DBContext.Set<T>();

        }

        public void Add(T entity)
        {
            this._DBSet.Add(entity);
            this._DBContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            this._DBSet.Remove(entity);
            this._DBContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this._DBSet.ToList();
            
        }

        public T GetById(int id)
        {
            return this._DBSet.Find(id);
        }

        public void Update(T entity)
        {
            this._DBSet.Update(entity);
            this._DBContext.SaveChanges();
        }
        
      
    }
}
