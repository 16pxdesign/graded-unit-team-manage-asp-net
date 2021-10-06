using System.ComponentModel.DataAnnotations;

/**
 * 
 * name         :   PlayerPosition.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Data.Models
{
    /// <summary>
    /// the enum class represents type of position on the pitch
    /// </summary>
    public enum PlayerPosition
    {
        [Display(Name = "Loose-head prop")]
        Loosehead,
        Hooker,
        [Display(Name = "Tight-head prop")]
        TightheadProp,
        [Display(Name = "Second row")]
        Second,
        [Display(Name = "Blind-side flanker")]
        Blindside,
        [Display(Name = "Open-side flanker")]
        openside,
        [Display(Name = "Number 8")]
        nr8,
        [Display(Name = "Scrum-help")]
        scrum,
        [Display(Name = "Fly-half")]
        fly,
        [Display(Name = "Left wing")]
        leftwing,
        [Display(Name = "Inside centre")]
        inside,
        [Display(Name = "Outside centre")]
        outside,
        [Display(Name = "Right wing")]
        rightwing,
        [Display(Name = "Full-back")]
        fullback


    }
}