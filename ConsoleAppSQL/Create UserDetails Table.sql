CREATE TABLE [dbo].[UsersDetails]
(
	[ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [UserName] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NULL
)
