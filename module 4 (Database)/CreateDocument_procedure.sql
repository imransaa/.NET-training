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
CREATE PROCEDURE CreateDocument
	-- Add the parameters for the stored procedure here
	@name varchar(255), 
	@creator_id varchar(255),
	@type varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @type_id int;
	set @type_id = null;

	-- Get type id
	select top 1 @type_id = id from document_types where type = @type;

    -- Insert statements for procedure here
	if(@type_id is not null)
	begin
		insert into documents(name, creator_id, type_id) values(@name, @creator_id, @type_id);
	end
	else
	begin
		print 'Type Does not exist'
	end
END
GO
