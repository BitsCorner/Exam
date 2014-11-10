CREATE TABLE [dbo].[UserProfile]
(
    [UserId] NVARCHAR(500) NOT NULL, 
    [Email] NVARCHAR(500) NOT NULL, 
    [FullName] NVARCHAR(500) NULL, 
    [CreatedDate] DATETIME NULL, 
    CONSTRAINT [PK_UserProfile] PRIMARY KEY ([UserId])
)
