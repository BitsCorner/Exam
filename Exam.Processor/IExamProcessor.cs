using Exam.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public interface IExamProcessor
    {
        Task<IEnumerable<CertificateResponse>> GetCertificates();

        Task<IEnumerable<QuestionsResponse>> GetQuestions();

        Task<int> SaveQuestion(QuestionRequest quesion);
    }
}
