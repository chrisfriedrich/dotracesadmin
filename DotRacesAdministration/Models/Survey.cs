using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotRacesAdministration.Models
{
    [Table("dotraces_Surveys")]
    public class Survey
    {
        public int SurveyID { get; set; }
        [Display(Name="Created")]
        public DateTime CreatedDate { get; set; }
        [Display(Name ="Identity Code")]
        public int? IdentityCode { get; set; }
        [Display(Name ="Setting Set")]
        public int SettingsID { get; set; }
        [Display(Name ="Point Total")]
        public int? PointTotal { get; set; }
        [Display(Name ="Chose to Bet")]
        public bool? ChoseToBetFlag { get; set; }

        public int? OSUWins { get; set; }
        public int? UOWins { get; set; }
    }
}
