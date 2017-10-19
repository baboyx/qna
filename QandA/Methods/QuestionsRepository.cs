using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QandA.Db;
using QandA.Interface;

namespace QandA.Methods
{
    public class QuestionsRepository : IQuestionsRepository
    {
        readonly QandAEntities db;
        public QuestionsRepository(QandAEntities db)
        {
            this.db = db;
        }

        public QuestionEx GetQuestion(int Id)
        {
            var r = db.Questions.Where(c => c.Id == Id).FirstOrDefault();
            var oReturn =  Transform(r);
            return oReturn;

        }

        public List<QuestionEx> GetAll()
        {
            var r = db.Questions.AsQueryable();
            return Transform(r);
        }


        public List<QuestionEx> Transform(IQueryable<Question> n)
        {
            List<QuestionEx> aReturn = new List<QuestionEx>();
            foreach (var r in n)
            {
                aReturn.Add(Transform(r));
            }
            return aReturn;
        }
        public QuestionEx Transform(Question n)
        {
            QuestionEx r = new QuestionEx();
            r.Id = n.Id;
            r.Questions = n.Questions;

            return r;
        }
        public Question Transform(QuestionEx n)
        {
            Question r;
            if (n.Id > 0)
            {
                r = db.Questions.Where(o => o.Id == n.Id).FirstOrDefault();
            }
            else
            {
                r = db.Questions.Create();
            }


            r.Questions = n.Questions;

            return r;
        }
    }
}