using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
/**
 * 
 * name         :   Training.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for training
    /// </summary>
    public class Training
    {
        //Primary
        public int Id { get; set; }

//Properties
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }

        public string CoachSRU { get; set; }

//Relations
        public virtual Member Coach { get; set; }
        public virtual List<Activities> Activities { get; set; }
    }
}