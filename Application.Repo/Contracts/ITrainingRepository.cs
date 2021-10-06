using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Application.Data.Models;
using Application.Repo.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
/**
 * 
 * name         :   ITrainingRepository.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Repo.Contracts
{
    public interface ITrainingRepository
    {
        List<Training> GetListOfTrainings();
        List<SelectListItem> GetListOfCoaches();
        void AddUpdateTraining(Training training, List<Activities> list);
        Training GetTraining(int id);
        void InsertUpdateAttendance(Training save, string[] Ids);
    }
}