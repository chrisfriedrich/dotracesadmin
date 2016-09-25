﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotRacesAdministration.Models
{
    [Table("dotraces_SettingSets")]
    public class SettingSet
    {
        public int SettingSetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? DefaultSetFlag { get; set; }

        public int PotentialHighScore { get; set; }
        public int PotentialLowScore { get; set; }
        public int PointsPerRound { get; set; }

        public int NumberOfRaces { get; set; }
        public string NumberOfRacesText { get; set; }
        public string NumberOfRacesAdjective { get; set; }

        public int LastRaceMultiplier { get; set; }

        public List<Race> Races { get; set; }
        public List<Question> FirstQuestions { get; set; }
        public List<Question> SecondQuestions { get; set; }
        public List<Question> EndQuestions { get; set; }

        public SettingSet()
        {
            Races = new List<Race>();
            FirstQuestions = new List<Question>();
            SecondQuestions = new List<Question>();
            EndQuestions = new List<Question>();
        }
    }
}
