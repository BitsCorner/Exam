CREATE TABLE [dbo].[UserAttemptDetail]
(
	[AttemptDetailId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [AttemptId] BIGINT NOT NULL, 
	[QuestionId] BIGINT NOT NULL, 
	[TimeSpent] NVARCHAR(50) NULL, 
    [GotItRight] BIT NULL,
    [Answers] NVARCHAR(500) NULL, 
    CONSTRAINT [FK_UserAttemptDetail_Question] FOREIGN KEY ([QuestionId]) 
									 REFERENCES [Question]([QuestionId]),
    CONSTRAINT [FK_UserAttemptDetail_UserAttempt] FOREIGN KEY ([AttemptId]) 
									 REFERENCES [UserAttempt]([AttemptId])
)
