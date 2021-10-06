using System.Collections.Generic;
/**
 * 
 * name         :   Junior.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for junior player
    /// </summary>
    public class Junior
    {
        //Primary
        public string SRU { get; set; }

        //Properties


        //Relations
        public virtual Player Player { get; set; }
        public virtual List<Guardian> Guardians { get; set; }
    }
}