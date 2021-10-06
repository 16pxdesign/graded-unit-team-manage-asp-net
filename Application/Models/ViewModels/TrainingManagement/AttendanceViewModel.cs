/**
 * 
 * name         :   AttendanceViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for training attendance
    /// </summary>
    public class AttendanceViewModel
    {
        public virtual TrainingViewModel Training { get; set; }
        public virtual PlayerViewModel Player { get; set; }
    }
}