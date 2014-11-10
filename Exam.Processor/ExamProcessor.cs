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
        private IRepository<UserProfile> userRepository;
        private IRepository<QuestionComment> questionCommentRepository;
        private IRepository<QuestionVote> questionVoteRepository;
        private IRepository<UserAttempt> userAttemptRepository;

        public ExamProcessor(IRepository<Certificate> certificateRepository, 
                             IRepository<Question> questionRepository, 
                             IRepository<UserProfile> userRepository,
                             IRepository<QuestionComment> questionCommentRepository,
                             IRepository<QuestionVote> questionVoteRepository,
                             IRepository<UserAttempt> userAttemptRepository)
        {
            this.certificateRepository = certificateRepository;
            this.questionRepository = questionRepository;
            this.userRepository = userRepository;
            this.questionCommentRepository = questionCommentRepository;
            this.questionVoteRepository = questionVoteRepository;
            this.userAttemptRepository = userAttemptRepository;
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

        public async Task<int> SaveUser(Contracts.UserRequest user)
        {
            var mappedUser = Map(user);
            return await this.userRepository.AddAsync(mappedUser);
        }

        public async Task<int> SaveQuestionComment(Contracts.QuestionCommentRequest questionComment)
        {
            var mappedQuestionComment = Map(questionComment);
            return await this.questionCommentRepository.AddAsync(mappedQuestionComment);
        }

        public async Task<int> SaveQuestionVote(Contracts.QuestionVoteRequest questionVote)
        {
            var mappedQuestionVote = Map(questionVote);
            return await this.questionVoteRepository.AddAsync(mappedQuestionVote);
        }

        public async Task<int> SaveUserAttempt(Contracts.UserAttemptRequest userAttempt)
        {
            var mappedUserAttempt = Map(userAttempt);
            return await this.userAttemptRepository.AddAsync(mappedUserAttempt);
        }


         
    }
}
