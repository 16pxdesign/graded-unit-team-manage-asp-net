/**
 * 
 * name         :   MemberShortViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for member
    /// </summary>
    public class MemberShortViewModel
    {
        
        public string SRU { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname => string.Concat(Name, " ", Surname);

    }
}