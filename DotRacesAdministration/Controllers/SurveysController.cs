using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotRacesAdministration.DAL;
using DotRacesAdministration.Models;
using System.IO;
using System.Text;

namespace DotRacesAdministration.Controllers
{
    [Authorize]
    public class SurveysController : Controller
    {
        private DotRacesDataContext db = new DotRacesDataContext();

        // GET: Surveys
        public ActionResult Index()
        {
            ViewData["Questions"] = db.Questions.ToList();
            ViewData["Answers"] = db.Answers.ToList();
            ViewData["Settings"] = db.SettingSets.ToList();
            return View(db.Surveys.OrderByDescending(x => x.CreatedDate).ToList());
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurveyID,CreatedDate,IdentityCode,SettingsID,PointTotal,ChoseToBetFlag")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurveyID,CreatedDate,IdentityCode,SettingsID,PointTotal,ChoseToBetFlag")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Surveys/Delete/5
        public ActionResult DeleteAll()
        {
            return View();
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllConfirmed()
        {

            foreach (Survey survey in db.Surveys)
            {
                db.Surveys.Remove(survey);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult DownloadCSV()
        {
            CSVViewModel model = new CSVViewModel();

            List<Survey> surveyList = db.Surveys.ToList();
            List<SettingSet> settingList = db.SettingSets.ToList();
            List<Race> raceList = db.Races.ToList();

            List<Answer> answerList = db.Answers.ToList();
            List<Question> questionList = db.Questions.ToList();

            var sw = new StringBuilder();

            // Write the header

            sw.AppendLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44}",
                                        "Timestamp", "ID_Code", "TimeRules", "Race1Winner", "Race2Winner", "Race3Winner",
                                        "Race4Winner", "Race5Winner", "Race6Winner", "Bet", "Hopeful1", "Worried1",
                                        "Happy1", "Sad1", "Relieved1", "Disappointed1", "Amused1", "Angry1", "Contented1",
                                        "Disgusted1", "Race7Winner", "Hopeful2", "Worried2", "Happy2", "Sad2", "Relieved2",
                                        "Disappointed2", "Amused2", "Angry2", "Contented2", "Disgusted2", "Enjoy1", "Enjoy2",
                                        "Enjoy3", "Enjoy4", "OSUIdentity1", "OSUIdentity2", "OSUIdentity3", "OSUIdentity4", 
                                        "UOIdentity1", "UOIdentity2", "UOIdentity3", "UOIdentity4", "Involved", "Exciting"
                                        ));

            sw.AppendLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44}",
                                        "", "4 Digits", "Seconds", "0=OSU; 1=UO", "0=OSU; 1=UO", "0=OSU; 1=UO",
                                        "0=OSU; 1=UO", "0=OSU; 1=UO", "0=OSU; 1=UO", "0=No; 1=Yes", "Scale 0-7", "Scale 0-7",
                                        "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 0-7",
                                        "Scale 0-7", "0=OSU; 1=UO", "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 0-7",
                                        "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 0-7", "Scale 1-7", "Scale 1-7",
                                        "Scale 1-7", "Scale 1-7", "Scale 1-7", "Scale 1-7", "Scale 1-7", "Scale 1-7",
                                        "Scale 1-7", "Scale 1-7", "Scale 1-7", "Scale 1-7", "Scale 1-7", "Scale 1-7"
                                        ));

            foreach (Survey survey in surveyList.OrderBy(x => x.SettingsID).ThenByDescending(x => x.CreatedDate))
            {
                SettingSet settings = settingList.Find(x => x.SettingSetID == survey.SettingsID);
                List<Race> races = raceList.Where(x => x.SettingSetID == settings.SettingSetID).OrderBy(x => x.RaceNum).ToList();

                List<Answer> answers = answerList.Where(x => x.SurveyID == survey.SurveyID).ToList();
                List<Question> questions = questionList.Where(x => x.SettingSetID == settings.SettingSetID).ToList();

                CSVViewModel line = new CSVViewModel();

                line.TimeStamp = survey.CreatedDate.ToLocalTime();
                line.ID_Code = (int)survey.IdentityCode;
                line.TimeRules = 60;

                if (races.FirstOrDefault(x => x.RaceNum == 1).Winner)
                {
                    line.Race1Winner = 1;
                }
                else
                {
                    line.Race1Winner = 0;
                }

                if (races.FirstOrDefault(x => x.RaceNum == 2).Winner)
                {
                    line.Race2Winner = 1;
                }
                else
                {
                    line.Race2Winner = 0;
                }

                if (races.FirstOrDefault(x => x.RaceNum == 3).Winner)
                {
                    line.Race3Winner = 1;
                }
                else
                {
                    line.Race3Winner = 0;
                }

                if (races.FirstOrDefault(x => x.RaceNum == 4).Winner)
                {
                    line.Race4Winner = 1;
                }
                else
                {
                    line.Race4Winner = 0;
                }

                if (races.FirstOrDefault(x => x.RaceNum == 5).Winner)
                {
                    line.Race5Winner = 1;
                }
                else
                {
                    line.Race5Winner = 0;
                }

                if (races.FirstOrDefault(x => x.RaceNum == 6).Winner)
                {
                    line.Race6Winner = 1;
                }
                else
                {
                    line.Race6Winner = 0;
                }

                if (survey.ChoseToBetFlag == true)
                {
                    line.Bet = 1;
                }
                else
                {
                    line.Bet = 0;
                }

                Question hopeful1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "hopeful");
                Answer hopeful1Ans = answers.Find(x => x.QuestionID == hopeful1.QuestionID);
                if (hopeful1Ans != null)
                {
                    if (hopeful1Ans.AnswerFlag == false)
                    {
                        line.Hopeful1 = 0;
                    }
                    else
                    {
                        line.Hopeful1 = (int)hopeful1Ans.AnswerValue;
                    }
                }

                Question worried1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "worried");
                Answer worried1Ans = answers.Find(x => x.QuestionID == worried1.QuestionID);
                if (worried1Ans != null)
                {
                    if (worried1Ans.AnswerFlag == false)
                    {
                        line.Worried1 = 0;
                    }
                    else
                    {
                        line.Worried1 = (int)worried1Ans.AnswerValue;
                    }
                }

                Question happy1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "happy");
                Answer happy1Ans = answers.Find(x => x.QuestionID == happy1.QuestionID);
                if (happy1Ans != null)
                {
                    if (happy1Ans.AnswerFlag == false)
                    {
                        line.Happy1 = 0;
                    }
                    else
                    {
                        line.Happy1 = (int)happy1Ans.AnswerValue;
                    }
                }

                Question sad1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "sad");
                Answer sad1Ans = answers.Find(x => x.QuestionID == sad1.QuestionID);
                if (sad1Ans != null)
                {
                    if (sad1Ans.AnswerFlag == false)
                    {
                        line.Sad1 = 0;
                    }
                    else
                    {
                        line.Sad1 = (int)sad1Ans.AnswerValue;
                    }
                }

                Question relieved1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "relieved");
                Answer relieved1Ans = answers.Find(x => x.QuestionID == relieved1.QuestionID);
                if (relieved1Ans != null)
                {
                    if (relieved1Ans.AnswerFlag == false)
                    {
                        line.Relieved1 = 0;
                    }
                    else
                    {
                        line.Relieved1 = (int)relieved1Ans.AnswerValue;
                    }
                }

                Question disappointed1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "disappointed");
                Answer disappointed1Ans = answers.Find(x => x.QuestionID == disappointed1.QuestionID);
                if (disappointed1Ans != null)
                {
                    if (disappointed1Ans.AnswerFlag == false)
                    {
                        line.Disappointed1 = 0;
                    }
                    else
                    {
                        line.Disappointed1 = (int)disappointed1Ans.AnswerValue;
                    }
                }

                Question amused1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "amused");
                Answer amused1Ans = answers.Find(x => x.QuestionID == amused1.QuestionID);
                if (amused1Ans != null)
                {
                    if (amused1Ans.AnswerFlag == false)
                    {
                        line.Amused1 = 0;
                    }
                    else
                    {
                        line.Amused1 = (int)amused1Ans.AnswerValue;
                    }
                }

                Question angry1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "angry");
                Answer angry1Ans = answers.Find(x => x.QuestionID == angry1.QuestionID);
                if (angry1Ans != null)
                {
                    if (angry1Ans.AnswerFlag == false)
                    {
                        line.Angry1 = 0;
                    }
                    else
                    {
                        line.Angry1 = (int)angry1Ans.AnswerValue;
                    }
                }

                Question contented1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "contented");
                Answer contented1Ans = answers.Find(x => x.QuestionID == contented1.QuestionID);
                if (contented1Ans != null)
                {
                    if (contented1Ans.AnswerFlag == false)
                    {
                        line.Contented1 = 0;
                    }
                    else
                    {
                        line.Contented1 = (int)contented1Ans.AnswerValue;
                    }
                }

                Question disgusted1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 1 && x.FeelingNoun == "disgusted");
                Answer disgusted1Ans = answers.Find(x => x.QuestionID == disgusted1.QuestionID);
                if (disgusted1Ans != null)
                {
                    if (disgusted1Ans.AnswerFlag == false)
                    {
                        line.Disgusted1 = 0;
                    }
                    else
                    {
                        line.Disgusted1 = (int)disgusted1Ans.AnswerValue;
                    }
                }

                if (races.FirstOrDefault(x => x.RaceNum == 7).Winner)
                {
                    line.Race7Winner = 1;
                }
                else
                {
                    line.Race7Winner = 0;
                }

                Question hopeful2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "hopeful");
                Answer hopeful2Ans = answers.Find(x => x.QuestionID == hopeful2.QuestionID);
                if (hopeful2Ans != null)
                {
                    if (hopeful2Ans.AnswerFlag == false)
                    {
                        line.Hopeful2 = 0;
                    }
                    else
                    {
                        line.Hopeful2 = (int)hopeful2Ans.AnswerValue;
                    }
                }

                Question worried2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "worried");
                Answer worried2Ans = answers.Find(x => x.QuestionID == worried2.QuestionID);
                if (worried2Ans != null)
                {
                    if (worried2Ans.AnswerFlag == false)
                    {
                        line.Worried2 = 0;
                    }
                    else
                    {
                        line.Worried2 = (int)worried2Ans.AnswerValue;
                    }
                }

                Question happy2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "happy");
                Answer happy2Ans = answers.Find(x => x.QuestionID == happy2.QuestionID);
                if (happy2Ans != null)
                {
                    if (happy2Ans.AnswerFlag == false)
                    {
                        line.Happy2 = 0;
                    }
                    else
                    {
                        line.Happy2 = (int)happy2Ans.AnswerValue;
                    }
                }

                Question sad2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "sad");
                Answer sad2Ans = answers.Find(x => x.QuestionID == sad2.QuestionID);
                if (sad2Ans != null)
                {
                    if (sad2Ans.AnswerFlag == false)
                    {
                        line.Sad2 = 0;
                    }
                    else
                    {
                        line.Sad2 = (int)sad2Ans.AnswerValue;
                    }
                }

                Question relieved2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "relieved");
                Answer relieved2Ans = answers.Find(x => x.QuestionID == relieved2.QuestionID);
                if (relieved2Ans != null)
                {
                    if (relieved2Ans.AnswerFlag == false)
                    {
                        line.Relieved2 = 0;
                    }
                    else
                    {
                        line.Relieved2 = (int)relieved2Ans.AnswerValue;
                    }
                }

                Question disappointed2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "disappointed");
                Answer disappointed2Ans = answers.Find(x => x.QuestionID == disappointed2.QuestionID);
                if (disappointed2Ans != null)
                {
                    if (disappointed2Ans.AnswerFlag == false)
                    {
                        line.Disappointed2 = 0;
                    }
                    else
                    {
                        line.Disappointed2 = (int)disappointed2Ans.AnswerValue;
                    }
                }

                Question amused2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "amused");
                Answer amused2Ans = answers.Find(x => x.QuestionID == amused2.QuestionID);
                if (amused2Ans != null)
                {
                    if (amused2Ans.AnswerFlag == false)
                    {
                        line.Amused2 = 0;
                    }
                    else
                    {
                        line.Amused2 = (int)amused2Ans.AnswerValue;
                    }
                }

                Question angry2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "angry");
                Answer angry2Ans = answers.Find(x => x.QuestionID == angry2.QuestionID);
                if (angry2Ans != null)
                {
                    if (angry2Ans.AnswerFlag == false)
                    {
                        line.Angry2 = 0;
                    }
                    else
                    {
                        line.Angry2 = (int)angry2Ans.AnswerValue;
                    }
                }

                Question contented2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "contented");
                Answer contented2Ans = answers.Find(x => x.QuestionID == contented2.QuestionID);
                if (contented2Ans != null)
                {
                    if (contented2Ans.AnswerFlag == false)
                    {
                        line.Contented2 = 0;
                    }
                    else
                    {
                        line.Contented2 = (int)contented2Ans.AnswerValue;
                    }
                }

                Question disgusted2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 2 && x.FeelingNoun == "disgusted");
                Answer disgusted2Ans = answers.Find(x => x.QuestionID == disgusted2.QuestionID);
                if (disgusted2Ans != null)
                {
                    if (disgusted2Ans.AnswerFlag == false)
                    {
                        line.Disgusted2 = 0;
                    }
                    else
                    {
                        line.Disgusted2 = (int)disgusted2Ans.AnswerValue;
                    }
                }

                Question entertaining = questions.FirstOrDefault(x => x.QuestionRoundNum == 3 && x.FeelingNoun == "entertaining");
                Answer entertainingAns = answers.Find(x => x.QuestionID == entertaining.QuestionID);
                if (entertainingAns != null)
                {
                    line.Enjoy1 = (int)entertainingAns.AnswerValue;
                }

                Question funToWatch = questions.FirstOrDefault(x => x.QuestionRoundNum == 3 && x.FeelingNoun == "fun to watch");
                Answer funToWatchAns = answers.Find(x => x.QuestionID == funToWatch.QuestionID);
                if (funToWatchAns != null)
                {
                    line.Enjoy2 = (int)funToWatchAns.AnswerValue;
                }

                Question watching = questions.FirstOrDefault(x => x.QuestionRoundNum == 3 && x.FeelingNoun == "watching");
                Answer watchingAns = answers.Find(x => x.QuestionID == watching.QuestionID);
                if (watchingAns != null)
                {
                    line.Enjoy3 = (int)watchingAns.AnswerValue;
                }

                Question enjoyable = questions.FirstOrDefault(x => x.QuestionRoundNum == 3 && x.FeelingNoun == "enjoyable");
                Answer enjoyableAns = answers.Find(x => x.QuestionID == enjoyable.QuestionID);
                if (enjoyableAns != null)
                {
                    line.Enjoy4 = (int)enjoyableAns.AnswerValue;
                }

                Question questionOSU1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 4 && x.GroupQuestionNumber == 5);
                Answer questionOSU1Ans = answers.Find(x => x.QuestionID == questionOSU1.QuestionID);
                if (questionOSU1Ans != null)
                {
                    line.OSUIdentity1 = (int)questionOSU1Ans.AnswerValue;
                }

                Question questionOSU2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 4 && x.GroupQuestionNumber == 6);
                Answer questionOSU2Ans = answers.Find(x => x.QuestionID == questionOSU2.QuestionID);
                if (questionOSU2Ans != null)
                {
                    line.OSUIdentity2 = (int)questionOSU2Ans.AnswerValue;
                }

                Question questionOSU3 = questions.FirstOrDefault(x => x.QuestionRoundNum == 4 && x.GroupQuestionNumber == 7);
                Answer questionOSU3Ans = answers.Find(x => x.QuestionID == questionOSU3.QuestionID);
                if (questionOSU3Ans != null)
                {
                    line.OSUIdentity3 = (int)questionOSU3Ans.AnswerValue;
                }

                Question questionOSU4 = questions.FirstOrDefault(x => x.QuestionRoundNum == 4 && x.GroupQuestionNumber == 8);
                Answer questionOSU4Ans = answers.Find(x => x.QuestionID == questionOSU4.QuestionID);
                if (questionOSU4Ans != null)
                {
                    line.OSUIdentity4 = (int)questionOSU4Ans.AnswerValue;
                }

                Question questionUO1 = questions.FirstOrDefault(x => x.QuestionRoundNum == 4 && x.GroupQuestionNumber == 1);
                Answer questionUO1Ans = answers.Find(x => x.QuestionID == questionUO1.QuestionID);
                if (questionUO1Ans != null)
                {
                    line.UOIdentity1 = (int)questionUO1Ans.AnswerValue;
                }

                Question questionUO2 = questions.FirstOrDefault(x => x.QuestionRoundNum == 4 && x.GroupQuestionNumber == 2);
                Answer questionUO2Ans = answers.Find(x => x.QuestionID == questionUO2.QuestionID);
                if (questionUO2Ans != null)
                {
                    line.UOIdentity2 = (int)questionUO2Ans.AnswerValue;
                }

                Question questionUO3 = questions.FirstOrDefault(x => x.QuestionRoundNum == 4 && x.GroupQuestionNumber == 3);
                Answer questionUO3Ans = answers.Find(x => x.QuestionID == questionUO3.QuestionID);
                if (questionUO3Ans != null)
                {
                    line.UOIdentity3 = (int)questionUO3Ans.AnswerValue;
                }

                Question questionUO4 = questions.FirstOrDefault(x => x.QuestionRoundNum == 4 && x.GroupQuestionNumber == 4);
                Answer questionUO4Ans = answers.Find(x => x.QuestionID == questionUO4.QuestionID);
                if (questionUO4Ans != null)
                {
                    line.UOIdentity4 = (int)questionUO4Ans.AnswerValue;
                }

                Question questionExciting = questions.FirstOrDefault(x => x.QuestionRoundNum == 5 && x.FeelingNoun == "exciting");
                Answer questionExcitingAns = answers.Find(x => x.QuestionID == questionExciting.QuestionID);
                if (questionExcitingAns != null)
                {
                    line.Exciting = (int)questionExcitingAns.AnswerValue;
                }

                Question questionInvolved = questions.FirstOrDefault(x => x.QuestionRoundNum == 5 && x.FeelingNoun == "involved");
                Answer questionInvolvedAns = answers.Find(x => x.QuestionID == questionInvolved.QuestionID);
                if (questionInvolvedAns != null)
                {
                    line.Involved = (int)questionInvolvedAns.AnswerValue;
                }


                sw.AppendLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44}",
                                        line.TimeStamp.ToString(), line.ID_Code, line.TimeRules, line.Race1Winner, line.Race2Winner, line.Race3Winner,
                                        line.Race4Winner, line.Race5Winner, line.Race6Winner, line.Bet, line.Hopeful1,
                                        line.Worried1, line.Happy1, line.Sad1, line.Relieved1, line.Disappointed1,
                                        line.Amused1, line.Angry1, line.Contented1, line.Disgusted1, line.Race7Winner,
                                        line.Hopeful2, line.Worried2, line.Happy2, line.Sad2, line.Relieved2, line.Disappointed2,
                                        line.Amused2, line.Angry2, line.Contented2, line.Disgusted2, line.Enjoy1, line.Enjoy2,
                                        line.Enjoy3, line.Enjoy4, line.UOIdentity1, line.UOIdentity2, line.UOIdentity3, line.UOIdentity4,
                                        line.OSUIdentity1, line.OSUIdentity2, line.OSUIdentity3, line.OSUIdentity4, line.Involved,
                                        line.Exciting));

            }

            return File(new System.Text.UTF8Encoding().GetBytes(sw.ToString()), "text/csv", "Results" + DateTime.Now.ToShortDateString() + ".csv");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
