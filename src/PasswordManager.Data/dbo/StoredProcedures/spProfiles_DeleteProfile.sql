CREATE PROCEDURE [dbo].[spProfiles_DeleteProfile]
	@id int
as
begin
	set nocount on

	delete from [dbo].[Profiles]
	where [Id] = @id;
end