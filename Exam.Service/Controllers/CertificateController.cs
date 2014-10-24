using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exam.Service.Controllers
{
    public class CertificateController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<string> GetCertificateSkills(int CertificateId)
        {
            return new string[] { "value1", "value2" };
        }

    }
}
