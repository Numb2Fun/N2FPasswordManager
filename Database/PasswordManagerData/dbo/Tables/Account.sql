CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] INT NOT NULL,
	[CategoryId] INT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[Website] NVARCHAR(100) NULL,
	[UserName] NVARCHAR(256) NULL,
	[Password] NVARCHAR(256) NULL,
	[EmailAddress] NVARCHAR(256) NULL,
	[LastUpdated] DATETIME2(7) NOT NULL DEFAULT getutcdate(),
	[Notes] NVARCHAR(256) NULL,
	CONSTRAINT [FK_Account_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Account_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
