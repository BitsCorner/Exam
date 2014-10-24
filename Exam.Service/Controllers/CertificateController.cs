using Exam.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Exam.Service.Controllers
{
    public class CertificateController : ApiController
    {
        private IExamProcessor examProcessor;
        public CertificateController(IExamProcessor examProcessor)
        {
            this.examProcessor = examProcessor;
        }
        public async Task<IHttpActionResult> Get()
        {
            var response = await examProcessor.GetCertificates();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        public async Task<IHttpActionResult> GetCertificateSkills(int CertificateId)
        {
            var response = await examProcessor.GetCertificates();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
