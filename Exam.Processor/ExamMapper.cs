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

    }
}
