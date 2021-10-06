using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.Models;
/**
 * 
 * name         :   JuniorViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for junior player
    /// </summary>
    [Serializable]
    public class JuniorViewModel
    {
        public JuniorViewModel()
        {
            Guardians = new List<GuardianViewModel>();
        }

        public List<GuardianViewModel> Guardians { get; set; }

        


    }
}
