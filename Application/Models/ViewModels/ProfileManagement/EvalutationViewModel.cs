using System.Collections.Generic;
/**
 * 
 * name         :   EvalutationViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for player evaluation
    /// </summary>
    public class EvalutationViewModel
    {
        public string id { get; set; }
        public MemberShortViewModel Player { get; set; }
        public List<SkillViewModel> Categories { get; set; }
        public List<SkillViewModel> Skills { get; set; }
        public List<ProfileViewModel> Scores { get; set; }
    }
}