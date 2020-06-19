USE OSIRIS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sayyed Amir Zaini>
-- Create date: <11/13/2019>
-- Description:	<Get Function>
-- =============================================
CREATE PROCEDURE [dbo].[AddImgDetails]
	@FileName nvarchar(max),
	@FileContent varbinary(max),
	@ImgClassification nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Insert into ProcessImgDetails values(@FileName,@FileContent,@ImgClassification) 
END
GO
