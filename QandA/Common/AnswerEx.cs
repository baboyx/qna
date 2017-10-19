using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA
{
    public class AnswerEx
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int QuestionId { get; set; }
        public string Answer1 { get; set; }
        public string Question { get; set; }
    }
}