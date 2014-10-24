CREATE TABLE [dbo].[UserProfile]
(
    [UserId] NVARCHAR(500) NOT NULL, 
    [Email] NVARCHAR(500) NOT NULL, 
    [FirstName] NVARCHAR(500) NOT NULL, 
    [LastName] NVARCHAR(500) NULL, 
    [CreatedDate] DATETIME NULL, 
    CONSTRAINT [PK_UserProfile] PRIMARY KEY ([UserId])
)
