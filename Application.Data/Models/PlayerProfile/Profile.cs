/**
 * 
 * name         :   Profile.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{ 
    /// <summary>
    /// This class representing model for player evaluation
    /// </summary>
    public class Profile
    {
        //Primary
        public string PlayerSRU { get; set; }
        public int SkillId { get; set; }
        //Properties
        public string Description { get; set; }
        public int Score { get; set; }
        
        //Relations
        public virtual Skill Skill { get; set; }
        public virtual Player Player { get; set; }
    }
}