using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QandA.Methods;

namespace QandA.Controllers
{
    public class MainApiController : ApiController
    {
        readonly AnswerRepository repoAnswers;
        readonly QuestionsRepository repoQuestions;
        readonly UserRepository repoUser;

        public MainApiController(AnswerRepository repoAnswers, QuestionsRepository repoQuestions, UserRepository repoUser)
        {
            this.repoAnswers = repoAnswers;
            this.repoQuestions = repoQuestions;
            this.repoUser = repoUser;
        }

        [Route("User/Save")]
        [HttpPost]
        public int Save(UserEx n)
        {
            repoUser.Save(n);
            return n.Id;
        }

        [Route("Question/Generate")]
        [HttpGet]
        public QuestionEx Generate()
        {
            var rand = new Random();
            var count = repoQuestions.GetAll().Count();
            return repoQuestions.GetQuestion(rand.Next(1,count));
        }

        [Route("Answer/Save")]
        [HttpPost]
        public void SaveAnswer(AnswerEx n)
        {
            repoAnswers.Save(n);
        }

        [Route("Answer/{UserId}")]
        [HttpGet]
        public AnswerEx GetAnswerInUsers(int UserId)
        {
            var r = repoAnswers.GetByUser(UserId);
            r.UserName = repoUser.GetUser(UserId).Name;
            return r;
        }

        


    }
}
