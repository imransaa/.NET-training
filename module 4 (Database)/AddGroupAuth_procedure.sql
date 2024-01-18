-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AddGroupAuth
	-- Add the parameters for the stored procedure here
	@document_id int, 
	@group_id int, 
	@role varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @prevRole varchar(255);
	declare @role_id varchar(255);
	set @prevRole = NULL;
	set @role_id = NULL;

	--get role_id
	select @role_id = id from roles where role = @role;

    -- Insert statements for procedure here
	select top 1 @prevRole = r.role from dbo.document_auth_groups dg
	inner join dbo.documents d on d.id = dg.document_id
	inner join dbo.groups g on g.id = dg.group_id
	inner join dbo.roles r on r.id = dg.role_id
	where g.id = @group_id and d.id = @document_id;

	--Check if authorization exists
	if (@prevRole is NULL)
	BEGIN
		insert into dbo.document_auth_groups values(@document_id, @group_id, @role_id);
	END
	ELSE
	BEGIN
		update dbo.document_auth_groups set role_id = @role_id
		where group_id = @group_id and document_id = @document_id;
	END
END
GO
