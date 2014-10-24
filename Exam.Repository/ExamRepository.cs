using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository
{
    public class ExamRepository : IExamRepository
    {
        public Task<IEnumerable<UserProfile>> GetAllUserProfiles()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetUserProfile(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> SaveUserProfile(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Certificate>> GetAllCertificates()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Skill>> GetAllSkills(int CertificateId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SkillDetail>> GetAllSkillDetails(int SkillId)
        {
            throw new NotImplementedException();
        }

        public Task<Question> SaveQuestion(Question question, IEnumerable<Answer> answers)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQuestion(int QuestionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAllQuestions(int CertificateId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAllQuestionsBySkill(int SkillId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAllQuestionsByLevel(int QuestionLevelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Answer>> GetAllAnswer(int QuestionId)
        {
            throw new NotImplementedException();
        }
    }
}
