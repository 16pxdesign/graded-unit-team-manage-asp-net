/**
 * 
 * name         :   PlayerPosition.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models.MemberManagement
{
    /// <summary>
    /// This class representing model for player pitch position
    /// </summary>
    public class PlayerPosition
    {
        //Primary
        public int Id { get; set; }

        //Properties
        public string Name { get; set; }
        public int Number { get; set; }

        //Relations
    }
}
