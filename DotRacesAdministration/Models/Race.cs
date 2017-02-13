using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotRacesAdministration.Models
{
    [Table("dotraces_Races")]
    public class Race
    {
        public int RaceID { get; set; }
        [Display(Name ="Race Number")]
        public int RaceNum { get; set; }
        [Display(Name ="Duration (seconds)")]
        public int Duration { get; set; }
        [Display(Name ="Winner")]
        public bool Winner { get; set; }
        [Display(Name="Setting Set")]
        public int SettingSetID { get; set; }
        
        [Display(Name="Stage 1")]
        public double Difference1 { get; set; }
        [Display(Name = "Stage 2")]
        public double Difference2 { get; set; }
        [Display(Name = "Stage 3")]
        public double Difference3 { get; set; }
        [Display(Name = "Stage 4")]
        public double Difference4 { get; set; }
        [Display(Name = "Stage 5")]
        public double Difference5 { get; set; }
        [Display(Name = "Stage 6")]
        public double Difference6 { get; set; }
        [Display(Name = "Stage 7")]
        public double Difference7 { get; set; }
        [Display(Name = "Stage 8")]
        public double Difference8 { get; set; }
        [Display(Name = "Stage 9")]
        public double Difference9 { get; set; }
        [Display(Name = "Stage 10")]
        public double Difference10 { get; set; }
        [Display(Name = "Stage 11")]
        public double Difference11 { get; set; }
        [Display(Name = "Stage 12")]
        public double Difference12 { get; set; }
        [Display(Name = "Stage 13")]
        public double Difference13 { get; set; }
        [Display(Name = "Stage 14")]
        public double Difference14 { get; set; }
        [Display(Name = "Stage 15")]
        public double Difference15 { get; set; }
        [Display(Name = "Stage 16")]
        public double Difference16 { get; set; }

        [Display(Name = "Difference 1")]
        public double? OtherDifference1 { get; set; }
        [Display(Name = "Difference 2")]
        public double? OtherDifference2 { get; set; }
        [Display(Name = "Difference 3")]
        public double? OtherDifference3 { get; set; }
        [Display(Name = "Difference 4")]
        public double? OtherDifference4 { get; set; }
        [Display(Name = "Difference 5")]
        public double? OtherDifference5 { get; set; }
        [Display(Name = "Difference 6")]
        public double? OtherDifference6 { get; set; }
        [Display(Name = "Difference 7")]
        public double? OtherDifference7 { get; set; }
        [Display(Name = "Difference 8")]
        public double? OtherDifference8 { get; set; }
        [Display(Name = "Difference 9")]
        public double? OtherDifference9 { get; set; }
        [Display(Name = "Difference 10")]
        public double? OtherDifference10 { get; set; }
        [Display(Name = "Difference 11")]
        public double? OtherDifference11 { get; set; }
        [Display(Name = "Difference 12")]
        public double? OtherDifference12 { get; set; }
        [Display(Name = "Difference 13")]
        public double? OtherDifference13 { get; set; }
        [Display(Name = "Difference 14")]
        public double? OtherDifference14 { get; set; }
        [Display(Name = "Difference 15")]
        public double? OtherDifference15 { get; set; }
        [Display(Name = "Difference 16")]
        public double? OtherDifference16 { get; set; }

        public int? Sound1ID { get; set; }
        public int? Sound2ID { get; set; }
        public int? Sound3ID { get; set; }
        public int? Sound4ID { get; set; }
        public int? Sound5ID { get; set; }
        public int? Sound6ID { get; set; }
        public int? Sound7ID { get; set; }
        public int? Sound8ID { get; set; }
        public int? Sound9ID { get; set; }
        public int? Sound10ID { get; set; }
        public int? Sound11ID { get; set; }
        public int? Sound12ID { get; set; }
        public int? Sound13ID { get; set; }
        public int? Sound14ID { get; set; }
        public int? Sound15ID { get; set; }
        public int? Sound16ID { get; set; }
    }
}
