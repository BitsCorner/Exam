CREATE TABLE [dbo].[Answer]
(
	[AnswerId] INT NOT NULL PRIMARY KEY, 
    [QuestionId] BIGINT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [FileName] NVARCHAR(MAX) NULL, 
	[OriginalFileName] NVARCHAR(MAX) NULL, 
    [IsCorrectAnswer] BIT NULL,
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([QuestionId]) 
									 REFERENCES [Question]([QuestionId]) 
)
