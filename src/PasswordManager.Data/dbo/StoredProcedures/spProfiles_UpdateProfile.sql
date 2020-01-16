CREATE PROCEDURE [dbo].[spProfiles_UpdateProfile]
	@id int,
	@categoryId int,
	@title nvarchar(128),
	@website nvarchar(256),
	@loginName nvarchar(256),
	@password nvarchar(256),
	@signUpEmail nvarchar(256),
	@lastUpdated datetime2(7)
as
begin
	set nocount on

	update [dbo].[Profiles]
	set 
		CategoryId = @categoryId,
		Title = @title,
		Website = @website,
		LoginName = @loginName,
		[Password] = @password,
		SignUpEmail = @signUpEmail,
		LastUpdated = @lastUpdated
	where
		Id = @id
end
