﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Contracts
{
    public class SkillResponse
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int SkillOrder { get; set; }
        public IEnumerable<SkillDetailResponse> SkillDetails { get; set; }
    }
}
