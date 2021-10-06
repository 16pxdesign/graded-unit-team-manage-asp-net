using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Application.Data.Models;
using Application.Repo.Contracts;
/**
 * 
 * name         :   ProfileRepository.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Repo
{
    /// <summary>
    /// This class is repository class for player evaluation
    /// </summary>
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        private readonly DatabaseModel _context;


        public ProfileRepository(DatabaseModel context) : base(context)
        {
            _context = context;
        }

        public void AddUpdateSkill(Skill skill)
        {
            if (!_context.Training.Any(x => x.Id == skill.Id))
            {
                if (skill.Type == SkillType.Category)
                    skill.ParentId = null;
                
                _context.Skill.Update(skill);
            }
            else
            {
                _context.Skill.Add(skill);
            }

            _context.SaveChanges();
        }


        public List<Skill> GetSkillList()
        {
            return _context.Skill.ToList();
        }

        public Skill GetSkillById(int id)
        {
            return _context.Skill.Find(id);
        }

        public List<Skill> GetCategories()
        {
            return _context.Skill.Where(x => x.Type == SkillType.Category).ToList();

        }
        
        public List<Skill> GetSkills()
        {
            return _context.Skill.Where(x => x.Type == SkillType.Skill).ToList();

        }
        
        public void AddUpdateProfile(Profile profile)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSkill(int id)
        {
            var skill = _context.Skill.Find(id);
            if(skill==null)
                throw new Exception("Not exist");
            if(_context.Skill.Any(x => x.ParentId == skill.Id))
                throw new Exception("Delete skills before category");
            _context.Skill.Remove(skill);
            _context.SaveChanges();

        }

        public List<Profile> GetProfileList()
        {
            throw new NotImplementedException();
        }

        public List<Profile> GetPlayerSkillsScores(string id)
        {
            return _context.Profile.Where(x => x.PlayerSRU == id).ToList();
        }

        public void SaveListOfScores(List<Profile> profiles)
        {
            foreach (var p in profiles)
            {
               // p.Player = _context.Player.First(x => x.SRU == p.PlayerSRU);
               // p.Skill = _context.Skill.Find(p.SkillId);
                if (_context.Profile.Any(x => x.PlayerSRU==p.PlayerSRU && x.SkillId == p.SkillId))
                {
                    _context.Profile.Update(p);
                }
                else
                {
                    _context.Profile.Add(p);
                }

                _context.SaveChanges();
            }
        }
    }
}