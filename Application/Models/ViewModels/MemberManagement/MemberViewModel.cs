using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.Models;
/**
 * 
 * name         :   MemberViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for member
    /// </summary>
    public class MemberViewModel
    {
        public MemberViewModel()
        {
            Player = new PlayerViewModel();
        }

        [Required]
        public string SRU { get; set; }
        [Display(Name = "Member Type")]
        public MemberType Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)] 
        [EmailAddress] 
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)] 
        [Phone] 
        public string Phone { get; set; }
        [DataType(DataType.PhoneNumber)] 
        [Phone] 
        public string Mobile { get; set; }
        public AddressViewModel Address { get; set; }
        public virtual PlayerViewModel Player { get; set; }

        public string Fullname => string.Concat(Name, " ", Surname);
    }
}
