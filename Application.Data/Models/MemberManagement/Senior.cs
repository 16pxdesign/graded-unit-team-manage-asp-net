/**
 * 
 * name         :   Senior.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// This class representing model for senior player
    /// </summary>
    public class Senior
    {
        //Primary
        public string SRU { get; set; }

        //Properties


        //Relations
        public virtual Player Player { get; set; }
        public virtual Kin Kin { get; set; }
        
    }
}