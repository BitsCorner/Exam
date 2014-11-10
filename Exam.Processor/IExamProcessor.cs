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

        Task<IEnumerable<QuestionIdsResponse>> GetQuestionIds(int certificateId);

        Task<QuestionsResponse> GetQuestion(long questionId);

        Task<int> SaveQuestion(QuestionRequest quesion);

        Task<int> SaveUser(UserRequest user);

        Task<int> SaveQuestionComment(QuestionCommentRequest questionComment);

        Task<int> SaveQuestionVote(QuestionVoteRequest questionVote);

        Task<int> SaveUserAttempt(UserAttemptRequest userAttempt);

    }
}
