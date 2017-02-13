using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotRacesAdministration.Models
{
    [Table("dotraces_SettingSets")]
    public class SettingSet
    {
        [Display(Name="ID")]
        public int SettingSetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name="Current Default")]
        public bool? DefaultSetFlag { get; set; }
        [Display(Name="Potential High Score")]
        public int PotentialHighScore { get; set; }
        [Display(Name = "Potential Low Score")]
        public int PotentialLowScore { get; set; }
        [Display(Name = "Points Per Round")]
        public int PointsPerRound { get; set; }
        [Display(Name ="Number of Races")]
        public int NumberOfRaces { get; set; }
        [Display(Name ="Number Text (i.e. five)")]
        public string NumberOfRacesText { get; set; }
        [Display(Name ="Number Adjective (i.e. fifth)")]
        public string NumberOfRacesAdjective { get; set; }
        [Display(Name = "Final Multiplier")]
        public int LastRaceMultiplier { get; set; }

    }
}
