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
    
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public Nullable<long> QuestionId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public Nullable<bool> IsCorrectAnswer { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
