using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotRacesAdministration.Models
{
    public class CSVViewModel
    {
        public DateTime TimeStamp { get; set; }
        public int ID_Code { get; set; }
        public int TimeRules { get; set; }
        public int Race1Winner { get; set; }
        public int Race2Winner { get; set; }
        public int Race3Winner { get; set; }
        public int Race4Winner { get; set; }
        public int Race5Winner { get; set; }
        public int Race6Winner { get; set; }
        public int Bet { get; set;}
        public int Hopeful1 { get; set; }
        public int Worried1 { get; set; }
        public int Happy1 { get; set; }
        public int Sad1 { get; set; }
        public int Relieved1 { get; set; }
        public int Disappointed1 { get; set; }
        public int Amused1 { get; set; }
        public int Angry1 { get; set; }
        public int Contented1 { get; set; }
        public int Disgusted1 { get; set; }
        public int Race7Winner { get; set; }
        public int Hopeful2 { get; set; }
        public int Worried2 { get; set; }
        public int Happy2 { get; set; }
        public int Sad2 { get; set; }
        public int Relieved2 { get; set; }
        public int Disappointed2 { get; set; }
        public int Amused2 { get; set; }
        public int Angry2 { get; set; }
        public int Contented2 { get; set; }
        public int Disgusted2 { get; set; }
        public int Enjoy1 { get; set; }
        public int Enjoy2 { get; set; }
        public int Enjoy3 { get; set; }
        public int Enjoy4 { get; set; }
        public int UOIdentity1 { get; set; }
        public int UOIdentity2 { get; set; }
        public int UOIdentity3 { get; set; }
        public int UOIdentity4 { get; set; }
        public int OSUIdentity1 { get; set; }
        public int OSUIdentity2 { get; set; }
        public int OSUIdentity3 { get; set; }
        public int OSUIdentity4 { get; set; }
        public int Involved { get; set; }
        public int Exciting { get; set; }

        public string ID_CodeDesc { get; set; }
        public string TimeRulesDesc { get; set; }
        public string Race1WinnerDesc { get; set; }
        public string Race2WinnerDesc { get; set; }
        public string Race3WinnerDesc { get; set; }
        public string Race4WinnerDesc { get; set; }
        public string Race5WinnerDesc { get; set; }
        public string Race6WinnerDesc { get; set; }
        public string BetDesc { get; set; }
        public string Hopeful1Desc { get; set; }
        public string Worried1Desc { get; set; }
        public string Happy1Desc { get; set; }
        public string Sad1Desc { get; set; }
        public string Relieved1Desc { get; set; }
        public string Disappointed1Desc { get; set; }
        public string Amused1Desc { get; set; }
        public string Angry1Desc { get; set; }
        public string Contented1Desc { get; set; }
        public string Disgusted1Desc { get; set; }
        public string Race7WinnerDesc { get; set; }
        public string Hopeful2Desc { get; set; }
        public string Worried2Desc { get; set; }
        public string Happy2Desc { get; set; }
        public string Sad2Desc { get; set; }
        public string Relieved2Desc { get; set; }
        public string Disappointed2Desc { get; set; }
        public string Amused2Desc { get; set; }
        public string Angry2Desc { get; set; }
        public string Contented2Desc { get; set; }
        public string Disgusted2Desc { get; set; }
        public string Enjoy1Desc { get; set; }
        public string Enjoy2Desc { get; set; }
        public string Enjoy3Desc { get; set; }
        public string Enjoy4Desc { get; set; }
        public string UOIdentity1Desc { get; set; }
        public string UOIdentity2Desc { get; set; }
        public string UOIdentity3Desc { get; set; }
        public string UOIdentity4Desc { get; set; }
        public string OSUIdentity1Desc { get; set; }
        public string OSUIdentity2Desc { get; set; }
        public string OSUIdentity3Desc { get; set; }
        public string OSUIdentity4Desc { get; set; }
        public string InvolvedDesc { get; set; }
        public string ExcitingDesc { get; set; }

        public CSVViewModel()
        {
            ID_CodeDesc = "4 Digits";
            TimeRulesDesc = "Seconds";
            Race1WinnerDesc = "0=OSU; 1=UO";
            Race2WinnerDesc = "0=OSU; 1=UO";
            Race3WinnerDesc = "0=OSU; 1=UO";
            Race4WinnerDesc = "0=OSU; 1=UO";
            Race5WinnerDesc = "0=OSU; 1=UO";
            Race6WinnerDesc = "0=OSU; 1=UO";
            BetDesc = "0=No; 1=Yes";
            Hopeful1Desc = "Scale 0-7";
            Worried1Desc = "Scale 0-7";
            Happy1Desc = "Scale 0-7";
            Sad1Desc = "Scale 0-7";
            Relieved1Desc = "Scale 0-7";
            Disappointed1Desc = "Scale 0-7";
            Amused1Desc = "Scale 0-7";
            Angry1Desc = "Scale 0-7";
            Contented1Desc = "Scale 0-7";
            Disgusted1Desc = "Scale 0-7";
            Race7WinnerDesc = "0=OSU; 1=UO";
            Hopeful2Desc = "Scale 0-7";
            Worried2Desc = "Scale 0-7";
            Happy2Desc = "Scale 0-7";
            Sad2Desc = "Scale 0-7";
            Relieved2Desc = "Scale 0-7";
            Disappointed2Desc = "Scale 0-7";
            Amused2Desc = "Scale 0-7";
            Angry2Desc = "Scale 0-7";
            Contented2Desc = "Scale 0-7";
            Disgusted2Desc = "Scale 0-7";
            Enjoy1Desc = "Scale 1-7";
            Enjoy2Desc = "Scale 1-7";
            Enjoy3Desc = "Scale 1-7";
            Enjoy4Desc = "Scale 1-7";
            UOIdentity1Desc = "Scale 1-7";
            UOIdentity2Desc = "Scale 1-7";
            UOIdentity3Desc = "Scale 1-7";
            UOIdentity4Desc = "Scale 1-7";
            OSUIdentity1Desc = "Scale 1-7";
            OSUIdentity2Desc = "Scale 1-7";
            OSUIdentity3Desc = "Scale 1-7";
            OSUIdentity4Desc = "Scale 1-7";
            InvolvedDesc = "Scale 1-7";
            ExcitingDesc = "Scale 1-7";
        }
    }
}