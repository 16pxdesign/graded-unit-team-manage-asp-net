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
 * name         :   TrainingRepositories.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Repo
{
    /// <summary>
    /// This class is repository class for training 
    /// </summary>
    public class TrainingRepositories : GenericRepository<Training>, ITrainingRepository
    {
        private readonly DatabaseModel _context;


        public TrainingRepositories(DatabaseModel context) : base(context)
        {
            _context = context;
        }

        public List<Training> GetListOfTrainings()
        {
            return _context.Training.ToList();
        }

        public List<SelectListItem> GetListOfCoaches()
        {
            var list = _context.Members.Where(x => x.Type == MemberType.Member).ToList();
            var coaches = new List<SelectListItem>();

            foreach (var item in list)
            {
                var selectListItem = new SelectListItem {Text = string.Concat(item.Name, " ", item.Surname)};
                if (item.SRU != null) selectListItem.Value = item.SRU;
                selectListItem.Selected = false;
                coaches.Add(selectListItem);
            }

            return coaches;
        }

        public void AddUpdateTraining(Training training, List<Activities> list = null)
        {
            if (_context.Training.Any(x => x.Id == training.Id))
            {
                var rootActivities = _context.Activities.AsNoTracking().Where(x => x.TrainingId == training.Id).ToList();
                foreach (var activity in rootActivities)
                {
                    if (!list.Exists(x => x.Name == activity.Name))
                    {
                        _context.Activities.Remove(activity);
                        _context.SaveChanges();

                    }
                }

                _context.Training.Update(training);
            }
            else
                _context.Training.Add(training);

            _context.SaveChanges();
        }

        public Training GetTraining(int id)
        {
            return _context.Training.Find(id);
        }

        public void DeleteTrainingById(int id)
        {
            var result = _context.Training.Find(id);

            _context.Remove(result);
            _context.SaveChanges();
        }


        public void InsertUpdateAttendance(Training save, string[] Ids)
        {
            var list = _context.Attendance.Where(x => x.TrainingId == save.Id).ToList();
            _context.Attendance.RemoveRange(list);
            _context.SaveChanges();
            if (Ids != null)
                foreach (var id in Ids)
                {
                    Player player = _context.Player.Find(id);
                    var attendance = new Attendance()
                    {
                        Training = save,
                        Player = player,
                        TrainingId = save.Id,
                        PlayerSRU = player.SRU
                    };
                    _context.Attendance.Add(attendance);
                }

            _context.SaveChanges();
        }

        public string[] GetSelectedAttendance(Training training)
        {
            var list = _context.Attendance.Where(x => x.TrainingId == training.Id).ToList();
            var ids = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                ids[i] = list[i].PlayerSRU;
            }


            return ids;
        }


        public List<Member> GetAttendenceList(int resultId)
        {
            var members = new List<Member>();
            var attendances = _context.Attendance.Where(x => x.TrainingId == resultId).ToList();
            foreach (var member in attendances)
            {
                members.Add(_context.Members.Find(member.PlayerSRU));
            }

            return members;
        }
    }
}