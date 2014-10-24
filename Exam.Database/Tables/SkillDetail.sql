CREATE TABLE [dbo].[SkillDetail]
(
	[SkillDetailId] INT NOT NULL PRIMARY KEY, 
    [SkillId] INT NOT NULL, 
    [SkillDetailDescription] NVARCHAR(MAX) NULL,
    [SkillDetailOrder] INT NULL, 
    CONSTRAINT [FK_Skill_SkillDetail] FOREIGN KEY ([SkillId]) 
									 REFERENCES [Skill]([SkillId]) 
)
