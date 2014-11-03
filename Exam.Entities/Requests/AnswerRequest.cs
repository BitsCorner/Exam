using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Contracts
{
    public class AnswerRequest
    {
        public string Description { get; set; }
        public string AnswerImage { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public FileRequest File { get; set; }
    }
}
