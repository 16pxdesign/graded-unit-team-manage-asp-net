using System;
using Application.Data.Models;
/**
 * 
 * name         :   IProfileRepository.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Repo.Contracts
{
    public interface IProfileRepository
    {
        void AddUpdateSkill(Skill skill);
        void AddUpdateProfile(Profile profile);
      
    }
}