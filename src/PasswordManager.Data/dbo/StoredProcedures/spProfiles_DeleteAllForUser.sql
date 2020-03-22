CREATE PROCEDURE [dbo].[spProfiles_DeleteAllForUser]
	@userId NVARCHAR(128)
AS
begin
	set nocount on;

	delete from [dbo].[Profiles]
	where UserId = @userId;
end