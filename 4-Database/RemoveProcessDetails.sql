USE [OSIRIS]
GO
/****** Object:  StoredProcedure [dbo].[RemoveProcessDetails]    Script Date: 11/19/2019 11:50:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sayyed Amir Zaini>
-- Create date: <11/13/2019>
-- Description:	<Delete Function>
-- =============================================
ALTER PROCEDURE [dbo].[RemoveProcessDetails]
(
	@FileName varchar(Max),  
	@FileContent varBinary(Max),
	@ImgClassification varchar(Max)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete From  ProcessImgDetails 
	Where(@FileName = FileName) 
END
