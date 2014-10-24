CREATE TABLE [dbo].[Skill]
(
	[SkillId] INT NOT NULL PRIMARY KEY, 
    [SkillName] NVARCHAR(500) NOT NULL, 
    [CertificateId] INT NOT NULL,
    [SkillOrder] INT NOT NULL, 
    CONSTRAINT [FK_Skill_Certificate] FOREIGN KEY ([CertificateId]) 
									 REFERENCES [Certificate]([CertificateId]) 
)
