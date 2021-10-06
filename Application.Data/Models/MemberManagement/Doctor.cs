/**
 * 
 * name         :   Doctor.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for player doctor
    /// </summary>
    public class Doctor
    {
        //Primary
        public int Id { get; set; }

        //Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        
        public string PlayerSRU { get; set; }
        public int AddressId { get; set; }
        //Relations
        public virtual Address Address { get; set; }
        public virtual Player Player { get; set; }
        
        }
}