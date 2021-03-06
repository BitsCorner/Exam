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
    
    public partial class Question
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
            this.QuestionVotes = new HashSet<QuestionVote>();
            this.UserAttempts = new HashSet<UserAttempt>();
        }
    
        public long QuestionId { get; set; }
        public int CertificateId { get; set; }
        public int SkillId { get; set; }
        public Nullable<int> SkillDetailId { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public Nullable<bool> IsMultiChoice { get; set; }
        public Nullable<int> CorrectAnswerCount { get; set; }
        public Nullable<bool> AllowShuffleChoices { get; set; }
        public Nullable<bool> CheckNumberOfSelected { get; set; }
        public string Explanation { get; set; }
        public Nullable<int> QuestionLevelId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> Vote { get; set; }
        public Nullable<bool> Confirmed { get; set; }
        public string ConfirmedBy { get; set; }
        public Nullable<System.DateTime> CinfirmDate { get; set; }
    
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Certificate Certificate { get; set; }
        public virtual QuestionLevel QuestionLevel { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual SkillDetail SkillDetail { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<QuestionVote> QuestionVotes { get; set; }
        public virtual ICollection<UserAttempt> UserAttempts { get; set; }
    }
}
