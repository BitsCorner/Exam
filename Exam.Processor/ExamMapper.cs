using Exam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public partial class ExamProcessor
    {
        internal IEnumerable<Contracts.CertificateResponse> Map(IEnumerable<Certificate> certificates)
        {
            if (certificates == null)
                return null;

            var result = from item in certificates
                         select new Contracts.CertificateResponse
                         {
                              CertificateCode = item.CertificateCode,
                              CertificateId = item.CertificateId,
                              CertificateName = item.CertificateName,
                              PublishDate = item.PublishDate,
                              CompanyName = item.CompanyName,
                              Skills = Map(item.Skills),
                              Technology = item.Technology
                         };
            return result.AsEnumerable();
        }
        internal IEnumerable<Contracts.SkillResponse> Map(ICollection<Skill> skills)
        {
            if (skills == null)
                return null;

            var result = from item in skills
                         select new Contracts.SkillResponse
                         {
                             SkillId = item.SkillId,
                             SkillName = item.SkillName,
                             SkillOrder = item.SkillOrder,
                             SkillDetails = Map(item.SkillDetails)
                         };
            return result.AsEnumerable();            
        }
        internal IEnumerable<Contracts.SkillDetailResponse> Map(ICollection<SkillDetail> skillDetails)
        {
            if (skillDetails == null)
                return null;

            var result = from item in skillDetails
                         select new Contracts.SkillDetailResponse
                         {
                              SkillDetailId = item.SkillDetailId,
                              SkillDetailDescription = item.SkillDetailDescription,
                              SkillDetailOrder = item.SkillDetailOrder
                         };
            return result.AsEnumerable();   
        }
        internal Question Map(Contracts.QuestionRequest question)
        {
            try
            {
                if (question == null)
                    return null;

                var answers = Map(question.Answers);
                return new Question
                {
                    CertificateId = question.CertificateId,
                    Answers = answers,
                    QuestionLevelId = question.DifficultyLevel.QuestionLevelId,
                    SkillId = question.Skill.SkillId,
                    SkillDetailId = question.SkillDetail != null ? (int?)question.SkillDetail.SkillDetailId : null,
                    Explanation = question.Explanation,
                    OriginalFileName = (question.File == null ? "" : question.QuestionImage),
                    FileName = (question.File == null ? "" : question.File.returnData),
                    CreatedBy = question.UserId,
                    ModifiedBy = question.UserId,
                    UserId = question.UserId,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    IsMultiChoice = answers.Where(m=>m.IsCorrectAnswer == true).Count() > 1 ? true : false,
                    CorrectAnswerCount = answers.Where(m=>m.IsCorrectAnswer == true).Count(),
                    Title = question.Title
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal IList<Answer> Map(IEnumerable<Contracts.AnswerRequest> answers)
        {
            if (answers == null)
                return null;

            var result = from answer in answers
                         select new Answer
                         {
                              Description = answer.Description,
                              OriginalFileName = (answer.File == null ? "" : answer.AnswerImage),
                              FileName = (answer.File == null ? "" : answer.File.returnData),
                              IsCorrectAnswer = answer.IsCorrectAnswer
                         };
            return result.ToList();
        }
        internal IEnumerable<Contracts.QuestionIdsResponse> Map(List<Question> questions)
        {
            if (questions == null)
                return null;

            var result = from item in questions
                         select new Contracts.QuestionIdsResponse
                         {
                              CertificateId = item.CertificateId,
                              QuestionId = item.QuestionId
                         };
            return result.AsEnumerable(); 
        }

        private Contracts.QuestionsResponse Map(Question question)
        {
            if (question == null)
                return null;

            var answers = Map(question.Answers);
            return new Contracts.QuestionsResponse
            {
                Title = question.Title,
                Answers = answers,
                QuestionId = question.QuestionId,
                CorrectAnswerCount = question.CorrectAnswerCount,
                Explanation = question.Explanation,
                IsMultiChoice = question.IsMultiChoice,
                //QuestionLevel = new Question question.QuestionLevel.QuestionLevelName
            };
        }

        private IEnumerable<Contracts.AnswerResponse> Map(ICollection<Answer> answers)
        {
            if (answers == null)
                return null;

            var result = from answer in answers
                         select new Contracts.AnswerResponse
                         {
                             Description = answer.Description,
                             IsCorrectAnswer = answer.IsCorrectAnswer
                         };
            return result.AsEnumerable();
        }
    }
}
