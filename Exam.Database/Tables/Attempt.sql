CREATE TABLE [dbo].[UserAttempt]
(
	[AttemptId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
	[UserId] NVARCHAR(500) NOT NULL, 
	[StartTime] DATETIME NULL, 
	[EndTime] DATETIME NULL, 
    [TimeSpent] NVARCHAR(50) NULL, 
    [Finished] BIT NULL, 
    [QuestionIds] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_UserAttempt_User] FOREIGN KEY ([UserId]) 
									 REFERENCES [UserProfile]([UserId])
)
