using System.Collections.Generic;
/**
 * 
 * name         :   ProfileViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for player evaluation skill
    /// </summary>
    public class ProfileViewModel
    {
        public string PlayerSRU { get; set; }
        public int SkillId { get; set; }
        //Properties
        public string Description { get; set; }
        public int Score { get; set; }
        
        
        public  SkillViewModel Skill { get; set; }
        public  PlayerViewModel Player { get; set; }
        
        
    }
}