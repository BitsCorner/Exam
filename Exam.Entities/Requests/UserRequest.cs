using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.Contracts
{
    public class UserRequest
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
