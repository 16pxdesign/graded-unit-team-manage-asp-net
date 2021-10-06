using System;
using System.ComponentModel.DataAnnotations;
/**
 * 
 * name         :   HealthIssue.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for player health issue
    /// </summary>
    public class HealthIssue
    {
        //Primary
        public int Id { get; set; }
        //Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string PlayerSRU { get; set; }

        //Relations
        public virtual Player Player { get; set; }

    }
}