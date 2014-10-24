CREATE TABLE [dbo].[Certificate]
(
	[CertificateId] INT NOT NULL PRIMARY KEY, 
    [CompanyName] NVARCHAR(500) NOT NULL, 
    [CertificateCode] NVARCHAR(500) NOT NULL, 
    [CertificateName] NVARCHAR(500) NOT NULL, 
    [Technology] NVARCHAR(500) NOT NULL,
	[PublishDate] DATETIME NOT NULL
)
