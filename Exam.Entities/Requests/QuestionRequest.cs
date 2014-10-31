using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Contracts
{
    public class QuestionRequest
    {
        public int QuestionId { get; set; }
        public int CertificateId { get; set; }
        public int SkillId { get; set; }
        public int SkillDetailId { get; set; }
        public string Title { get; set; }
        public bool IsMultiChoice { get; set; }
        public int CorrectAnswerCount { get; set; }
        public bool AllowShuffleChoices { get; set; }
        public string Explanation { get; set; }
        public bool CheckNumberOfSelected { get; set; }
        public int QuestionLevelId { get; set; }
        public string UserId { get; set; }

    }
}
