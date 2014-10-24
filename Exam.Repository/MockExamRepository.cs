using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository
{
    public class MockExamRepository : IExamRepository
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

        public async Task<IEnumerable<Certificate>> GetAllCertificates()
        {
            var result = new List<Certificate>() { 
                new Certificate(){
                     CertificateId = 1,
                     CertificateCode = "70-480",
                     CertificateName = "Programming in HTML5 with JavaScript and CSS3",
                     CompanyName = "Microsoft",
                     Technology = "Microsoft Visual Studio 2012",
                     PublishDate = DateTime.Parse("August 20, 2012"),
                     Skills = (ICollection<Skill>)GetAllSkills(1).Result
                },
                new Certificate(){
                     CertificateId = 2,
                     CertificateCode = "70-486",
                     CertificateName = "Developing ASP.NET MVC Web Applications",
                     CompanyName = "Microsoft",
                     Technology = "Microsoft Visual Studio 2013, ASP.NET MVC 5.1",
                     PublishDate = DateTime.Parse("October 4, 2012"),
                     Skills = (ICollection<Skill>)GetAllSkills(2).Result,
                },
                new Certificate(){
                     CertificateId = 3,
                     CertificateCode = "70-487",
                     CertificateName = "Developing Microsoft Azure and Web Services",
                     CompanyName = "Microsoft",
                     Technology = "Microsoft Visual Studio 2013, Microsoft Azure",
                     PublishDate = DateTime.Parse("October 17, 2012"),
                     Skills = (ICollection<Skill>)GetAllSkills(3).Result
                },
            };
            return result.AsEnumerable();
        }

        public async Task<IEnumerable<Skill>> GetAllSkills(int CertificateId)
        {
            var result = new List<Skill>() { 
                new Skill(){
                     SkillId = 1,
                     SkillName = "Implement and manipulate document structures and objects (24%)",
                     CertificateId = 1,
                     SkillOrder = 1,
                     SkillDetails = (ICollection<SkillDetail>)GetAllSkillDetails(1).Result

                },
                new Skill(){
                     SkillId = 2,
                     SkillName = "Implement  program flow (25%)",
                     CertificateId = 1,
                     SkillOrder = 2,
                     SkillDetails = (ICollection<SkillDetail>)GetAllSkillDetails(2).Result
                },
                new Skill(){
                     SkillId = 3,
                     SkillName = "Access and secure data (26%)",
                     CertificateId = 1,
                     SkillOrder = 4,
                     SkillDetails = (ICollection<SkillDetail>)GetAllSkillDetails(3).Result
                },
                new Skill(){
                     SkillId = 4,
                     SkillName = "Use CSS3 in applications (25%)",
                     CertificateId = 1,
                     SkillOrder = 4,
                     SkillDetails = (ICollection<SkillDetail>)GetAllSkillDetails(4).Result
                },
            };

            return result.Where(m=>m.CertificateId == CertificateId).ToList().AsEnumerable();
        }

        public async Task<IEnumerable<SkillDetail>> GetAllSkillDetails(int SkillId)
        {
            var result = new List<SkillDetail>() { 
                new SkillDetail(){
                     SkillDetailId = 1,
                     SkillId = 1,
                     SkillDetailDescription = "Create the document structure",
                     SkillDetailOrder = 1,
                },
                new SkillDetail(){
                     SkillDetailId = 2,
                     SkillId = 1,
                     SkillDetailDescription = "Write code that interacts with UI controls",
                     SkillDetailOrder = 2,
                },
                new SkillDetail(){
                     SkillDetailId = 3,
                     SkillId = 1,
                     SkillDetailDescription = "Apply styling to HTML elements programmatically",
                     SkillDetailOrder = 3,
                },
                new SkillDetail(){
                     SkillDetailId = 4,
                     SkillId = 1,
                     SkillDetailDescription = "Implement HTML5 APIs",
                     SkillDetailOrder = 4,
                },
                new SkillDetail(){
                     SkillDetailId = 5,
                     SkillId = 1,
                     SkillDetailDescription = "Establish the scope of objects and variables",
                     SkillDetailOrder = 5,
                },
                new SkillDetail(){
                     SkillDetailId = 6,
                     SkillId = 1,
                     SkillDetailDescription = "Create and implement objects and methods",
                     SkillDetailOrder = 6,
                },

            };

            return result.Where(m => m.SkillId == SkillId).ToList().AsEnumerable();
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
