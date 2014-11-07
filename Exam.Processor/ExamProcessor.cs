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
        private IRepository<Certificate> certificateRepository;
        private IRepository<Question> questionRepository;

        public ExamProcessor(IRepository<Certificate> certificateRepository, IRepository<Question> questionRepository)
        {
            this.certificateRepository = certificateRepository;
            this.questionRepository = questionRepository;
        }
        public async Task<IEnumerable<Contracts.CertificateResponse>> GetCertificates()
        {
            return Map(await this.certificateRepository.GetAllAsync());
        }

        public async Task<int> SaveQuestion(Contracts.QuestionRequest question)
        {
            var mappedQuestion = Map(question);
            return await this.questionRepository.AddAsync(mappedQuestion);
        }

        public async Task<IEnumerable<Contracts.QuestionIdsResponse>> GetQuestionIds(int certificateId)
        {
            var questions = await this.questionRepository.FindAllAsync(m=>m.CertificateId== certificateId);
            return Map(questions);
        }

        public async Task<Contracts.QuestionsResponse> GetQuestion(long questionId)
        { 
            var question = await this.questionRepository.FindAsync(m=>m.QuestionId== questionId);
            return Map(question);
        }

    }
}
