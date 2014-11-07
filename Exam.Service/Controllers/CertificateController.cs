using Exam.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Exam.Service.Controllers
{
    [EnableCors("*","*","*")]
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

        public async Task<IHttpActionResult> Get(int id)
        {
            var response = await examProcessor.GetCertificates();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response.FirstOrDefault(m=>m.CertificateId == id));
        }

        [Route("api/Certificate/{certificateId}/Questions")]
        public async Task<IHttpActionResult> GetCertificateQuestionIds(int certificateId)
        {
            var response = await examProcessor.GetQuestionIds(certificateId);
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
