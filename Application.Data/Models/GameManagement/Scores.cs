using System;
/**
 * 
 * name         :   Scores.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for game score
    /// </summary>
    public class Scores
    {
        //Primary
        public int Id { get; set; }
        //Properties
        public GameHalf Half { get; set; }
        public DateTime Time { get; set; }
        public int Points { get; set; }
        public GameTeam Team { get; set; }
        public string Comment { get; set; }
        //Relations
        public virtual int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}