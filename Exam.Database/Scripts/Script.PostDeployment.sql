/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* Add some seed Certificate rows */
IF NOT EXISTS (SELECT * FROM [Certificate] WHERE CertificateId = 1)
BEGIN
	INSERT INTO [Certificate]
	SELECT 1 , 'Microsoft', '70-480', 'Programming in HTML5 with JavaScript and CSS3', 'Microsoft Visual Studio 2012', 'August 20, 2012'
END 

IF NOT EXISTS (SELECT * FROM [Certificate] WHERE CertificateId = 2)
BEGIN
	INSERT INTO [Certificate]
	SELECT 2 , 'Microsoft', '70-486', 'Developing ASP.NET MVC Web Applications', 'Microsoft Visual Studio 2013, ASP.NET MVC 5.1', 'October 4, 2012'
END 

IF NOT EXISTS (SELECT * FROM [Certificate] WHERE CertificateId = 3)
BEGIN
	INSERT INTO [Certificate]
	SELECT 3 , 'Microsoft', '70-487', 'Developing Microsoft Azure and Web Services', 'Microsoft Visual Studio 2013, Microsoft Azure', 'October 17, 2012'
END

IF NOT EXISTS (SELECT * FROM [Certificate] WHERE CertificateId = 4)
BEGIN
	INSERT INTO [Certificate]
	SELECT 4 , 'Microsoft', '70-461', 'Querying Microsoft SQL Server 2012', 'Microsoft SQL Server 2012', 'June 11, 2012'
END

/* Add some seed Skill rows */
IF NOT EXISTS (SELECT * FROM [Skill] WHERE SkillId = 1)
BEGIN
	INSERT INTO [Skill]
	SELECT 1 , 'Implement and manipulate document structures and objects', 1, 1
END 

IF NOT EXISTS (SELECT * FROM [Skill] WHERE SkillId = 2)
BEGIN
	INSERT INTO [Skill]
	SELECT 2 , 'Implement  program flow', 1, 2
END 

IF NOT EXISTS (SELECT * FROM [Skill] WHERE SkillId = 3)
BEGIN
	INSERT INTO [Skill]
	SELECT 3 , 'Access and secure data', 1, 3
END

IF NOT EXISTS (SELECT * FROM [Skill] WHERE SkillId = 4)
BEGIN
	INSERT INTO [Skill]
	SELECT 4 , 'Use CSS3 in applications', 1, 4
END


IF NOT EXISTS (SELECT * FROM [Skill] WHERE SkillId = 5)
BEGIN
	INSERT INTO [Skill]
	SELECT 5 , 'Create  database objects', 4, 1
END

IF NOT EXISTS (SELECT * FROM [Skill] WHERE SkillId = 6)
BEGIN
	INSERT INTO [Skill]
	SELECT 6 , 'Working with data', 4, 2
END

IF NOT EXISTS (SELECT * FROM [Skill] WHERE SkillId = 7)
BEGIN
	INSERT INTO [Skill]
	SELECT 7 , 'Modify data', 4, 3
END

IF NOT EXISTS (SELECT * FROM [Skill] WHERE SkillId = 8)
BEGIN
	INSERT INTO [Skill]
	SELECT 8 , 'Troubleshoot and Optimize', 4, 4
END


/* Add some seed SkillDetails rows */
IF NOT EXISTS (SELECT * FROM [SkillDetail] WHERE SkillDetailId = 1)
BEGIN
	INSERT INTO [SkillDetail]
	SELECT 1 , 1, 'Create the document structure', 1
END 

IF NOT EXISTS (SELECT * FROM [SkillDetail] WHERE SkillDetailId = 2)
BEGIN
	INSERT INTO [SkillDetail]
	SELECT 2 , 1, 'Write code that interacts with UI controls', 2
END 

IF NOT EXISTS (SELECT * FROM [SkillDetail] WHERE SkillDetailId = 3)
BEGIN
	INSERT INTO [SkillDetail]
	SELECT 3 , 1, 'Apply styling to HTML elements programmatically', 3
END

IF NOT EXISTS (SELECT * FROM [SkillDetail] WHERE SkillDetailId = 4)
BEGIN
	INSERT INTO [SkillDetail]
	SELECT 4 , 1, 'Implement HTML5 APIs', 4
END

IF NOT EXISTS (SELECT * FROM [SkillDetail] WHERE SkillDetailId = 5)
BEGIN
	INSERT INTO [SkillDetail]
	SELECT 5 , 1, 'Establish the scope of objects and variables', 5
END

IF NOT EXISTS (SELECT * FROM [SkillDetail] WHERE SkillDetailId = 6)
BEGIN
	INSERT INTO [SkillDetail]
	SELECT 6 , 1, 'Create and implement objects and methods', 6
END


/* Question Level seed */
IF NOT EXISTS (SELECT * FROM [QuestionLevel] WHERE QuestionLevelId = 1)
BEGIN
	INSERT INTO [QuestionLevel]
	SELECT 1 , 'Junior'
END 

IF NOT EXISTS (SELECT * FROM [QuestionLevel] WHERE QuestionLevelId = 2)
BEGIN
	INSERT INTO [QuestionLevel]
	SELECT 2 , 'Intermediate'
END 

IF NOT EXISTS (SELECT * FROM [QuestionLevel] WHERE QuestionLevelId = 3)
BEGIN
	INSERT INTO [QuestionLevel]
	SELECT 3 , 'Senior'	
END

IF NOT EXISTS (SELECT * FROM [UserProfile] WHERE userId = 'aramkoukia@gmail.com')
BEGIN
	INSERT INTO [UserProfile]
	SELECT 'aramkoukia@gmail.com', 'aramkoukia@gmail.com', 'Aram', 'Koukia', GETDATE()
END 

