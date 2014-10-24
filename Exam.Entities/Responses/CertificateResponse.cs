using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Contracts
{
    public class CertificateResponse
    {
        public int CertificateId { get; set; }
        public string CompanyName { get; set; }
        public string CertificateCode { get; set; }
        public string CertificateName { get; set; }
        public string Technology { get; set; }
        public DateTime PublishDate { get; set; }
        public IEnumerable<SkillResponse> Skills { get; set; }
    }
}
