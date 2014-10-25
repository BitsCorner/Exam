using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Contracts
{
    public class SkillDetailResponse
    {
        public int SkillDetailId { get; set; }
        public string SkillDetailDescription { get; set; }
        public Nullable<int> SkillDetailOrder { get; set; }
    }
}
