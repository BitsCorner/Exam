CREATE TABLE [dbo].[QuestionVote]
(
    [QuestionVoteId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
	[QuestionId] BIGINT NOT NULL, 
	[UserId] NVARCHAR(500) NULL, 
    [Vote] INT NOT NULL, 
	[VoteDate] DATETIME NOT NULL 
    CONSTRAINT [FK_QuestionVote_Question] FOREIGN KEY ([QuestionId]) 
									 REFERENCES [Question]([QuestionId]),
    CONSTRAINT [FK_Question_User] FOREIGN KEY ([UserId]) 
									 REFERENCES [UserProfile]([UserId])
)
