using System;
using System.ComponentModel.DataAnnotations;
using Application.Data.Models;
/**
 * 
 * name         :   ScoreViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    /// This class representing view model for game score
    /// </summary>
    public class ScoreViewModel
    {
      

        public int Id { get; set; }
        //Properties
        public GameHalf Half { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time { get; set; }
        [Range(1, 5)]
        public int Points { get; set; }
        public GameTeam Team { get; set; }
        public string Comment { get; set; }
    }
}