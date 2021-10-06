using System.ComponentModel.DataAnnotations;
/**
 * 
 * name         :   ActivitiesViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for training activity
    /// </summary>
    public class ActivitiesViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}