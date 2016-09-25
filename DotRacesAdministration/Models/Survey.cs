using System;
using System.Collections.Generic;
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
        public DateTime CreatedDate { get; set; }
        public int IdentityCode { get; set; }
        public int SettingsID { get; set; }

        public int? PointTotal { get; set; }
        public bool? ChoseToBetFlag { get; set; }
        List<Answer> FirstAnswers { get; set; }
        List<Answer> SecondAnswers { get; set; }
        List<Answer> EndAnswers { get; set; }

        public Survey()
        {
            FirstAnswers = new List<Answer>();
            SecondAnswers = new List<Answer>();
            EndAnswers = new List<Answer>();
        }

    }
}
