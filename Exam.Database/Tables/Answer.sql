CREATE TABLE [dbo].[Answer]
(
	[AnswerId] INT NOT NULL PRIMARY KEY, 
    [RowId] INT NULL, 
    [QuestionId] BIGINT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [IsCorrectAnswer] BIT NULL,
    [CreatedDate] DATETIME NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [ModifiedDate] DATETIME NULL, 
    [ModifiedBy] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([QuestionId]) 
									 REFERENCES [Question]([QuestionId]) 
)
