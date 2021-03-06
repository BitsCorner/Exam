﻿using Exam.Repository;
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
            var found = await this.userRepository.FindAsync(m => m.UserId == user.UserId);
            var mappedUser = Map(user);
            if (found == null)
                return await this.userRepository.AddAsync(mappedUser);
            else
                return await Task.FromResult(1);
                //return await this.userRepository.UpdateAsync(mappedUser);
        }

        public async Task<int> SaveQuestionComment(Contracts.QuestionCommentRequest questionComment)
        {
            var mappedQuestionComment = Map(questionComment);
            return await this.questionCommentRepository.AddAsync(mappedQuestionComment);
        }

        public async Task<int> SaveQuestionVote(Contracts.QuestionVoteRequest questionVote)
        {
            var question = await this.questionRepository.FindAsync(m => m.QuestionId == questionVote.QuestionId);
            if (question != null)
            { 
                question.Vote += questionVote.Vote;
                this.questionRepository.UpdateAsync(question);
            }
            var mappedQuestionVote = Map(questionVote);
            return await this.questionVoteRepository.AddAsync(mappedQuestionVote);
        }

        public async Task<int> SaveUserAttempt(Contracts.AttemptDetailRequest attemptDetail)
        {
            var mappedUserAttempt = Map(attemptDetail);
            return await this.userAttemptRepository.AddAsync(mappedUserAttempt);
        }





        public Task<int> SaveAttemptDetail(Contracts.AttemptDetailRequest attemptDetail)
        {
            throw new NotImplementedException();
        }

        public Task<int> StartAttempt(Contracts.AttemptRequest attempt)
        {
            throw new NotImplementedException();
        }

        public Task<int> EndAttempt(Contracts.AttemptRequest attempt)
        {
            throw new NotImplementedException();
        }
    }
}
