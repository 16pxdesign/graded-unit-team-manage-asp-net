using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Application.Data.Models;
/**
 * 
 * name         :   GameViewModel.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Models
{
    /// <summary>
    ///This class representing view model for game
    /// </summary>
    public class GameViewModel
    {
        public GameViewModel()
        {
            Date = DateTime.Today;
        }

        public int Id { get; set; }

        //Properties
        [Required]
        [Display(Name = "Opposition team")]
        public string Opposition { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Kick off")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime KO { get; set; }
        [Required]
        public GameLocation Location { get; set; }
        public GameResult Result { get; set; }

        //Relations
        public List<ScoreViewModel> Scores { get; set; }

        public int? OppositionPoints
        {
            get
            {
                var points = 0;
                if(Scores!= null && Scores.Any(x => x.Team == GameTeam.Opposition)) points = Scores.Where(x => x.Team == GameTeam.Opposition).Aggregate(points, (current, score) => current + score.Points);
                return points;
            }
        }
        
        public int? SimpleRugbyPoints
        {
            get
            {
                var points = 0;
                if(Scores!= null && Scores.Any(x => x.Team == GameTeam.SimpleRugby)) points = Scores.Where(x => x.Team == GameTeam.SimpleRugby).Aggregate(points, (current, score) => current + score.Points);

                return points;
            }
        }

    }
}