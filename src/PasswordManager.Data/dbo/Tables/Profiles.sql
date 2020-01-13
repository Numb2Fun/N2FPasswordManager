CREATE TABLE [dbo].[Profiles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] NVARCHAR(128) NOT NULL,
	[CategoryId] INT NULL,
	[Title] NVARCHAR(128) NOT NULL,
	[Website] NVARCHAR(256) NULL,
	[LoginName] NVARCHAR(256) NULL,
	[Password] NVARCHAR(256) NULL,
	[SignUpEmail] NVARCHAR(256) NULL,
	[LastUpdated] DATETIME2 NOT NULL DEFAULT getutcdate(),
	CONSTRAINT [FK_Profile_ToAspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]),
	CONSTRAINT [FK_Profile_ToCategories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
)
