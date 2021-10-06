using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using Application.Data.Models;
using Application.Repo.Contracts;
using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
/**
 * 
 * name         :   MemberRepositories.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Repo
{
    /// <summary>
    /// This class is repository class for member
    /// </summary>
    public class MemberRepositories : GenericRepository<Member>, IMemberRepositories
    {
        private readonly DatabaseModel _context;


        public MemberRepositories(DatabaseModel context) : base(context)
        {
            _context = context;
        }

        public Member FindBySRU(string sru)
        {
            return _context.Members.Find(sru);
        }


        public List<Member> GetMemberList()
        {
            return _context.Members.ToList();
        }

        public List<Member> GetPlayerList()
        {
            return _context.Members.Where(x => x.Type != MemberType.Member).ToList();
        }

        public void DeleteBySRU(string sru)
        {
            var member = _context.Members.Find(sru);

            _context.Remove(member);
            try
            {
                _context.SaveChanges();

            }
            catch (SqliteException e)
            {
                throw new Exception("Delete member error",e);
            }
        }

        public Exception InsertEditMember(Member save)
        {
            var isMemberExist = IsMemberExist(save.SRU);

            if (!isMemberExist)
            {
                _context.Members.Add(save);
                _context.SaveChanges();
                return null;
            }
            else
            {
                var dbMember = _context.Members.AsNoTracking().Single(x => x.SRU == save.SRU);
                Doctor dbDoctor = null;
                if (_context.Doctor.AsNoTracking().Any(x => x.PlayerSRU == save.SRU))
                {
                    dbDoctor = _context.Doctor.AsNoTracking().Single(x => x.PlayerSRU == save.SRU);
                }
                Kin dbKin = null;
                if (_context.Kin.AsNoTracking().Any(x => x.SeniorSRU == save.SRU))
                {
                    dbKin = _context.Kin.AsNoTracking().Single(x => x.SeniorSRU == save.SRU);
                }

                var dbHealth = _context.HealthIssues.AsNoTracking().Where(x => x.PlayerSRU == save.SRU).ToList();
                var dbGuardian = _context.Guardians.AsNoTracking().Where(x => x.JuniorId == save.SRU).ToList();

                save.AddressId = dbMember.AddressId;
                _context.Entry(save).State = EntityState.Modified;
                save.AddressId = dbMember.AddressId;
                _context.Entry(save).State = EntityState.Modified;
                save.Address.Id = dbMember.AddressId;
                _context.Entry(save.Address).State = EntityState.Modified;

                switch (save.Type)
                {
                    case MemberType.Member:
                        if (_context.Player.Any(x => x.SRU == save.SRU))
                        {
                            _context.Player.Remove(_context.Player.First(x => x.SRU == save.SRU));
                        }

                        break;
                    case MemberType.Junior:
                        if (_context.Senior.AsNoTracking().Any(x => x.SRU == save.SRU))
                            _context.Senior.Remove(_context.Senior.Find(save.SRU));

                        if (_context.Player.Any(x => x.SRU == save.SRU))
                        {
                            save.Player.SRU = save.SRU;
                            _context.Entry(save.Player).State = EntityState.Modified;
                        }
                        else
                        {
                            save.Player.SRU = save.SRU;
                            _context.Entry(save.Player).State = EntityState.Added;
                        }


                        if (dbDoctor != null)
                        {
                            save.Player.Doctor.Id = dbDoctor.Id;
                            save.Player.Doctor.PlayerSRU = dbDoctor.PlayerSRU;
                            save.Player.Doctor.AddressId = dbDoctor.AddressId;
                            _context.Entry(save.Player.Doctor).State = EntityState.Modified;


                            save.Player.Doctor.Address.Id = dbDoctor.AddressId;
                            _context.Entry(save.Player.Doctor.Address).State = EntityState.Modified;
                        }
                        else
                        {
                            save.Player.Doctor.PlayerSRU = save.SRU;
                            _context.Doctor.Add(save.Player.Doctor);
                        }

                        if (_context.Junior.Any(x => x.SRU == save.SRU))
                        {
                            save.Player.Junior.SRU = save.SRU;
                            _context.Entry(save.Player.Junior).State = EntityState.Modified;
                        }
                        else
                        {
                            save.Player.Junior.SRU = save.SRU;
                            _context.Entry(save.Player.Junior).State = EntityState.Added;
                        }


                        //health
                        foreach (var t in dbHealth)
                        {
                            if (!save.Player.HealthIssues.Exists(x => x.Id == t.Id))
                            {
                                _context.HealthIssues.Remove(t);
                                _context.SaveChanges();
                            }
                        }

                        foreach (var t in save.Player.HealthIssues)
                        {
                            if (dbHealth.Exists(x => x.Id == t.Id))
                            {
                                t.PlayerSRU = save.SRU;

                                _context.HealthIssues.Update(t);
                                _context.SaveChanges();
                            }
                            else
                            {
                                _context.HealthIssues.Add(t);
                                _context.SaveChanges();
                            }
                        }

                        //guardian
                        foreach (var t in dbGuardian)
                        {
                            if (!save.Player.Junior.Guardians.Exists(x => x.Id == t.Id))
                            {
                                _context.Guardians.Remove(t);
                                _context.SaveChanges();
                            }
                        }

                        foreach (var t in save.Player.Junior.Guardians)
                        {
                            if (dbGuardian.Exists(x => x.Id == t.Id))
                            {
                                t.JuniorId = save.SRU;
                                t.AddressId = _context.Guardians.AsNoTracking().First(x => x.Id == t.Id).AddressId;
                                t.Address.Id = t.AddressId;
                                _context.Guardians.Update(t);
                                _context.Address.Update(t.Address);
                                _context.SaveChanges();
                            }
                            else
                            {
                                _context.Guardians.Add(t);
                                _context.SaveChanges();
                            }
                        }

                        break;
                    case MemberType.Senior:

                        if (_context.Junior.AsNoTracking().Any(x => x.SRU == save.SRU))
                            _context.Junior.Remove(_context.Junior.Find(save.SRU));

                        if (_context.Player.Any(x => x.SRU == save.SRU))
                        {
                            save.Player.SRU = save.SRU;
                            _context.Entry(save.Player).State = EntityState.Modified;
                        }
                        else
                        {
                            save.Player.SRU = save.SRU;
                            _context.Entry(save.Player).State = EntityState.Added;
                        }


                        if (dbDoctor != null)
                        {
                            save.Player.Doctor.Id = dbDoctor.Id;
                            save.Player.Doctor.PlayerSRU = dbDoctor.PlayerSRU;
                            save.Player.Doctor.AddressId = dbDoctor.AddressId;
                            _context.Entry(save.Player.Doctor).State = EntityState.Modified;


                            save.Player.Doctor.Address.Id = dbDoctor.AddressId;
                            _context.Entry(save.Player.Doctor.Address).State = EntityState.Modified;
                        }
                        else
                        {
                            save.Player.Doctor.PlayerSRU = save.SRU;
                            _context.Doctor.Add(save.Player.Doctor);
                        }

                        if (_context.Senior.Any(x => x.SRU == save.SRU))
                        {
                            save.Player.Senior.SRU = save.SRU;
                            _context.Entry(save.Player.Senior).State = EntityState.Modified;
                        }
                        else
                        {
                            save.Player.Senior.SRU = save.SRU;
                            _context.Entry(save.Player.Senior).State = EntityState.Added;
                        }

                        if (dbKin != null)
                        {
                            save.Player.Senior.Kin.Id = dbKin.Id;
                            save.Player.Senior.Kin.SeniorSRU = dbKin.SeniorSRU;
                            save.Player.Senior.Kin.AddressId = dbKin.AddressId;
                            _context.Entry(save.Player.Senior.Kin).State = EntityState.Modified;


                            save.Player.Senior.Kin.Address.Id = dbKin.AddressId;
                            _context.Entry(save.Player.Senior.Kin.Address).State = EntityState.Modified;
                        }
                        else
                        {
                            
                            save.Player.Senior.Kin.SeniorSRU = save.SRU;
                            _context.Kin.Add(save.Player.Senior.Kin);
                        }

                        //health
                        foreach (var t in dbHealth)
                        {
                            if (!save.Player.HealthIssues.Exists(x => x.Id == t.Id))
                            {
                                _context.HealthIssues.Remove(t);
                                _context.SaveChanges();
                            }
                        }

                        foreach (var t in save.Player.HealthIssues)
                        {
                            if (dbHealth.Exists(x => x.Id == t.Id))
                            {
                                t.PlayerSRU = save.SRU;

                                _context.HealthIssues.Update(t);
                                _context.SaveChanges();
                            }
                            else
                            {
                                _context.HealthIssues.Add(t);
                                _context.SaveChanges();
                            }
                        }


                        break;
                }

                //member
                _context.SaveChanges();


                //address
            }


            return null;
        }

        public bool IsMemberExist(string sru)
        {
            var exits = _context.Members.Where(x => x.SRU == sru).AsNoTracking().FirstOrDefault();
            return exits != null;
        }

        public bool IsPlayer(string id)
        {
            var any = _context.Player.Any(x => x.SRU == id);
            return any;
        }

        public Game FindGame(int id)
        {
            return _context.Game.Find(id);
        }
    }
}