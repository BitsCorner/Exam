using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository
{
    public interface IExamRepository
    {
        #region User Profile
        Task<IEnumerable<UserProfile>> GetAllUserProfiles();
        Task<UserProfile> GetUserProfile(string UserId);
        Task<UserProfile> SaveUserProfile(UserProfile userProfile);
        #endregion

        #region Certificate
        Task<IEnumerable<Certificate>> GetAllCertificates();
        #endregion

        #region Skill
        Task<IEnumerable<Skill>> GetAllSkills(int CertificateId);
        #endregion

        #region SkillDetail
        Task<IEnumerable<SkillDetail>> GetAllSkillDetails(int SkillId);
        #endregion

        #region Question
        Task<Question> SaveQuestion(Question question, IEnumerable<Answer> answers);
        Task<bool> DeleteQuestion(int QuestionId);
        Task<IEnumerable<Question>> GetAllQuestions(int CertificateId);
        Task<IEnumerable<Question>> GetAllQuestionsBySkill(int SkillId);
        Task<IEnumerable<Question>> GetAllQuestionsByLevel(int QuestionLevelId);
        #endregion

        #region Answer
        Task<IEnumerable<Answer>> GetAllAnswer(int QuestionId);
        #endregion
    }
}
