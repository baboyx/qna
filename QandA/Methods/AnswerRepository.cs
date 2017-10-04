using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QandA.Db;

namespace QandA.Methods
{
    public class AnswerRepository
    {
        readonly QandAEntities db;
        public AnswerRepository(QandAEntities db)
        {
            this.db = db;
        }
        public List<AnswerEx> GetByQuestion(int Id)
        {
            var r = db.Answers.Where(c => c.Id == Id).AsQueryable();
            return Transform(r);

        }

        public AnswerEx GetByUser(int UserId)
        {
            var r = db.Answers.Where(c => c.UserId == UserId).FirstOrDefault();
            return Transform(r);
        }

        public void Save(AnswerEx n)
        {
            var t = Transform(n);
            if (t.UserId == 0)
            {
                db.Answers.Add(t);
            }
            db.SaveChanges();
        }

        public List<AnswerEx> Transform(IQueryable<Answer> n)
        {
            List<AnswerEx> aReturn = new List<AnswerEx>();
            foreach (var r in n)
            {
                aReturn.Add(Transform(r));
            }
            return aReturn;
        }
        public AnswerEx Transform(Answer n)
        {
            AnswerEx r = new AnswerEx();
            r.Id = n.Id;
            r.QuestionId = n.QuestionId;
            r.Answer1 = n.Answer1;
       
            r.UserId = n.UserId;


            return r;
        }
        public Answer Transform(AnswerEx n)
        {
            Answer r;
            if (n.UserId > 0)
            {
                r = db.Answers.Where(o => o.UserId == n.UserId).FirstOrDefault();
            }
            else
            {
                r = db.Answers.Create();
            }
            r.QuestionId = n.QuestionId;
            r.Answer1 = n.Answer1;
            r.UserId = n.UserId;

            return r;
        }
    }
}