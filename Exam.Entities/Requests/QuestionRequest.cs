using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Contracts.Requests;

namespace Exam.Contracts
{
    public class QuestionRequest
    {
        public string Title { get; set; }
        public IEnumerable<AnswerRequest> Answers { get; set; }
        public string Explanation { get; set; }
        public SkillRequest Skill { get; set; }
        public SkillDetailRequest SkillDetail { get; set; }
        public DifficultyLevelRequest DifficultyLevel { get; set; }
        public FileRequest File { get; set; }
        public string QuestionImage { get; set; }
        public string UserId { get; set; }
        public int CertificateId { get; set; }
    }
}
