using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exam.Service.Controllers
{
    public class QuestionController : ApiController
    {
        public IEnumerable<string> Get(int CertificateId)
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<string> GetBySkill(int CertificateId, int SkillId)
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<string> GetById(int QuestionId)
        {
            return new string[] { "value1", "value2" };
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
