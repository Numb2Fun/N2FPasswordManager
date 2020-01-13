CREATE PROCEDURE [dbo].[spProfiles_GetForUser]
	@userId NVARCHAR(128)
as
begin
	set nocount on
	
	select *
	from [dbo].[Profiles] as p
	where p.[UserId] = @userId

end