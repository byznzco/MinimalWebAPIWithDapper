# MinimalWebAPIWithDapper
![image](https://github.com/byznzco/MinimalWebAPIWithDapper/assets/85300745/61cbe29d-76aa-48b6-a888-2eea883ff8fe)



UserDB.publish.xml 
// Data source should be added

	<?xml version="1.0" encoding="utf-8"?>
	<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
	  <PropertyGroup>
	    <IncludeCompositeObjects>True</IncludeCompositeObjects>
	    <TargetDatabaseName>UserDB</TargetDatabaseName>
	    <DeployScriptFileName>UserDB.sql</DeployScriptFileName>
	    <TargetConnectionString>Data Source= ;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=True;Command Timeout=0</TargetConnectionString>
	    <ProfileVersionNumber>1</ProfileVersionNumber>
	  </PropertyGroup>
	</Project>


Script.PostDeployment.sql

IF NOT EXISTS (SELECT 1 FROM DBO.[USER])
BEGIN 
	INSERT INTO DBO.[User] (FirstName, LastName)
	VALUES
		('Ada', 'Lovelace'),
		('Beyza', 'Salı'),
		('Elif', 'Beta'),
		('Ufuk', 'Ulusoy'),
    ('İrem', 'Tatlı');
END

-Table-
CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL
)

Stored Procedures

- EXEC_DELETE_USER.sql
- EXEC_UPDATE_USER.sql
- EXEC_INSERT_USER.sql
- EXEC_GET_USER.sql
- EXEC_GET_ALL_USERS.sql

