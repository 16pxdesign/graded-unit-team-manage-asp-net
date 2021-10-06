using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Application.Data.Models;
/**
 * 
 * name         :   SkillViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for player skill
    /// </summary>
    public class SkillViewModel
    {
        public int Id { get; set; }
        //Properties
        [Required]
        public string Name { get; set; }
        [DisplayName("Type")]
        public SkillType Type { get; set; }
        [DisplayName("Category")]
        public int? ParentId { get; set; }
        public SkillViewModel Parent { get; set; }
        public List<SkillViewModel> Categories { get; set; }

    }
}