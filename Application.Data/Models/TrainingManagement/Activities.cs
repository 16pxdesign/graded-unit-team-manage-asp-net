/**
 * 
 * name         :   Activities.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for training activity
    /// </summary>
    public class Activities
    {
        //Primary
        public int Id { get; set; }

        //Properties
        public string Name { get; set; }
        public int TrainingId { get; set; }

        //Relations
        public virtual Training Training { get; set; }
    }
}