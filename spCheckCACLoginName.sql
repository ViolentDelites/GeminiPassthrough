USE [CLWaterDB_02112024]
GO
/****** Object:  StoredProcedure [dbo].[spCheckCACLoginName]    Script Date: 4/2/2024 3:31:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spCheckCACLoginName]
	@p_login_nm VARCHAR(100)	
AS
BEGIN
		SET NOCOUNT ON;
    		SELECT  is_va_user,
		is_admin,
		user_id, 
			first_nm, 
		last_nm 
			FROM TBL_USER 
			WHERE login_nm = @p_login_nm
END