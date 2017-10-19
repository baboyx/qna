using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QandA.Methods;
using QandA.Db;
using QandA.Interface;
namespace QandA.Controllers
{
    public class MainApiController : ApiController
    {




        [Route("User/Save")]
        [HttpPost]
        public int Save(UserEx n)
        {
            var db = new QandAEntities();
            var repoUser = new UserRepository(db);
            repoUser.Save(n);
            return n.Id;
        }

        [Route("Question/Generate")]
        [HttpGet]
        public QuestionEx Generate()
        {
            var db = new QandAEntities();
            var repoQuestions = new QuestionsRepository(db);
            var rand = new Random();
            var count = repoQuestions.GetAll().Count();
            return repoQuestions.GetQuestion(rand.Next(1,count));
        }

        [Route("Question/Get/{Id}")]
        [HttpGet]
        public QuestionEx GetQuestion(int Id)
        {
            var db = new QandAEntities();
            var repoQuestions = new QuestionsRepository(db);
            return repoQuestions.GetQuestion(Id);

        }

        [Route("Answer/Save")]
        [HttpPost]
        public void SaveAnswer(AnswerEx n)
        {
            var user = new UserEx();
            user.Name = n.UserName;
            var uId = Save(user);
            n.UserId = uId;
            var db = new QandAEntities();
            var repoAnswers = new AnswerRepository(db);
            repoAnswers.Save(n);
        }

        [Route("Answer/{UserId}")]
        [HttpGet]
        public AnswerEx GetAnswerInUsers(int UserId)
        {
            var db = new QandAEntities();
            var repoUser = new UserRepository(db);
            var repoAnswers = new AnswerRepository(db);
            var r = repoAnswers.GetByUser(UserId);
            r.UserName = repoUser.GetUser(UserId).Name;
            r.Question = GetQuestion(r.QuestionId).Questions;
            return r;
        }
        [Route("Answer/List")]
        [HttpGet]
        public List<AnswerEx> GetAll()
        {
            var db = new QandAEntities();
            var repoUser = new UserRepository(db);
            var repoAnswers = new AnswerRepository(db);
            var aReturn = repoAnswers.GetAll();
            foreach(var g in aReturn)
            {
                g.UserName = repoUser.GetUser(g.UserId).Name;
                g.Question = GetQuestion(g.QuestionId).Questions;
            }
            return aReturn;
        }

        


    }
}
