/**
 * 
 * name         :   Member.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for member
    /// </summary>
    public class Member
    {
        //Primary
        public string SRU { get; set; }

        //Properties
        public MemberType Type  { get; set; }
        public string Name { get; set; }  
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool Active { get; set; }
        public int AddressId { get; set; }

        //Relations
        public virtual Player Player { get; set; }
        public virtual Address Address { get; set; }

  
    }
}