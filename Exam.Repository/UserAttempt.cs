//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exam.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAttempt
    {
        public long AttemptId { get; set; }
        public long QuestionId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> AttemptDate { get; set; }
        public string TimeSpent { get; set; }
        public Nullable<bool> GotItRight { get; set; }
        public string Answers { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}