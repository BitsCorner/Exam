using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Contracts
{
    public class UserAttemptRequest
    {
        public Int64 QuestionId { get; set; }
        public string UserId { get; set; }
        public string TimeSpent { get; set; }
        public bool GotItRight { get; set; }
        public IEnumerable<Int64> Answers { get; set; }
    }
}
