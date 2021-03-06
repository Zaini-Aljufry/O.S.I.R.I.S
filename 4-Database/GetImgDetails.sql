USE [OSIRIS]
GO
/****** Object:  StoredProcedure [dbo].[GetImgDetails]    Script Date: 11/13/2019 5:42:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sayyed Amir Zaini,,GetImgDetail>
-- Create date: <29,10,2019>
-- Description:	<Get img details from database>
-- =============================================
ALTER PROCEDURE [dbo].[GetImgDetails] 
	@PId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,FileName,FileContent
	From ImageDetails
	where Id=isnull(@PId,Id)
END