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
    public class UserController : ApiController
    {
        private IExamProcessor examProcessor;
        public UserController(IExamProcessor examProcessor)
        {
            this.examProcessor = examProcessor;
        }

        public async Task<IHttpActionResult> Post([FromBody]UserRequest user)
        {
            if(user == null)
                return InternalServerError();

            var response = await examProcessor.SaveUser(user);
            if (response == 0)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

    }
}
