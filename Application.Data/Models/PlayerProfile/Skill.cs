/**
 * 
 * name         :   Skill.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for player evaluation skill
    /// </summary>
    public class Skill
    {
        //Primary
        public int Id { get; set; }
        //Properties
        public string Name { get; set; }
        public SkillType Type { get; set; }
        public int? ParentId { get; set; }
        //Relations
        public virtual Skill Parent { get; set; }
    }
}