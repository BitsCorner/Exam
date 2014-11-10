CREATE TABLE [dbo].[Question]
(
	[QuestionId] BIGINT NOT NULL PRIMARY KEY, 
    [CertificateId] INT NOT NULL, 
	[SkillId] INT NOT NULL, 
	[SkillDetailId] INT NULL, 
    [Title] NVARCHAR(MAX) NULL, 
    [FileName] NVARCHAR(MAX) NULL, 
	[OriginalFileName] NVARCHAR(MAX) NULL, 
    [IsMultiChoice] BIT NULL, 
    [CorrectAnswerCount] INT NULL, 
    [AllowShuffleChoices] BIT NULL, 
    [CheckNumberOfSelected] BIT NULL, 
    [Explanation] NVARCHAR(MAX) NULL,
	[QuestionLevelId] INT NULL,
	[UserId] NVARCHAR(500) NULL,
    [CreatedDate] DATETIME NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [ModifiedDate] DATETIME NULL, 
    [ModifiedBy] NVARCHAR(50) NULL, 
    [Vote] INT NULL, 
    [Confirmed] BIT NULL, 
    [ConfirmedBy] NVARCHAR(500) NULL, 
    [CinfirmDate] DATETIME NULL, 
    CONSTRAINT [FK_Question_Certificate] FOREIGN KEY ([CertificateId]) 
									 REFERENCES [Certificate]([CertificateId]),
    CONSTRAINT [FK_Question_Skill] FOREIGN KEY ([SkillId]) 
									 REFERENCES [Skill]([SkillId]),
    CONSTRAINT [FK_Question_SkillDetail] FOREIGN KEY ([SkillDetailId]) 
									 REFERENCES [SkillDetail]([SkillDetailId]),
    CONSTRAINT [FK_Question_UserProfile] FOREIGN KEY ([UserId]) 
									 REFERENCES [UserProfile]([UserId]),
    CONSTRAINT [FK_Question_QuestionLevel] FOREIGN KEY ([QuestionLevelId]) 
									 REFERENCES [QuestionLevel]([QuestionLevelId]) 
)
