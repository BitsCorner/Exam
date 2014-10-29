using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Contracts
{
    public class AnswerRequest
    {
        public int AnswerId { get; set; }
        public Nullable<int> RowId { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsCorrectAnswer { get; set; }
    }
}
