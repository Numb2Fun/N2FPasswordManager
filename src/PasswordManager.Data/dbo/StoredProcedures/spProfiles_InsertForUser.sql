CREATE PROCEDURE [dbo].[spProfiles_InsertForUser]
	@userId nvarchar(128),
	@categoryId int,
	@title nvarchar(128),
	@website nvarchar(256),
	@loginName nvarchar(256),
	@password nvarchar(256),
	@signUpEmail nvarchar(256)
AS
begin
	set nocount on

	insert into [dbo].[Profiles] (
		[UserId], 
		[CategoryId], 
		[Title], 
		[Website], 
		[LoginName], 
		[Password],
		[SignUpEmail]
	)
	values (
		@userId,
		@categoryId,
		@title,
		@website,
		@loginName,
		@password,
		@signUpEmail
	)

end