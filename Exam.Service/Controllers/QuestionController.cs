using Exam.Business;
using Exam.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Exam.Service.Controllers
{
    [EnableCors("*","*","*")]
    public class QuestionController : ApiController
    {
        private IExamProcessor examProcessor;
        public QuestionController(IExamProcessor examProcessor)
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

        public async Task<IHttpActionResult> Post([FromBody]QuestionRequest question)
        {
            if(question == null)
                return InternalServerError();

            var response = await examProcessor.SaveQuestion(question);
            if (response == false)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

    }
}
