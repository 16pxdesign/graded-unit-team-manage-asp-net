using System;
/**
 * 
 * name         :   Address.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for address
    /// </summary>
    public class Address
    {
        //Primary
        public int Id { get; set; }

        //Properties
        public string Flat { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
  
        //Relations
    }
}