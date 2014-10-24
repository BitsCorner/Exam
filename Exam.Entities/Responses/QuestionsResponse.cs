using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Contracts
{
    public class QuestionsResponse
    {
        public long QuestionId { get; set; }
        public CertificateResponse Certificate { get; set; }
        public string Title { get; set; }
        public Nullable<bool> IsMultiChoice { get; set; }
        public Nullable<int> CorrectAnswerCount { get; set; }
        public Nullable<bool> AllowShuffleChoices { get; set; }
        public Nullable<bool> CheckNumberOfSelected { get; set; }
        public string Explanation { get; set; }
        public QuestionLevelResponse QuestionLevel { get; set; }
        public UserResponse User { get; set; }
        public virtual IEnumerable<AnswerResponse> Answers { get; set; }
    }
}
