using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Contracts
{
    public class AttemptRequest
    {
        public Int64 AttemptId { get; set; }
        public string UserId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool Finished  { get; set; }
        public IEnumerable<Int64> QuestionIds { get; set; }
    }
}
