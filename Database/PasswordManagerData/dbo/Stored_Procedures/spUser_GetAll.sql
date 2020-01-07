CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin

set nocount on

select UserName, EmailAddress, DateCreated
from [User]

end