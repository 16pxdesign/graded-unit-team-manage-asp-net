using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
/**
 * 
 * name         :   IUnitOfWork.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Repo.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
