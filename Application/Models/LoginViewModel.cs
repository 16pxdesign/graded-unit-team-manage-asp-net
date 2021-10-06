using System.ComponentModel.DataAnnotations;
/**
 * 
 * name         :   LoginViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for login password
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
    }
}