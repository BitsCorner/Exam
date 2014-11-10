using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Contracts;

namespace Exam.Contracts
{
    public class QuestionVoteRequest
    {
        public Int64 QuestionId { get; set; }
        public string UserId { get; set; }
        public int Vote { get; set; }
    }
}
