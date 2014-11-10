CREATE TABLE [dbo].[QuestionComment]
(
	[QuestionCommentId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [QuestionId] INT NOT NULL, 
	[UserId] NVARCHAR(500) NULL, 
	[CommentDate] DATETIME NOT NULL, 
	[Email] NVARCHAR(500) NULL, 
	[FullName] NVARCHAR(500) NULL, 
	[ParrentCommentId] BIGINT NULL, 
	[Confirmed] BIT, 
	[ConfirmedBy] NVARCHAR(500) NULL, 
	[ConfirmDate] DATETIME, 
    CONSTRAINT [FK_QuestionComment_Question] FOREIGN KEY ([QuestionId]) 
									 REFERENCES [Certificate]([CertificateId]),
    CONSTRAINT [FK_QuestionComment_User] FOREIGN KEY ([UserId]) 
									 REFERENCES [UserProfile]([UserId])
)
