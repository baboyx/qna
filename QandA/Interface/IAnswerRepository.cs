using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Interface
{
    public interface IAnswerRepository
    {
        List<AnswerEx> GetByQuestion(int Id);
        AnswerEx GetByUser(int UserId);
        void Save(AnswerEx n);
        List<AnswerEx> GetAll();
    }
}
