using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/**
 * 
 * name         :   AddressViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for address
    /// </summary>
    public class AddressViewModel
    {
        [Required]
        public string Flat { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string City { get; set; }

    }
}
