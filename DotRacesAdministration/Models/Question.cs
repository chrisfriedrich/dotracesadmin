using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DotRacesAdministration.Models
{
    [Table("dotraces_Questions")]
    public class Question
    {
        public int SettingSetID { get; set; }
        public int QuestionID { get; set; }
        [AllowHtml]
        [Display(Name ="Question Text")]
        public string QuestionText { get; set; }
        [Display(Name = "Has Follow-Up Question")]
        public bool HasFollowUp { get; set; }
        [Display(Name = "Follow-Up Text")]
        public string FollowUpText { get; set; }
        [Display(Name = "Feeling Noun (i.e. happy)")]
        public string FeelingNoun { get; set; }
        [Display(Name = "Low Scale (i.e. slightly)")]
        public string LowScaleDescription { get; set; }
        [Display(Name = "High Scale (i.e. extremely)")]
        public string HighScaleDescription { get; set; }
        public bool? AskedFlag { get; set; }
        public bool? CurrentQuestionFlag { get; set; }
        [Display(Name = "Question Round Number")]
        public int? QuestionRoundNum { get; set; }
        [Display(Name = "Group Question")]
        public bool? FinalGroupQuestion { get; set; }
        [Display(Name = "Group Question Order")]
        public int? GroupQuestionNumber { get; set; } 
    }
}
