using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.Models;
/**
 * 
 * name         :   PlayerViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for player
    /// </summary>
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            Position = null;
            HealthIssues = new List<HealthIssueViewModel>();
            Junior = new JuniorViewModel();
        }
        [Display(Name = "Player Position")]
        public PlayerPosition? Position { get; set; }
        public DoctorViewModel Doctor { get; set; }
        [Display(Name = "Health Issues")]
        public List<HealthIssueViewModel> HealthIssues { get; set; }
        public virtual JuniorViewModel Junior { get; set; }
        public virtual SeniorViewModel Senior { get; set; }

    }
}
