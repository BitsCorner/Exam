﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExamEntities : DbContext
    {
        public ExamEntities()
            : base("name=ExamEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionComment> QuestionComments { get; set; }
        public virtual DbSet<QuestionLevel> QuestionLevels { get; set; }
        public virtual DbSet<QuestionVote> QuestionVotes { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillDetail> SkillDetails { get; set; }
        public virtual DbSet<UserAttempt> UserAttempts { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
    }
}
