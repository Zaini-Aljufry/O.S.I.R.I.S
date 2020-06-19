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
CREATE PROCEDURE [dbo].[GetProcessImg]
	@PId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,FileName,FileContent,ImgClassification
	From ProcessImgDetails
	where Id = isnull (@PId,Id)
END
GO
