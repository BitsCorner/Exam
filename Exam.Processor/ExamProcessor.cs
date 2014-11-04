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

        public async Task<IEnumerable<Contracts.QuestionsResponse>> GetQuestions()
        {
            var questions = await this.questionRepository.GetAllAsync();
            return Map(questions);
        }

        public async Task<int> SaveQuestion(Contracts.QuestionRequest question)
        {
            var mappedQuestion = Map(question);
            return await this.questionRepository.AddAsync(mappedQuestion);
        }
    }
}
