using Exam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public partial class ExamProcessor : IExamProcessor
    {
        private IExamRepository examRepository;

        public ExamProcessor(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }
        public async Task<IEnumerable<Contracts.CertificateResponse>> GetCertificates()
        {
            return Map(await this.examRepository.GetAllCertificates());
        }

        public Task<IEnumerable<Contracts.QuestionsResponse>> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveQuestion(Contracts.QuestionRequest quesion)
        {
            throw new NotImplementedException();
        }
    }
}
