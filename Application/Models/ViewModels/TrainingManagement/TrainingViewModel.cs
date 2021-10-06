using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Application.Data.Models;
using Newtonsoft.Json;
/**
 * 
 * name         :   TrainingViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for training 
    /// </summary>
    public class TrainingViewModel
    {
        public TrainingViewModel()
        {
            Date = DateTime.Now;
            Time = DateTime.Now;
        }
        public int? Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time { get; set; }
        public string Location { get; set; }
        [Required]
        [Display(Name = "Coach")]
        public string CoachSRU { get; set; }
        public MemberViewModel Coach { get; set; }
        public List<ActivitiesViewModel> Activities { get; set; }
        public string[] Attended { get; set; }
        public List<MemberViewModel> Attendance { get; set; }
    }
}