CREATE TABLE [dbo].[UserAttempt]
(
	[AttemptId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [QuestionId] BIGINT NOT NULL, 
	[UserId] NVARCHAR(500) NOT NULL, 
	[AttemptDate] DATETIME NULL, 
    [TimeSpent] NVARCHAR(50) NULL, 
    [GotItRight] BIT NULL,
    [Answers] NVARCHAR(500) NULL, 
    CONSTRAINT [FK_UserAttempt_Question] FOREIGN KEY ([QuestionId]) 
									 REFERENCES [Question]([QuestionId]),
    CONSTRAINT [FK_UserAttempt_User] FOREIGN KEY ([UserId]) 
									 REFERENCES [UserProfile]([UserId])
)
