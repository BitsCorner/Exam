using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Contracts
{
    public class QuestionCommentRequest
    {
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Comment { get; set; }
        public Int64 ParentCommentId { get; set; }
    }
}
