using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Interface
{
    public interface IQuestionsRepository
    {
        QuestionEx GetQuestion(int Id);
        List<QuestionEx> GetAll();

    }
}
