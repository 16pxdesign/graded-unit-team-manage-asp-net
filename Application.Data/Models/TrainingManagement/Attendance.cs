/**
 * 
 * name         :   Attendance.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for training attendance
    /// </summary>
    public class Attendance
    {
        //Primary
        public string Id { get; set; }
        //Properties
        public int TrainingId { get; set; }
        public string PlayerSRU { get; set; }
        //Relations
        public virtual Training Training { get; set; }
        public virtual Player Player { get; set; }
    }
}