﻿using DotRacesAdministration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotRacesAdministration.DAL
{
    class DotRacesDataContext : DbContext
    {
        public DotRacesDataContext() : base("DotRacesDataContext")
        {

        }

        public DbSet<Separator> Separators { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<OSUAnswer> OSUAnswers { get; set; }
        public DbSet<SettingSet> SettingSets { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<OSUSurvey> OSUSurveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Race> Races { get; set; }
    }
}
