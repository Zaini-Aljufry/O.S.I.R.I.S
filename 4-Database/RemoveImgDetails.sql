
USE OSIRIS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sayyed Amir Zaini>
-- Create date: <11/13/2019>
-- Description:	<Delete Function>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveImgDetails]
(
	@FileName varchar(Max),  
	@FileContent varBinary(Max)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete From  ImageDetails 
	Where(@FileName = FileName) 
END
GO
